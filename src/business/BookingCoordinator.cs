using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Structure;
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
    }

    public class BookingCoordinator : AbstractCoordinatorDecorator, IBookingCoordinator
    {
        #region Eventi
        #endregion

        #region Campi
        private readonly IEnumerable<IBookableItem> _bookableItems;
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

            /* Structures HardCoded */
            
        }
        public void AddBookableItem(IBookableItem bookableItem)
        {
            #region Precondizioni
            if (bookableItem == null)
                throw new ArgumentNullException("bookable item null");
            #endregion
            if(!_bookableItems.Contains(bookableItem))
                (_bookableItems as List<IBookableItem>).Add(bookableItem);
        }
        public IEnumerable<IBookableItem> Filter(Structure structure)
        {
            #region Precondizioni
            if (structure == null)
                throw new ArgumentNullException("area null");
            #endregion
            return _bookableItems.Where(item => structure.Areas.Where(area => area.Sectors.Contains(item.Sector)).Any());
        }
        public IEnumerable<IBookableItem> Filter(StructureArea area)
        {
            #region Precondizioni
            if (area == null)
                throw new ArgumentNullException("area null");
            #endregion
            return _bookableItems.Where(item => area.Sectors.Contains(item.Sector));
        }
        public IEnumerable<IBookableItem> Filter(Sector sector)
        {
            #region Precondizioni
            if (sector == null)
                throw new ArgumentNullException("area null");
            #endregion
            return _bookableItems.Where(item => item.Sector == sector);
        }
        #endregion


        #region Handler
        #endregion
    }
}
