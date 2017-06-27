using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Services
{
    /// <summary>
    /// Rappresenta un servizio della struttura
    /// </summary>
    public interface IUsable
    {
        string Name { get; }
        string Description { get; }
        bool IsActiveIn(DateTime when);
        bool IsActiveIn(DateRange when);
        double Price { get; }
        DateRange Availability { get; }
    }
}
