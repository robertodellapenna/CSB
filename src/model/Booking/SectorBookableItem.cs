using CSB_Project.src.model.Item;
using CSB_Project.src.model.Structure;
using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Booking
{
    public class SectorBookableItem : IBookableItem
    {
        #region Eventi
        #endregion

        #region Campi
        private readonly IItem _baseItem;
        private readonly Position _position;
        private readonly Sector _sector;
        #endregion

        #region Proprietà
        public IItem BaseItem => _baseItem;
        public Position Position => _position;
        public Sector Sector => _sector;
        public double DailyPrice => _baseItem.DailyPrice + _sector.ItemPriceIncrease;
        #endregion

        #region Costruttori
        public SectorBookableItem(IItem baseItem, Position position, Sector sector)
        {
            #region Precondizioni
            if (baseItem == null)
                throw new ArgumentException("baseItem null");
            if (sector == null)
                throw new ArgumentException("sector null");
            if(position.Row > sector.Rows || position.Column > sector.Columns)
                throw new Exception("position not valid in this sector");
            #endregion
            _baseItem = baseItem;
            _position = position;
            _sector = sector;
        }

        #endregion

        #region Metodi

        #endregion

        #region Handler
        #endregion
    }
}
