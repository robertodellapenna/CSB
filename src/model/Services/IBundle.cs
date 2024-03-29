﻿using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Services
{
    public interface IBundle
    {
        /// <summary>
        /// Pacchetti che formano il bundle
        /// </summary>
        ISet<IPacket> Packets { get; }

        double Price { get; }
        DateRange Availability { get; }
        bool IsActiveIn(DateTime when);
        bool IsActiveIn(DateRange when);
        string Name { get; }
        string Description { get; }
        string InformationString { get; }
    }
}
