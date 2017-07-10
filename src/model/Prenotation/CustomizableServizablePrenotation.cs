using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Users;
using CSB_Project.src.model.Utils;
using CSB_Project.src.model.TrackingDevice;
using CSB_Project.src.model.Services;
using System.Collections.ObjectModel;

namespace CSB_Project.src.model.Prenotation
{
    public class CustomizableServizablePrenotation : ICustomizablePrenotation, IServizablePrenotation
    {
        #region Campi
        /// <summary>
        /// Id della prenotazione
        /// </summary>
        private readonly int _id;
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
        private readonly IList<IPacket> _packets;
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
        /// Id della prenotazione
        /// </summary>
        public int Id => _id;
        /// <summary>
        /// Items prenotati
        /// </summary>
        public ReadOnlyCollection<IItemPrenotation> BookedItems  => new ReadOnlyCollection<IItemPrenotation>(_bookedItems);
        /// <summary>
        /// Pacchetti comprati
        /// </summary>
        public ReadOnlyCollection<IPacket> Packets => new ReadOnlyCollection<IPacket>(_packets);
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
                double price=0;
                foreach (IItemPrenotation ip in _bookedItems)
                    price += ip.Price;
                foreach (IPacket p in _packets)
                    price += p.Price;
                foreach (IBundle b  in _bundles)
                    price += b.Price;
                
                return price;
            }
        }
        #endregion

        #region Costruttori
        public CustomizableServizablePrenotation(int id, ICustomer client, DateRange prenotationDate,
            IEnumerable<IItemPrenotation> items, ITrackingDevice baseTrackingDevice, 
            AssociationDescriptor tdDesc, IEnumerable<IPacket> packets = null,
            IEnumerable<IBundle> bundles = null)
        {
            #region Precondizioni
            if (id < 0)
                throw new ArgumentException("id is not valid");
            if (prenotationDate == null)
                throw new ArgumentNullException("range data null");
            if(client == null)
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
            foreach (IPacket packet in packets)
                if (!CanAdd(packet))
                    throw new InvalidOperationException("packet not valid");
            foreach (IBundle bundle in bundles)
                if (!CanAdd(bundle))
                    throw new InvalidOperationException("bundle not valid");
            foreach (IItemPrenotation ip in items)
                if (!CanAdd(ip))
                    throw new InvalidOperationException("item prenotation not valid");
            // Verifico che gli item comprano interamente la prenotazione
            // per ogni giorno ci deve essere almeno un item
            if (!IsIstantiable(items))
                throw new InvalidOperationException("gli item non comprono interamente la prenotazione");
            #endregion

            _id = id;
            _client = client;
            _prenotationDate = prenotationDate;
            _bookedItems = items.ToList();
            _packets = packets?.ToList() ?? new List<IPacket>();
            _bundles = bundles != null ? new HashSet<IBundle>(bundles) : new HashSet<IBundle>();
            _tdAssociations = new Dictionary<ITrackingDevice, AssociationDescriptor>();
            AddTrackingDevice(baseTrackingDevice, tdDesc);
        }

        public CustomizableServizablePrenotation(int id, ICustomer client, DateRange rangeData, IEnumerable<IItemPrenotation> items, 
            ITrackingDevice baseTrackingDevice, AssociationDescriptor tdDesc, IEnumerable<IBundle> bundles) 
            : this(id, client, rangeData, items, baseTrackingDevice, tdDesc, null, bundles) { }
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
        }
        public void AddPacket(IPacket packet)
        {
            #region Precondizioni
            if (packet == null)
                throw new ArgumentNullException("tracking device null");
            if (!CanAdd(packet))
                new Exception("packet not valid");
            #endregion
            _packets.Add(packet);
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
        }

        private bool IsIstantiable(IEnumerable<IItemPrenotation> items)
        {
            return PrenotationDate.IsComplete((from i in items
                              select i.RangeData));
        }

        private bool CanAdd(IPacket packet)
        {
            return packet.IsActiveIn(PrenotationDate);
        }
        private bool CanAdd(IBundle bundle)
        {
            return bundle.IsActiveIn(PrenotationDate)
                && _bundles.Contains(bundle);
        }
        private bool CanAdd(IItemPrenotation IItemPrenotation) 
        {
            return PrenotationDate.Contains(IItemPrenotation.RangeData);
        }
        #endregion
    }
}
