using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Booking
{
    interface IBookableItem
    {
        IBaseItem BaseItem { get; }
        IEnumerable<IPluginItem> GetPluginItems();
        void AddPluginItem(IPluginItem pluginItem, DateRange dataRange);
        int getQuantityOf(IPluginItem pluginItem);
        DateRange getDateRangeOf(IPluginItem pluginItem);
    }
}
