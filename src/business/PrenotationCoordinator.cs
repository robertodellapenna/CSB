using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Prenotation;
using CSB_Project.src.model.Structure;
using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.business
{
    public interface IPrenotatiionCoordinator : ICoordinator
    {
        IEnumerable<Prenotation> Prenotations { get; }
        void AddPrenotation(Prenotation prenotation);
        void AddItemPrenotation(int idPrenotation, ItemPrenotation itemPrenotation);
        IEnumerable<Position> BusyPositions(Sector sector, DateRange rangeData);
        bool IsAvailable(Sector sector,Position position, DateRange rangeData);
        bool CanAdd(ItemPrenotation itemPrenotation);
        bool CanAdd(Prenotation prenotation);
        event EventHandler PrenotationChanged;
    }

    class PrenotationCoordinator : AbstractCoordinatorDecorator, IPrenotatiionCoordinator
    {
        #region Eventi
        public event EventHandler PrenotationChanged;
        #endregion

        #region Campi
        private readonly List<Prenotation> _prenotations = new List<Prenotation>();
        #endregion

        #region Proprietà
        public IEnumerable<Prenotation> Prenotations
        {

            get
            {
                Prenotation[] copy = new Prenotation[_prenotations.Count];
                _prenotations.CopyTo(copy);
                return copy;
            }
        }
        
        #endregion

        #region Costruttori
        public PrenotationCoordinator(ICoordinator next) : base(next)
        {
        }

        #endregion

        #region Metodi
        protected override void init()
        {
            base.init();
            /* Cerco un file di configurazione delle prenotation nel fileSystem,
             * se lo trovo carico le prenotation contenute
             */

            /* Prenotations HardCoded */
            
        }

        public void AddPrenotation(Prenotation prenotation)
        {
            #region Precondizioni
            if (prenotation == null)
                throw new ArgumentNullException("prenotation null");
            if (!CanAdd(prenotation))
                throw new Exception("prenotation not valid");
            #endregion
            _prenotations.Add(prenotation);
        }
        public void AddItemPrenotation(int idPrenotation, ItemPrenotation itemPrenotation)
        {
            #region Precondizioni
            if (idPrenotation < 0)
                throw new ArgumentException("id not valid");
            if (itemPrenotation == null)
                throw new ArgumentNullException("item prenotation null");
            if (GetPrenotation(idPrenotation)==null)
                throw new Exception("prenotation not found");
            if(!CanAdd(itemPrenotation))
                throw new Exception("item prenotation not valid");
            #endregion
            GetPrenotation(idPrenotation).AddItem(itemPrenotation);
        }
        public IEnumerable<Position> BusyPositions(Sector sector, DateRange rangeData)
        {
            #region Precondizioni
            if (sector == null)
                throw new ArgumentNullException("sector null");
            if (rangeData == null)
                throw new ArgumentNullException("rangeData null");
            #endregion
            return (from item in BookedItems(rangeData)
                    where item.Sector == sector
                    select item.Position);
        }
        public bool IsAvailable(Sector sector, Position position, DateRange rangeData)
        {
            #region Precondizioni
            if (sector == null)
                throw new ArgumentNullException("sector null");
            if (position == null)
                throw new ArgumentNullException("sector null");
            if (rangeData == null)
                throw new ArgumentNullException("rangeData null");
            if (position.Row > sector.Rows || position.Column > sector.Columns)
                throw new Exception("invalid position for this sector");
            #endregion
            return !BusyPositions(sector, rangeData).Where(pos => pos.Row == position.Row &&
                                                                 pos.Column == position.Column).Any();
        }
        public bool CanAdd(ItemPrenotation itemPrenotation)
        {
            #region Precondizioni
            if (itemPrenotation == null)
                throw new ArgumentNullException("item prenotation null");
            #endregion
            return _prenotations.Where(
                prenotation => prenotation.Items.Where(
                    item => item.BookableItem.Sector == itemPrenotation.BookableItem.Sector &&
                            item.BookableItem.Position.Row == itemPrenotation.BookableItem.Position.Row &&
                            item.BookableItem.Position.Column == itemPrenotation.BookableItem.Position.Column &&
                            item.RangeData.OverlapWith(itemPrenotation.RangeData)
                ).Any()
            ).Any();
        }
        public bool CanAdd(Prenotation prenotation)
        {
            #region Precondizioni
            if (prenotation == null)
                throw new ArgumentNullException("prenotation null");
            #endregion
            foreach (ItemPrenotation item in prenotation.Items)
                if (!CanAdd(item)) return false;
            return true;
        }
        private IEnumerable<IBookableItem> BookedItems(DateRange rangeData)
        {
            #region Precondizioni
            if (rangeData == null)
                throw new ArgumentNullException("rangeData null");
            #endregion
            List<IBookableItem> result = new List<IBookableItem>();
            foreach (Prenotation p in _prenotations)
                foreach (ItemPrenotation item in p.Items)
                    if (item.RangeData.OverlapWith(rangeData))
                        result.Add(item.BookableItem);
            return result;
        }
        private Prenotation GetPrenotation(int idPrenotation)
        {
            #region Precondizioni
            if (idPrenotation < 0)
                throw new ArgumentException("id not valid");
            #endregion
            if (!_prenotations.Where(prenotation => prenotation.Id == idPrenotation).Any())
                return null;
            return _prenotations.Where(prenotation => prenotation.Id == idPrenotation).ElementAt(0);
        }
        #endregion

        #region Handler
        private void OnStructureChanged(Object sender, EventArgs args)
        {
            PrenotationChanged?.Invoke(sender, args);
        }
        #endregion
    }
}
