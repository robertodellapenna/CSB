﻿using CSB_Project.src.model.Item;
using CSB_Project.src.model.Structure;
using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Booking
{
    public interface IBookableItem
    {
        IItem BaseItem { get; }
        StructureArea Area { get; }
        double DailyPrice { get; }
    }
}
