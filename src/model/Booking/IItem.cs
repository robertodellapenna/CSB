using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Booking
{
    public interface IItem
    {
        /// <summary>
        /// Nome dell'oggetto
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Descrizione generale dell'oggetto
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Prezzo giornaliero dell'oggetto
        /// </summary>
        double BaseDailyPrice { get; }
    }
}
