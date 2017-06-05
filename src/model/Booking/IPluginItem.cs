using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Booking
{
    public interface IPluginItem
    {
        /// <summary>
        /// Check sulla compatibilità del plugin Item con il Base Item
        /// </summary>
        /// <param name="baseItem">un IBaseItem</param>
        /// <returns>true se è compatibile, false in caso contrario</returns>
        bool IsAssociableWith(IBaseItem baseItem);
        /// <summary>
        /// Limite massimo di associabilità al BaseItem da parte del PluginItem 
        /// </summary>
        /// <param name="baseItem">BaseItem a cui il PluginItem è associabile</param>
        /// <returns>numero massimo</returns>
        int GetMaxQuantity(IBaseItem baseItem);
        /// <summary>
        /// Ottiene la lista dei IBaseItem a cui il plugin Item è associabile
        /// </summary>
        /// <returns>Collezione di IBaseItem</returns>
        IEnumerable<IBaseItem> getCompatibleItems();
    }
}
