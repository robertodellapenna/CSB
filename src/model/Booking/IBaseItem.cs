using CSB_Project.src.model.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Booking
{
    public interface IBaseItem
    {
        /// <summary>
        /// Nome dell'Item
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Prezzo giornaliero dell'item
        /// </summary>
        /// <returns>prezzo</returns>
        double getDailyPrice();
    }
}
