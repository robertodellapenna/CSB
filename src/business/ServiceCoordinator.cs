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
        IEnumerable<IUsage> Filter(ITrackingDevice card);
        event EventHandler ServiceChanged;
    }
    public class ServiceCoordinator : AbstractCoordinator, IServiceCoordinator
    {
        #region Eventi
        public event EventHandler ServiceChanged;
        #endregion
        #region Campi
        private readonly List<IBundle> _bundles;
        private readonly List<IPacket> _packets;
        private readonly List<IUsable> _services;
        private readonly List<IUsage> _usages;
        #endregion
        #region Proprieta
        public IEnumerable<IBundle> Bundles => _bundles.ToArray();
        public IEnumerable<IPacket> Packets => _packets.ToArray();
        public IEnumerable<IUsable> Services => _services.ToArray();
        public IEnumerable<IUsage> Usages => _usages.ToArray();

        #endregion
        #region Costruttori
        #endregion
        #region Metodi
        public void AddBundle(IBundle bundle)
        {
            #region Precondizioni
            if (bundle == null)
                throw new ArgumentNullException("bundle null");
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
            if (!_packets.Contains(packet))
                _packets.Add(packet);
        }

        public void AddService(IUsable service)
        {
            #region Precondizioni
            if (service == null)
                throw new ArgumentNullException("service null");
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

        #endregion
        #region Handler
        private void OnServiceChanged(Object sender, EventArgs args)
        {
            ServiceChanged?.Invoke(sender, args);
        }

        public IEnumerable<IUsage> Filter(ITrackingDevice card)
        {

            return _usages.Where(usage => usage.Who.Id == card.Id);
        }

        public IEnumerable<IPacket> Filter(DateRange data)
        {
            return _packets.Where(packet => packet.Availability.Contains(data));
        }

        public IEnumerable<IBundle> FilterBundle(DateRange data)
        {
            return _bundles.Where(bundle => bundle.Availability.Contains(data));
        }
        #endregion
    }
}
