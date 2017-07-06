using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Users;
using CSB_Project.src.model.Utils;
using CSB_Project.src.model.TrackingDevice;
using CSB_Project.src.model.Services;

namespace CSB_Project.src.model.Prenotation
{
    public class Prenotation
    {

        #region Eventi
        #endregion
        #region Campi
        private readonly int _id;
        private readonly Client _client;
        private readonly IDictionary<ITrackingDevice, AssociationDescriptor> _tdAssociations;
        private readonly DateRange _rangeData;
        private readonly List<ItemPrenotation> _items;
        private readonly IEnumerable<IPacket> _packets;
        private readonly IEnumerable<IBundle> _bundles;
        #endregion
        #region Proprieta

        public Client Client => _client;
        public DateRange RangeData => _rangeData;
        public int Id => _id;
        public  List<ItemPrenotation> Items  => _items;
        public IEnumerable<IPacket> Packets => _packets.ToArray();
        public IEnumerable<IBundle> Bundles => _bundles.ToArray();
        public IEnumerable<KeyValuePair<ITrackingDevice, AssociationDescriptor>> TrackingDeviceAssociations
        {
            get
            {
                KeyValuePair<ITrackingDevice, AssociationDescriptor>[] copy = new KeyValuePair<ITrackingDevice, AssociationDescriptor>[_tdAssociations.Count];
                _tdAssociations.CopyTo(copy, 0);
                return copy;
            }
        }
        public double Price
        {
            get
            {
                double price=0;
                foreach (ItemPrenotation ip in _items)
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
        public Prenotation(int id, Client client, DateRange rangeData, List<ItemPrenotation> items, ITrackingDevice baseTrackingDevice, IEnumerable<IPacket> packets, IEnumerable<IBundle> bundles)
        {
            #region Precondizioni
            if (id < 0)
                throw new ArgumentException("id is not valid");
            if (rangeData == null)
                throw new ArgumentNullException("range data null");
            if(client == null)
                throw new ArgumentNullException("client null");
            if (items == null)
                throw new ArgumentNullException("items null");
            if (baseTrackingDevice == null)
                throw new ArgumentNullException("baseTrackingDevice null");
            if (packets == null)
                throw new ArgumentNullException("packets null");
            if (bundles == null)
                throw new ArgumentNullException("bundles null");
            if (!isInstantiable(items))
                throw new Exception("items not valid");
            foreach (ItemPrenotation ip in items)
                if (!isValid(ip))
                    throw new Exception("item prenotation not valid");
            foreach (IPacket packet in packets)
                if (!isValid(packet))
                    throw new Exception("packet not valid");
            foreach (IBundle bundle in bundles)
                if (!isValid(bundle))
                    throw new Exception("bundle not valid");
            #endregion
            _id = id;
            _client = client;
            _rangeData = rangeData;
            _items = items;
            _tdAssociations = new Dictionary<ITrackingDevice, AssociationDescriptor>();
            AddTrackingDevice(baseTrackingDevice, new AssociationDescriptor(rangeData, "Base"));
            _packets = packets;
            _bundles = bundles;
        }
        public Prenotation(int id, Client client, DateRange rangeData, List<ItemPrenotation> items, ITrackingDevice baseTrackingDevice) : this(id, client , rangeData, items, baseTrackingDevice, new List<IPacket>(), new List<IBundle>()) { }
        public Prenotation(int id, Client client, DateRange rangeData, List<ItemPrenotation> items, ITrackingDevice baseTrackingDevice, IEnumerable<IPacket> packets) : this(id, client, rangeData, items, baseTrackingDevice,packets, new List<IBundle>()) { }
        public Prenotation(int id, Client client, DateRange rangeData, List<ItemPrenotation> items, ITrackingDevice baseTrackingDevice, IEnumerable<IBundle> bundles) : this(id, client, rangeData, items, baseTrackingDevice, new List<IPacket>(), bundles) { }
        #endregion
        #region Metodi
        public void AddItem(ItemPrenotation item)
        {
            #region Precondizioni
            if (item == null)
                throw new ArgumentNullException("item null");
            if (!isValid(item))
                throw new Exception("item prenotation not valid");
            #endregion

            Items.Add(item);
        }
        public void AddTrackingDevice(ITrackingDevice trackingDevice, AssociationDescriptor associationDescriptor)
        {
            #region Precondizioni
            if (trackingDevice == null)
                throw new ArgumentNullException("tracking device null");
            if (associationDescriptor == null)
                throw new ArgumentNullException("association Descriptor null");
            if (!RangeData.Contains(associationDescriptor.DateRange))
                throw new Exception("date range not valid");
            #endregion
            _tdAssociations.Add(trackingDevice, associationDescriptor);
        }
        public void addPacket(IPacket packet)
        {
            #region Precondizioni
            if (packet == null)
                throw new ArgumentNullException("tracking device null");
            if (!isValid(packet))
                new Exception("packet not valid");
            #endregion
            (_packets as List<IPacket>).Add(packet);
        }
        public void addBundle(IBundle bundle)
        {
            #region Precondizioni
            if (bundle == null)
                throw new ArgumentNullException("bundle null");
            if (!isValid(bundle))
                new Exception("bundle not valid");
            #endregion
            (_bundles as List<IBundle>).Add(bundle);
        }

        private bool isInstantiable(IEnumerable<ItemPrenotation> items)
        {
            //return RangeData.isComponibleBy((from i in items
            //                                 select i.RangeData));
            return false;
        }

        private bool isValid(IPacket packet)
        {
            return packet.IsActiveIn(RangeData);
        }
        private bool isValid(IBundle bundle)
        {
            return bundle.IsActiveIn(RangeData);
        }
        private bool isValid(ItemPrenotation itemPrenotation) 
        {
            return RangeData.Contains(itemPrenotation.RangeData);
        }
        #endregion
        #region Handler
        #endregion


    }
}
