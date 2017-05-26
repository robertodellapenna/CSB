using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model
{
    interface IBookableItem
    {
        string Name { get; }
        Tuple<string, double> GetValueCategory(ICategory category);
        ICollection<Tuple<string, double>> GetValues();
        ICollection<ICategory> GetCategories();
        double BaseDailyPrice { get; }
        double DailyPrice { get; }
    }
}
