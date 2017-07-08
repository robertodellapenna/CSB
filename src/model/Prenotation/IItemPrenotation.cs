using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Item;
using CSB_Project.src.model.Utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CSB_Project.src.model.Prenotation
{
    public interface IItemPrenotation
    {
        DateRange RangeData { get; }
        IBookableItem BaseItem { get; }
        double Price { get; }
    }

    public interface ICustomizableItemPrenotation : IItemPrenotation
    {
        ReadOnlyCollection<IItem> Plugins { get; }
        ReadOnlyCollection<KeyValuePair<IItem, IEnumerable<DateRange>>> PluginsAssociation { get; }
        void AddPlugin(IItem item, DateRange dateRange);
    }
}