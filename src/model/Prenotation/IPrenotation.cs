﻿using CSB_Project.src.model.TrackingDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Prenotation
{
    public interface IPrenotation
    {
        ITrackingDevice[] TrackingDevices { get; }
    }
}
