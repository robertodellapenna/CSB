using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Category;
using CSB_Project.src.model.Prenotation;
using CSB_Project.src.model.Utils;
using CSB_Project.src.presentation.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Item
{
    public interface IItem
    {
        /// <summary>
        /// Identificatore dell'oggetto
        /// </summary>
        string Identifier { get; }

        string FriendlyName { get; }

        /// <summary>
        /// Descrizione generale dell'oggetto
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Prezzo base giornaliero dell'oggetto
        /// </summary>
        double BaseDailyPrice { get; }

        /// <summary>
        /// Prezzo comprensivo di caratteristiche aggiuntive
        /// </summary>
        double DailyPrice { get; }

        string InformationString { get; }

        void Accept(IPrenotationVisitor visitor);
    }

    public interface ICategorizableItem : IItem
    {
        IEnumerable<ICategory> Categories { get; }
        ReadOnlyCollection<KeyValuePair<ICategory, PriceDescriptor>> Properties { get; }

        bool ContainsSubCateogryOf(IGroupCategory category);
        bool ContainsCategory(ICategory category);
        string GetNameOf(ICategory category);
        string GetDescriptionOf(ICategory category);
        double GetPriceOf(ICategory category);
    }
}
