using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Utils;
using CSB_Project.src.model.Booking;

namespace CSB_Project.src.model.Prenotation
{
    public class ItemPrenotation
    {
        #region Eventi
        #endregion
        #region Campi
        private readonly DateRange _rangeData;
        private readonly IBookableItem _bookableItem;
        private readonly Plugins _plugins;
        #endregion
        #region Proprieta
        public DateRange RangeData => _rangeData; 
        public IBookableItem BookableItem => _bookableItem;
        public Plugins Plugins => _plugins;
        #endregion
        #region Costruttori
        public ItemPrenotation(DateRange rangeData, IBookableItem bookableItem)
        {
            #region Precondizioni
            if (rangeData == null)
                throw new ArgumentNullException("range data null");
            if (bookableItem == null)
                throw new ArgumentNullException("bookable item null");
            #endregion

            _rangeData = rangeData;
            _bookableItem = bookableItem;
            _plugins = new Plugins();
        }

        public ItemPrenotation(DateRange rangeData, IBookableItem bookableItem, Plugins plugins) : this(rangeData, bookableItem)
        {
            #region Precondizioni
            if (plugins == null)
                throw new ArgumentNullException("plugins null");
            #endregion

            _plugins = plugins;
        }

        #endregion
        #region Metodi
        #endregion
        #region Handler
        #endregion
    }
}
