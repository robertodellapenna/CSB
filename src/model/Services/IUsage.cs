using CSB_Project.src.model.TrackingDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Services
{
    /// <summary>
    /// Rappresenta un utilizzo di un servizio della struttura
    /// </summary>
    public interface IUsage
    {
        /// <summary>
        /// Quando è stato utilizzato il servizio
        /// </summary>
        DateTime When { get; }
        /// <summary>
        /// Da chi è stato utilizzato il servizio
        /// </summary>
        ITrackingDevice Who { get; }
        /// <summary>
        /// Il servizio utilizzato
        /// </summary>
        IUsable Type { get; }
    }
}
