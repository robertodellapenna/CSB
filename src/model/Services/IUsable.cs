using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Services
{
    public interface IUsable
    {
        string Name { get; }
        string Desciption { get; }
        bool IsActiveIn(DateTime when);
        bool IsActiveIn(DateRange when);
        double Price { get; }
        DateRange Availability { get; }
    }
}
