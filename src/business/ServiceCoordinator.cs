using System;
using System.Collections.Generic;
using CSB_Project.src.model;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Services;

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
        IEnumerable<IUsage> Usage { get; }
        void AddUsage (IUsage usage);
        event EventHandler ServiceChanged;
    }
    class ServiceCoordinator : AbstractCoordinator, IServiceCoordinator
    {
        #region Eventi
        #endregion
        #region Campi
        private readonly List<IBundle> _bundles;
        private readonly List<IPacket> _packets;
        private readonly List<IUsable> _services;
        private readonly List<IUsage> _usages;
        #endregion
        #region Proprieta
        #endregion
        #region Costruttori
        #endregion
        #region Metodi
        #endregion
        #region Handler
        #endregion
    }
}
