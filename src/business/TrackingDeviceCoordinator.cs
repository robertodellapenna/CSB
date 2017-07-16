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
        void LockTrackingDevice(IServizablePrenotation prenotation);
        void RemoveTrackingDevice(ITrackingDevice td);
        void AddTrackingDevice(ITrackingDevice td);
    }

    public class TrackingDeviceCoordinator : AbstractCoordinatorDecorator, ITrackingDeviceCoordinator
    {
        #region Eventi
        #endregion

        #region Campi
        private ISet<ITrackingDevice> _notAvailables = new HashSet<ITrackingDevice>();
        private Queue<ITrackingDevice> _availables = new Queue<ITrackingDevice>();
        private Dictionary<ITrackingDevice, IServizablePrenotation> _booked = new Dictionary<ITrackingDevice, IServizablePrenotation>();
        #endregion

        #region Proprietà
        public ITrackingDevice Next => _availables.Peek(); 
        #endregion

        #region Costruttori
        public TrackingDeviceCoordinator(ICoordinator next) : base(next)
        {
        }
        #endregion

        #region Metodi
        protected override void Init()
        {
            base.Init();
            /* Cerco un file di configurazione dei tracking devices nel fileSystem,
             * se lo trovo carico i tracking devices contenuti 
             */
             
            /* Tracking Devices HardCoded */
            ITrackingDevice trackingDevice = new MagneticCard(101);
            AddTrackingDevice(trackingDevice);
            trackingDevice = new MagneticCard(102);
            AddTrackingDevice(trackingDevice);
            trackingDevice = new SimpleCard(101);
            AddTrackingDevice(trackingDevice);
        }

        public void AddTrackingDevice(ITrackingDevice td)
        {
            #region Precondizioni
            if (td == null)
                throw new ArgumentNullException("td null");
            if (_availables.Contains(td))
                throw new InvalidOperationException("td è già presente nel sistema");
            if (_booked.Keys.Contains(td))
                throw new InvalidOperationException("td è già presente nel sistema");
            if (_notAvailables.Contains(td))
                throw new InvalidOperationException("td è già presente nel sistema");
            #endregion
            _availables.Enqueue(td);
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

        public void LockTrackingDevice(IServizablePrenotation prenotation)
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
