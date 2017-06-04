using CSB_Project.src.model.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Booking
{
    interface IBaseItem
    {
        /// <summary>
        /// Nome dell'Item
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Prezzo base dell'Item
        /// </summary>
        double BaseDailyPrice { get; }
    }
}
