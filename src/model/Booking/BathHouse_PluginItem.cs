using CSP_Project.src.model.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Category;

namespace CSB_Project.src.model.Booking
{
    class BathHouse_PluginItem : BathHouse_BaseItem, IPluginItem
    {
        #region Eventi
        #endregion

        #region Campi
        #endregion

        #region Proprietà
        private readonly Compatibilities _compatibilities;
        #endregion

        #region Costruttori

        public BathHouse_PluginItem(string name, double baseDailyPrice) : base(name, baseDailyPrice)
        {
            _compatibilities = Compatibilities.Instance;
        }

        #endregion

        #region Metodi

        public bool IsAssociableWith(IBaseItem baseItem)
        {
            if (baseItem == null)
                throw new ArgumentException("baseItem null");
            //un plugin item non può essere associato ad un plugin item
            if (baseItem is IPluginItem)
                throw new ArgumentException("baseItem is a PluginItem");
            return _compatibilities.CheckCompatibility(baseItem, this);
        }

        public IEnumerable<IBaseItem> getCompatibleItems() => _compatibilities.GetAllCompatibleBaseItems(this);


        #endregion

        #region Handler
        #endregion

    }
}
