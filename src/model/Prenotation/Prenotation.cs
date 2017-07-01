using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Users;
using CSB_Project.src.model.Utils;
using CSB_Project.src.model.TrackingDevice;

namespace CSB_Project.src.model.Prenotation
{
    public class Prenotation
    {

        #region Eventi
        #endregion
        #region Campi
        private readonly int _id;
        private readonly Client _client;
        private readonly CardsAssociations _cardsAssociations;
        private readonly DateRange _rangeData;
        private readonly List<ItemPrenotation> _items;
        #endregion
        #region Proprieta
    
        public Client Client => _client;
        public DateRange RangeData => _rangeData;
        public int Id => _id;
        public  List<ItemPrenotation> Items  => _items;
        public CardsAssociations CardsAssociations => _cardsAssociations;

        #endregion
        #region Costruttori
        public Prenotation(int id, Client client, DateRange rangeData, List<ItemPrenotation> items)
        {
            if (id < 0)
                throw new ArgumentException("id is not valid");
            _client = client ?? throw new ArgumentException("client is not defined");
            _rangeData = rangeData ?? throw new ArgumentException("range Data is not defined");
            _items = items ?? throw new ArgumentException("items is not defined");
            if (!IsAValidPrenotation())
                throw new ArgumentException("Data Range of Items do not satisfy data range of prenotation");
        }

        #endregion
        #region Metodi
        public bool AddItem(ItemPrenotation item)
        {
            if (item != null && RangeData.Contains(item.RangeData))
            {
                Items.Add(item);
                return true;
            }
            else
                return false;
        }

        public float GetCurrentPriece()
        {
            return 0;
        }

        public bool IsAValidPrenotation()
        {
            return true;
        }

        public float Bill()
        {
            return 0;
        }
        #endregion
        #region Handler
        #endregion


    }
}
