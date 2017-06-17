using CSB_Project.src.model.TrackingDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Services
{
    public interface IUsage
    {
        DateTime When { get; }
        ITrackingDevice Who { get; }
        IUsable Type { get; }
    }
}
