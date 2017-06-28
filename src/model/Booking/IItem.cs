using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Booking
{
    public interface IItem
    {

        string Name { get; }

        string Description { get; }

        double BaseDailyPrice { get; }

    }
}
