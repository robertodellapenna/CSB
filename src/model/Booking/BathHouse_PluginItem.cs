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
        /// <summary>
        /// mantiene il riferimento ai IBaseItem compatibili in un campo privato, non specificato nell'interfaccia
        /// </summary>
        private readonly List<IBaseItem> _compatibleItems;

        #endregion

        #region Proprietà

        internal List<IBaseItem> CompatibleItems => _compatibleItems;

        #endregion

        #region Costruttori

        public BathHouse_PluginItem(string name, double baseDailyPrice) : base(name, baseDailyPrice){}

        #endregion

        #region Metodi

        public bool IsAssociableWith(IBaseItem baseItem)
        {
            if (baseItem == null)
                throw new ArgumentException("baseItem null");
            //un plugin item non può essere associato ad un plugin item
            if (baseItem is IPluginItem)
                throw new ArgumentException("baseItem is a PluginItem");
            return _compatibleItems.Contains(baseItem);
        }

        public IEnumerable<IBaseItem> getCompatibleItems() => CompatibleItems;
        #endregion

        #region Handler
        #endregion

    }
}
