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
        private readonly StructureArea _area;
        private readonly Position _position;
        private readonly Sector _sector;
        #endregion

        #region Proprietà
        public IItem BaseItem => _baseItem;
        public StructureArea Area => _area;
        public Position Position => _position;
        public Sector Sector => _sector;
        #endregion

        #region Costruttori
        public SectorBookableItem(IItem baseItem, StructureArea area, Position position, Sector sector)
        {
            #region Precondizioni
            if (baseItem == null)
                throw new ArgumentException("baseItem null");
            if (area == null)
                throw new ArgumentException("area null");
            if (sector == null)
                throw new ArgumentException("sector null");
            #endregion
            _baseItem = baseItem;
            _area = area;
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
