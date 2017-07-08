
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Utils;
using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Item;
using System.Collections.ObjectModel;

namespace CSB_Project.src.model.Prenotation
{
    public class CustomizableItemPrenotation : ICustomizableItemPrenotation
    {
        #region Campi
        private readonly DateRange _rangeData;
        private readonly IBookableItem _baseItem;
        private readonly IDictionary<IItem, IEnumerable<DateRange>> _pluginsAssociation;
        #endregion
        #region Proprieta
        public DateRange RangeData => _rangeData; 
        public IBookableItem BaseItem => _baseItem;
        public ReadOnlyCollection<IItem> Plugins 
            => new ReadOnlyCollection<IItem>(_pluginsAssociation.Keys.ToList());

        public ReadOnlyCollection<KeyValuePair<IItem, IEnumerable<DateRange>>> PluginsAssociation
            => new ReadOnlyCollection<KeyValuePair<IItem, IEnumerable<DateRange>>>(_pluginsAssociation.ToList());
        
        public double Price {
            get
            {
                double price = BaseItem.DailyPrice * RangeData.Days;
                foreach (IItem plugin in _pluginsAssociation.Keys)
                    foreach (DateRange dr in _pluginsAssociation[plugin])
                        price += (plugin.DailyPrice * dr.Days);
                return price;
            }
        }
        #endregion
        #region Costruttori
        public CustomizableItemPrenotation(DateRange rangeData, IBookableItem bookableItem)
        {
            #region Precondizioni
            if (rangeData == null)
                throw new ArgumentNullException("range data null");
            if (bookableItem == null)
                throw new ArgumentNullException("bookable item null");
            #endregion

            _rangeData = rangeData;
            _baseItem = bookableItem;
            _pluginsAssociation = new Dictionary<IItem, IEnumerable<DateRange>>();
        }

        public CustomizableItemPrenotation(DateRange rangeData, IBookableItem bookableItem, IDictionary<IItem, IEnumerable<DateRange>> pluginsAssociation) : this(rangeData, bookableItem)
        {
            #region Precondizioni
            if (pluginsAssociation == null)
                throw new ArgumentNullException("pluginsAssociation null");
            #endregion

            _pluginsAssociation = pluginsAssociation;
        }

        #endregion
        #region Metodi
        public void AddPlugin(IItem item, DateRange dateRange)
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
    }
}
