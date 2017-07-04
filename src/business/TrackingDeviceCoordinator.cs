using CSB_Project.src.model.Prenotation;
using CSB_Project.src.model.TrackingDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.business
{
    public interface ITrackingDeviceCoordinator : ICoordinator
    {
        
    }

    public class TrackingDeviceCoordinator : AbstractCoordinatorDecorator, ITrackingDeviceCoordinator
    {
        #region Eventi
        #endregion

        #region Campi
        private IEnumerable<ITrackingDevice> _notAvailables;
        private IEnumerable<ITrackingDevice> _availables;
        private Dictionary<ITrackingDevice, Prenotation> _booked;
        #endregion

        #region Proprietà
        public ITrackingDevice Next => (_availables as Queue<ITrackingDevice>).Dequeue(); 
        #endregion

        #region Costruttori
        public TrackingDeviceCoordinator(ICoordinator next) : base(next)
        {
            _availables = new Queue<ITrackingDevice>();
            _notAvailables = new List<ITrackingDevice>();
            _booked = new Dictionary<ITrackingDevice, Prenotation>();
        }
        #endregion

        #region Metodi
        protected override void init()
        {
            /* Cerco un file di configurazione dei tracking devices nel fileSystem,
             * se lo trovo carico i tracking devices contenuti 
             */
             
            /* Tracking Devices HardCoded */
            ITrackingDevice trackingDevice = new MagneticCard(101);
            (_availables as Queue<ITrackingDevice>).Enqueue(trackingDevice);
            trackingDevice = new MagneticCard(102);
            (_availables as Queue<ITrackingDevice>).Enqueue(trackingDevice);
            trackingDevice = new SimpleCard(101);
            (_availables as Queue<ITrackingDevice>).Enqueue(trackingDevice);
        }
        #endregion 
        #region Handler
        #endregion
    }
}
