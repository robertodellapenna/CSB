using System;
using System.Collections.Generic;
using CSB_Project.src.model;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Services;
using CSB_Project.src.model.Utils;
using CSB_Project.src.model.TrackingDevice;
using CSB_Project.src.model.Prenotation;

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
        void RemoveService(IUsable service);
        IEnumerable<IUsage> Usages { get; }
        void AddUsage (IUsage usage);
        IEnumerable<IUsage> FilterCard(ITrackingDevice card);
        IEnumerable<IPacket> FilterPacketName(string name);
        IEnumerable<IBundle> FilterBundleName(string name);
        IEnumerable<IUsable> FilterServiceName(string name);
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
            IUsable service1 = new BasicService(new DatePriceDescriptor("Massaggio", "Massaggio sotto l'ombrellone", date1, 5.0));
            IUsable service2 = new BasicService(new DatePriceDescriptor("Piscina termale 1h", "Accesso alla piscina termale per 1 ora", date2, 6.0));
            IUsable service3 = new BasicService(new DatePriceDescriptor("Happy aperitivo", "Accesso alla zona happy aperitivo", date2, 4.0));
            IUsable service4 = new BasicService(new DatePriceDescriptor("Doccia calda", "Accesso alla doccia calda", new DateRange(15), 0.5));
            _services.Add(service1);
            _services.Add(service2);
            _services.Add(service3);
            _services.Add(service4);

            IPacket packet1 = new TicketPacket((new DatePriceDescriptor("Piscina termale x10", "Ticket per l'accesso alla piscina termale", date1, 48.0)), service2, 10);
            IPacket packet2 = new TicketPacket((new DatePriceDescriptor("Massaggio x3", "include 3 massaggi al prezzo di 2", date1, 10)), service1, 3);
            IPacket packet3 = new DateRangePacket((new DatePriceDescriptor("Doccia calda", "accesso alla doccia calsa", date1, 5)), service4, 15);
            _packets.Add(packet1);
            _packets.Add(packet2);
            _packets.Add(packet3);

            ISet<IPacket> bundleSet = new HashSet<IPacket>();
            bundleSet.Add(packet2);
            bundleSet.Add(packet3);

            IBundle bundle1 = new Bundle(bundleSet, new DatePriceDescriptor("Welcome Pack", "Bundle di benvenuto ", date1, 12));
            _bundles.Add(bundle1);
            IUsage usage1 = new UsageService(new DateTime(2017, 7, 16), new SimpleCard(1), service1);
            IUsage usage2 = new UsageService(new DateTime(2017, 7, 16), new SimpleCard(2), service2);
            IUsage usage3 = new UsageService(new DateTime(2017, 7, 16), new SimpleCard(1), service2);
            IPrenotationCoordinator prenotationCoordinator = CoordinatorManager.Instance.CoordinatorOfType<IPrenotationCoordinator>();
            _usages.Add(usage1);
            _usages.Add(usage2);
            _usages.Add(usage3);
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

        public void RemoveService(IUsable service)
        {
            #region Precondizioni
            if (service == null)
                throw new ArgumentNullException("service null");
            #endregion
            if (_services.Contains(service))
                _services.Remove(service);

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

        public IEnumerable<IUsable> FilterServiceName(string name)
        {
            return _services.Where(service => service.Name.Equals(name));
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
