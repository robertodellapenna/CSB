using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Item;
using CSB_Project.src.model.Prenotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.presentation.Utils
{
    public interface IPrenotationVisitor
    {
        void Visit(IPrenotation prenotation);
        void Visit(ICustomizableServizablePrenotation prenotation);
        void Visit(IItemPrenotation itemPrenotation);
        void Visit(ICategorizableItem item);
        void Visit(IItem item);
        void Visit(IBookableItem item);
    }
}
