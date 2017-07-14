using CSB_Project.src.model.Item;
using CSB_Project.src.model.Prenotation;
using CSB_Project.src.model.Structure;
using CSB_Project.src.model.Utils;
using CSB_Project.src.presentation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Booking
{
    public interface IBookableItem
    {
        IItem BaseItem { get; }
        Sector Sector { get; }
        Position Position { get; }
        double DailyPrice { get; }
        void Accept(IPrenotationVisitor visitor);
    }
}
