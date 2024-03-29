﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Users;
using CSB_Project.src.model.Utils;
using CSB_Project.src.model.TrackingDevice;
using CSB_Project.src.model.Services;
using System.Collections.ObjectModel;
using CSB_Project.src.presentation.Utils;

namespace CSB_Project.src.model.Prenotation
{
    public class CustomizableServizablePrenotation : ICustomizableServizablePrenotation, IServizablePrenotation
    {
        #region Eventi
        public event EventHandler<PrenotationEventArgs> PrenotationChanged;
        #endregion

        #region Campi
        /// <summary>
        /// Cliente a cui è associata la prenotazione
        /// </summary>
        private readonly ICustomer _client;
        /// <summary>
        /// Tracking device associati alla prenotazione
        /// </summary>
        private readonly IDictionary<ITrackingDevice, AssociationDescriptor> _tdAssociations;
        /// <summary>
        /// Giorni riservati alla prenotazione
        /// </summary>
        private readonly DateRange _prenotationDate;
        /// <summary>
        /// Items prenotati
        /// </summary>
        private readonly IList<IItemPrenotation> _bookedItems;
        /// <summary>
        /// Pacchetti comprati
        /// </summary>
        private readonly IList<IPacketPurchase> _packetsPurchases;
        /// <summary>
        /// Bundle comprati
        /// </summary>
        private readonly ISet<IBundle> _bundles;
        #endregion

        #region Proprieta
        /// <summary>
        /// Cliente a cui è associata la prenotazione
        /// </summary>
        public ICustomer Client => _client;
        public DateRange PrenotationDate => _prenotationDate;
        /// <summary>
        /// Items prenotati
        /// </summary>
        public ReadOnlyCollection<IItemPrenotation> BookedItems => new ReadOnlyCollection<IItemPrenotation>(_bookedItems);
        /// <summary>
        /// Pacchetti comprati
        /// </summary>
        public ReadOnlyCollection<IPacket> Packets => new ReadOnlyCollection<IPacket>((from p in _packetsPurchases select p.Packet).ToList());
        public ReadOnlyCollection<IPacketPurchase> PacketsPurchases => new ReadOnlyCollection<IPacketPurchase>(_packetsPurchases);
        /// <summary>
        /// Bundle comprati
        /// </summary>
        public ReadOnlyCollection<IBundle> Bundles => new ReadOnlyCollection<IBundle>(_bundles.ToList());
        /// <summary>
        /// Tracking device associati alla prenotazione e relative info
        /// </summary>
        public ReadOnlyCollection<KeyValuePair<ITrackingDevice, AssociationDescriptor>> TrackingDeviceAssociations
         => new ReadOnlyCollection<KeyValuePair<ITrackingDevice, AssociationDescriptor>>(_tdAssociations.ToList());
        /// <summary>
        /// Tracking device associati alla prenotazione
        /// </summary>
        public ReadOnlyCollection<ITrackingDevice> TrackingDevices
         => new ReadOnlyCollection<ITrackingDevice>(_tdAssociations.Keys.ToList());

        /// <summary>
        /// Prezzo corrente della prenotazione non comprensivo dei servizi utilizzati
        /// </summary>
        public double Price
        {
            get
            {
                double price = 0;
                foreach (IItemPrenotation ip in _bookedItems)
                    price += ip.Price;
                foreach (IPacket p in Packets)
                    price += p.Price;
                foreach (IBundle b in Bundles)
                    price += b.Price;

                return price;
            }
        }

        public string InformationString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (IItemPrenotation ip in BookedItems)
                {
                    sb.AppendLine(ip.InformationString);
                    sb.AppendLine("");
                }

                sb.AppendLine(Environment.NewLine + "PACCHETTI COMPRATI:");
                foreach (IPacket p in Packets)
                {
                    sb.AppendLine(p.InformationString);
                    sb.AppendLine("");
                }

                sb.AppendLine(Environment.NewLine + "BUNDLE COMPRATI:");
                foreach (IBundle b in Bundles)
                {
                    sb.AppendLine(b.InformationString);
                    sb.AppendLine("");
                }
                return sb.ToString();
            }
        }
        #endregion

        #region Costruttori
        public CustomizableServizablePrenotation(ICustomer client, DateRange prenotationDate,
            IEnumerable<IItemPrenotation> items, ITrackingDevice baseTrackingDevice,
            AssociationDescriptor tdDesc, IEnumerable<IPacket> packets = null,
            IEnumerable<IBundle> bundles = null)
        {
            #region Precondizioni
            if (prenotationDate == null)
                throw new ArgumentNullException("range data null");
            if (client == null)
                throw new ArgumentNullException("client null");
            if (items == null)
                throw new ArgumentNullException("items null");
            if (baseTrackingDevice == null)
                throw new ArgumentNullException("baseTrackingDevice null");
            if (tdDesc == null)
                throw new ArgumentNullException("tdDesc null");
            if (!tdDesc.DateRange.Equals(prenotationDate))
                throw new InvalidOperationException("Il tracking device base deve essere +" +
                    "associato per tutta la prenotazione");

            #endregion

            _client = client;
            _prenotationDate = prenotationDate;
            _bookedItems = items.ToList();
            _packetsPurchases = new List<IPacketPurchase>();
            List<IPacket> packetList = new List<IPacket>();

            foreach (IPacket packet in packets ?? new IPacket[0])
            {
                if (!CanAdd(packet))
                    throw new InvalidOperationException("packet not valid");
                DateTime start = prenotationDate.StartDate > packet.Availability.StartDate ? 
                    prenotationDate.StartDate : packet.Availability.StartDate;

                _packetsPurchases.Add(new PacketPurchase(start, packet));
            }

            _bundles = new HashSet<IBundle>();
            _tdAssociations = new Dictionary<ITrackingDevice, AssociationDescriptor>();
            AddTrackingDevice(baseTrackingDevice, tdDesc);

            foreach (IBundle bundle in bundles ?? new IBundle[0])
            {
                if (!CanAdd(bundle))
                    throw new InvalidOperationException("bundle not valid");
                _bundles.Add(bundle);
            }

            foreach (IItemPrenotation ip in _bookedItems)
                if (!CanAdd(ip))
                    throw new InvalidOperationException("item prenotation not valid");

            // Verifico che gli item comprano interamente la prenotazione
            // per ogni giorno ci deve essere almeno un item
            if (!IsIstantiable(_bookedItems))
                throw new InvalidOperationException("gli item non comprono interamente la prenotazione");
        }

        public CustomizableServizablePrenotation(ICustomer client, DateRange rangeData, IEnumerable<IItemPrenotation> items,
            ITrackingDevice baseTrackingDevice, AssociationDescriptor tdDesc, IEnumerable<IBundle> bundles)
            : this( client, rangeData, items, baseTrackingDevice, tdDesc, null, bundles) { }
        #endregion

        #region Metodi
        public void AddItem(IItemPrenotation item)
        {
            #region Precondizioni
            if (item == null)
                throw new ArgumentNullException("item null");
            if (!CanAdd(item))
                throw new Exception("item prenotation not valid");
            #endregion
            _bookedItems.Add(item);
            item.PrenotationChanged += (sender, ipea) => OnPrenotatitionChangedHandler(this, new PrenotationEventArgs(this));
            OnPrenotatitionChangedHandler(this, new PrenotationEventArgs(this));
        }
        public void AddTrackingDevice(ITrackingDevice trackingDevice, AssociationDescriptor associationDescriptor)
        {
            #region Precondizioni
            if (trackingDevice == null)
                throw new ArgumentNullException("tracking device null");
            if (associationDescriptor == null)
                throw new ArgumentNullException("association Descriptor null");
            if (!PrenotationDate.Contains(associationDescriptor.DateRange))
                throw new Exception("date range not valid");
            #endregion
            _tdAssociations.Add(trackingDevice, associationDescriptor);
            OnPrenotatitionChangedHandler(this, new PrenotationEventArgs(this));
        }
        
        public void AddPacket(IPacket packet, DateTime date)
        {
            #region Precondizioni
            if (packet == null)
                throw new ArgumentNullException("tracking device null");
            if (!CanAdd(packet))
                new Exception("packet not valid");
            if(!PrenotationDate.Contains(date))
                new Exception("prenotation not available in this date");
            #endregion
            _packetsPurchases.Add(new PacketPurchase(date,packet));
            OnPrenotatitionChangedHandler(this, new PrenotationEventArgs(this));
        }
        public void AddPacket(IPacket packet)
        {
            AddPacket(packet, DateTime.Now);
        }
        public void AddBundle(IBundle bundle)
        {
            #region Precondizioni
            if (bundle == null)
                throw new ArgumentNullException("bundle null");
            if (!CanAdd(bundle))
                new Exception("bundle not valid");
            #endregion
            _bundles.Add(bundle);
            OnPrenotatitionChangedHandler(this, new PrenotationEventArgs(this));
        }

        private bool IsIstantiable(IEnumerable<IItemPrenotation> items)
        {
            return PrenotationDate.IsComplete((from i in items
                                               select i.RangeData));
        }

        private bool CanAdd(IPacket packet)
        {
            return packet.Availability.OverlapWith(_prenotationDate);
        }

        private bool CanAdd(IBundle bundle)
        {
            return bundle.Availability.OverlapWith(PrenotationDate)
                && !_bundles.Contains(bundle);
        }
        private bool CanAdd(IItemPrenotation IItemPrenotation)
        {
            return PrenotationDate.Contains(IItemPrenotation.RangeData);
        }

        public void Accept(IPrenotationVisitor visitor)
        {
            visitor.Visit(this);
            foreach (IItemPrenotation p in _bookedItems)
                p.Accept(visitor);
        }
        #endregion

        #region EventHandler
        private void OnPrenotatitionChangedHandler(Object sender, PrenotationEventArgs args)
        {
            PrenotationChanged?.Invoke(sender, args);
        }
        #endregion
    }
}
