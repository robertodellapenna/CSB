using CSB_Project.src.model.Prenotation;
using CSB_Project.src.model.TrackingDevice;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSB_Project.src.business
{
    public interface ITrackingDeviceCoordinator : ICoordinator
    {
        ITrackingDevice Next { get; }
        void ReleaseTrackingDevice(ITrackingDevice td);
        void LockTrackingDevice(IPrenotation prenotation);
        void RemoveTrackingDevice(ITrackingDevice td);
    }

    public class TrackingDeviceCoordinator : AbstractCoordinatorDecorator, ITrackingDeviceCoordinator
    {
        #region Eventi
        #endregion

        #region Campi
        private ISet<ITrackingDevice> _notAvailables;
        private Queue<ITrackingDevice> _availables;
        private Dictionary<ITrackingDevice, IPrenotation> _booked;
        #endregion

        #region Proprietà
        public ITrackingDevice Next => _availables.Peek(); 
        #endregion

        #region Costruttori
        public TrackingDeviceCoordinator(ICoordinator next) : base(next)
        {
            _availables = new Queue<ITrackingDevice>();
            _notAvailables = new HashSet<ITrackingDevice>();
            _booked = new Dictionary<ITrackingDevice, IPrenotation>();
        }
        #endregion

        #region Metodi
        protected override void init()
        {
            base.init();
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

        public void ReleaseTrackingDevice(ITrackingDevice td)
        {
            #region Precondizioni.
            if (td == null)
                throw new ArgumentNullException("td null");
            if (_availables.Contains(td))
                throw new InvalidOperationException("Il device è già disponibile all'uso");
            if (!_booked.ContainsKey(td))
                throw new InvalidOperationException("Il device non è associata a nessuna prenotazione");
            #endregion
            _booked.Remove(td);
            _availables.Enqueue(td);
        }

        public void LockTrackingDevice(IPrenotation prenotation)
        {
            #region Precondizioni
            if (prenotation == null)
                throw new ArgumentNullException("prenotation null");
            if (!prenotation.TrackingDevices.Contains(Next))
                throw new InvalidOperationException("Stai cercando di registrare "+
                    "il prossimo tracking device ad una prenotazione che non include il tracking device");
            if (_booked.ContainsKey(_availables.Peek()))
                throw new InvalidOperationException("Il tracking device è già registrata e allo stesso tempo disponibile");
            #endregion
            _booked.Add(_availables.Dequeue(), prenotation);
        }

        public void RemoveTrackingDevice(ITrackingDevice badTd)
        {
            #region Precondizioni
            if (!_availables.Contains(badTd))
                throw new InvalidOperationException("Il tracking device non è presente nella coda delle disponibili");
            if (_notAvailables.Contains(badTd))
                throw new InvalidOperationException("Il tracking device è già stato rimosso");
            #endregion
            IEnumerable<ITrackingDevice> goodTd = from currentTd in _availables
                                                  where currentTd != badTd
                                                  select currentTd;

            _availables = new Queue<ITrackingDevice>(goodTd);
            _notAvailables.Add(badTd);
        }
        #endregion 

        #region Handler
        #endregion
    }
}
