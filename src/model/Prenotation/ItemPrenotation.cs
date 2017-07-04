
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Utils;
using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Item;

namespace CSB_Project.src.model.Prenotation
{
    public class ItemPrenotation
    {
        #region Eventi
        #endregion
        #region Campi
        private readonly DateRange _rangeData;
        private readonly IBookableItem _bookableItem;
        private readonly IDictionary<IItem, IEnumerable<DateRange>> _pluginsAssociation;
        #endregion
        #region Proprieta
        public DateRange RangeData => _rangeData; 
        public IBookableItem BookableItem => _bookableItem;
        public IEnumerable<IItem> Plugins => _pluginsAssociation.Keys.ToArray();
        public IEnumerable<KeyValuePair<IItem, IEnumerable<DateRange>>> PluginsAssociation
        {
            get
            {
                KeyValuePair<IItem, IEnumerable<DateRange>>[] copy = new KeyValuePair<IItem, IEnumerable<DateRange>>[_pluginsAssociation.Count];
                _pluginsAssociation.CopyTo(copy, 0);
                return copy;
            }
        }
        public double Price {
            get
            {
                double price= BookableItem.DailyPrice * RangeData.Days;
                foreach (IItem plugin in _pluginsAssociation.Keys)
                    foreach (DateRange dr in _pluginsAssociation[plugin])
                        price += (plugin.DailyPrice * dr.Days);
                return price;
            }
        }
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
            _pluginsAssociation = new Dictionary<IItem, IEnumerable<DateRange>>();
        }

        public ItemPrenotation(DateRange rangeData, IBookableItem bookableItem, IDictionary<IItem, IEnumerable<DateRange>> pluginsAssociation) : this(rangeData, bookableItem)
        {
            #region Precondizioni
            if (pluginsAssociation == null)
                throw new ArgumentNullException("pluginsAssociation null");
            #endregion

            _pluginsAssociation = pluginsAssociation;
        }

        #endregion
        #region Metodi
        public void addPlugin(IItem item, DateRange dateRange)
        {
            #region Precondizioni
            if (item == null)
                throw new ArgumentNullException("item null");
            if (dateRange == null)
                throw new ArgumentNullException("dateRange null");
            if (!_rangeData.Contains(dateRange))
                throw new Exception("date range not valid");
            #endregion 
            if (!_pluginsAssociation.ContainsKey(item))
            { 
                _pluginsAssociation.Add(item, new List<DateRange>());
            }
            (_pluginsAssociation[item] as List<DateRange>).Add(dateRange);
            
        }
        #endregion
        #region Handler
        #endregion
    }
}
