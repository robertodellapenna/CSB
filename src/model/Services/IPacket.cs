using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Services
{
    public interface IPacket
    {
        double Price { get; }
        DateRange Availability { get; }
        IUsable Usable { get; }
        bool IsActiveIn(DateTime when);
        bool IsActiveIn(DateRange when);
        string Name { get; }
        string Description { get; }

        IEnumerable<IUsage> filter(IEnumerable<IUsage> usage);
    }
}
