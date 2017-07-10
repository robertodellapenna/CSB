using System;
using System.Collections.Generic;
using CSB_Project.src.model;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Services;
using CSB_Project.src.model.Utils;
using CSB_Project.src.model.TrackingDevice;

namespace CSB_Project.src.business
{
    public interface IServiceCoordinator : ICoordinator
    {
        IEnumerable<IBundle> Bundles { get; }
        void AddBundle(IBundle bundle);
        IEnumerable<IPacket> Packets { get; }
        void AddPacket(IPacket packet);
        IEnumerable<IUsable> Services { get; }
        void AddService (IUsable service);
        IEnumerable<IUsage> Usages { get; }
        void AddUsage (IUsage usage);
        IEnumerable<IUsage> FilterCard(ITrackingDevice card);
        IEnumerable<IPacket> FilterPacketName(string name);
        IEnumerable<IBundle> FilterBundleName(string name);
        IEnumerable<IBundle> FilterBundleDate(DateRange data);
        IEnumerable<IPacket> FilterPacketDate(DateRange data);
        event EventHandler ServiceChanged;
    }
    public class ServiceCoordinator : AbstractCoordinatorDecorator, IServiceCoordinator
    {
        #region Eventi
        public event EventHandler ServiceChanged;
        #endregion
        #region Campi
        private readonly List<IBundle> _bundles = new List<IBundle>();
        private readonly List<IPacket> _packets = new List<IPacket>();
        private readonly List<IUsable> _services = new List<IUsable>();
        private readonly List<IUsage> _usages = new List<IUsage>();
        #endregion
        #region Proprieta
        public IEnumerable<IBundle> Bundles => _bundles.ToArray();
        public IEnumerable<IPacket> Packets => _packets.ToArray();
        public IEnumerable<IUsable> Services => _services.ToArray();
        public IEnumerable<IUsage> Usages => _usages.ToArray();

        #endregion
        #region Costruttori
        public ServiceCoordinator(ICoordinator next) : base(next)
        {
        }
        #endregion
        #region Metodi
        protected override void Init()
        {
            DateRange date1 = new DateRange(10);
            DateRange date2 = new DateRange(12);
            IUsable service1 = new BasicService(new DatePriceDescriptor("servizio1", "servizio1", date1, 5.0));
            IUsable service2 = new BasicService(new DatePriceDescriptor("servizio2", "servizio2", date2, 6.0));
            IUsable service3 = new BasicService(new DatePriceDescriptor("servizio3", "servizio3", date2, 4.0));
            _services.Add(service1);
            _services.Add(service2);
            _services.Add(service3);
            IPacket packet1 = new TicketPacket((new DatePriceDescriptor("packet1", "packet1", date1, 12.0)), service2, 5);
            IPacket packet2 = new TicketPacket((new DatePriceDescriptor("packet2", "packet2", date1, 15.0)), service3, 10);
            _packets.Add(packet1);
            _packets.Add(packet2);
            ISet<IPacket> bundleSet = new HashSet<IPacket>();
            bundleSet.Add(packet1);
            bundleSet.Add(packet2);
            IBundle bundle1 = new Bundle(bundleSet, new DatePriceDescriptor("bundle1", "bundle1", date1, 23.0));
            _bundles.Add(bundle1);
        }
        public void AddBundle(IBundle bundle)
        {
            #region Precondizioni
            if (bundle == null)
                throw new ArgumentNullException("bundle null");
            foreach (IBundle b in _bundles)
            {
                if (b.Name.Equals(bundle.Name))
                    throw new ArgumentException("bundle with same name is already present");
            }
            #endregion
            if (!_bundles.Contains(bundle))
                _bundles.Add(bundle);
        }

        public void AddPacket(IPacket packet)
        {
            #region Precondizioni
            if (packet == null)
                throw new ArgumentNullException("paccket null");
            #endregion
            foreach(IPacket p in _packets)
            {
                if (p.Name.Equals(packet.Name))
                    throw new ArgumentException("packet with same name is already present");
            }
            if (!_packets.Contains(packet))
                _packets.Add(packet);
        }

        public void AddService(IUsable service)
        {
            #region Precondizioni
            if (service == null)
                throw new ArgumentNullException("service null");
            foreach (IUsable s in _services)
            {
                if (s.Name.Equals(service.Name))
                    throw new ArgumentException("service with same name is already present");
            }
            #endregion
            if (!_services.Contains(service))
                _services.Add(service);
        }

        public void AddUsage(IUsage usage)
        {
            #region Precondizioni
            if (usage == null)
                throw new ArgumentNullException("usage null");
            #endregion
            if (!_usages.Contains(usage))
                _usages.Add(usage);
        }

        public IEnumerable<IUsage> FilterCard(ITrackingDevice card)
        {

            return _usages.Where(usage => usage.Who.Id == card.Id);
        }

        public IEnumerable<IPacket> FilterPacketDate(DateRange data)
        {
            return _packets.Where(packet => packet.Availability.Contains(data));
        }

        public IEnumerable<IBundle> FilterBundleDate(DateRange data)
        {
            return _bundles.Where(bundle => bundle.Availability.Contains(data));
        }

        public IEnumerable<IPacket> FilterPacketName(string name)
        {
            return _packets.Where(packet => packet.Name.Equals(name));
        }

        public IEnumerable<IBundle> FilterBundleName(string name)
        {
            return _bundles.Where(bundle => bundle.Name.Equals(name));
        }

        #endregion
        #region Handler
        private void OnServiceChanged(Object sender, EventArgs args)
        {
            ServiceChanged?.Invoke(sender, args);
        }
        #endregion
    }
}
