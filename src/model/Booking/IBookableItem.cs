using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Booking
{
    interface IBookableItem
    {
        string Name { get; }
        ICollection<Property> Properties  { get; }
        double BaseDailyPrice { get; }
        double DailyPrice { get; }
    }
}
