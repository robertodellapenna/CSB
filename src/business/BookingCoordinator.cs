using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Item;
using CSB_Project.src.model.Structure;
using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.business
{
    public interface IBookingCoordinator : ICoordinator
    {
        IEnumerable<IBookableItem> BookableItems { get; }
        IEnumerable<IBookableItem> Filter(Structure structure);
        IEnumerable<IBookableItem> Filter(StructureArea area);
        IEnumerable<IBookableItem> Filter(Sector sector);
        void AddBookableItem(IBookableItem item);
        event EventHandler BookingChanged;
    }

    public class BookingCoordinator : AbstractCoordinatorDecorator, IBookingCoordinator
    {
        #region Eventi
        public event EventHandler BookingChanged;
        #endregion

        #region Campi
        private readonly List<IBookableItem> _bookableItems;
        #endregion

        #region Proprietà
        public IEnumerable<IBookableItem> BookableItems => _bookableItems.ToArray();
        #endregion

        #region Costruttori
        public BookingCoordinator(ICoordinator next) : base(next)
        {
            _bookableItems = new List<IBookableItem>();
        }

        #endregion

        #region Metodi
        protected override void init()
        {
            base.init();
            /* Cerco un file di configurazione dei bookable items nel fileSystem,
             * se lo trovo carico i bookable items  contenuti
             */

            /* Bookable Items HardCoded */
            ItemCoordinator itemCoord = CoordinatorManager.Instance.CoordinatorOfType<ItemCoordinator>();
            IItem ombrelloneBase = itemCoord.baseItems.Where(item => item.Identifier.Equals("Ombrellone001")).FirstOrDefault();
            IItem ombrellonePaglia = itemCoord.baseItems.Where(item => item.Identifier.Equals("Ombrellone101")).FirstOrDefault();

            StructureCoordinator structCoord = CoordinatorManager.Instance.CoordinatorOfType<StructureCoordinator>();
            Sector settoreBase = structCoord.GetSectorIn("Stabilimento Bologna Via Mario Longhena", "Spiaggia", "Settore base");
            Sector settoreVip= structCoord.GetSectorIn("Stabilimento Bologna Via Mario Longhena", "Spiaggia", "Settore vip");

            for(int row=0; row<settoreBase.Rows; row++)
                for(int col=0; col<settoreBase.Columns; col++)
                {
                    IBookableItem item = new SectorBookableItem(ombrelloneBase, new Position(row, col), settoreBase);
                    _bookableItems.Add(item);
                }
            for (int row = 0; row < settoreVip.Rows; row++)
                for (int col = 0; col < settoreVip.Columns; col++)
                {
                    IBookableItem item = new SectorBookableItem(ombrellonePaglia, new Position(row, col), settoreVip);
                    _bookableItems.Add(item);
                }
        }
        public void AddBookableItem(IBookableItem bookableItem)
        {
            #region Precondizioni
            if (bookableItem == null)
                throw new ArgumentNullException("bookable item null");
            foreach (IBookableItem item in Filter(bookableItem.Sector))
                if (item.Position.Row==bookableItem.Position.Row &&
                    item.Position.Column==bookableItem.Position.Column)
                    throw new Exception("position not available");
            #endregion
            (_bookableItems as List<IBookableItem>).Add(bookableItem);
        }
        public IEnumerable<IBookableItem> Filter(Structure structure)
        {
            #region Precondizioni
            if (structure == null)
                throw new ArgumentNullException("area null");
            #endregion
            return _bookableItems.Where(item => structure.Areas.Where(area => area.Sectors.Contains(item.Sector)).Any()).ToArray();
        }
        public IEnumerable<IBookableItem> Filter(StructureArea area)
        {
            #region Precondizioni
            if (area == null)
                throw new ArgumentNullException("area null");
            #endregion
            return _bookableItems.Where(item => area.Sectors.Contains(item.Sector)).ToArray();
        }
        public IEnumerable<IBookableItem> Filter(Sector sector)
        {
            #region Precondizioni
            if (sector == null)
                throw new ArgumentNullException("area null");
            #endregion
            return _bookableItems.Where(item => item.Sector == sector).ToArray();
        }
        #endregion


        #region Handler
        private void OnBookingChanged(Object sender, EventArgs args)
        {
            BookingChanged?.Invoke(sender, args);
        }
        #endregion
    }
}
