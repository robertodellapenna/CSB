using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model
{
    interface IBookableItem
    {
        string Name { get; }
        ICollection<IProperty> Properties  { get; }
        double DailyPrice { get; }
     
    }
}
