using CSB_Project.src.model.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.persistence
{
    public interface IItemPopulator
    {
        void Popoulate(IDictionary<string, IItem> dict);
    }
}
