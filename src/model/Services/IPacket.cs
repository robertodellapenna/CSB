using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Services
{
    public interface IPacket
    {
        double Price { get; }
        DateRange Availability { get; }
        
        bool IsActiveIn(DateTime when);
        bool IsActiveIn(DateRange when);
        string Name { get; }
        string Description { get; }

        /// <summary>
        /// Servizio a cui fa riferimento il pacchetto
        /// </summary>
        IUsable Usable { get; }

        /// <summary>
        /// Dato un insieme di IUsage restituisce un IEnumerable degli
        /// usage che non soddisfano le regole del pacchetto.
        /// </summary>
        /// <param name="usage">Collezione di elementi IUsage</param>
        /// <returns>Collezione di elementi che non soddisfano le condizioni
        /// del pacchetto</returns>
        IEnumerable<IUsage> Filter(IEnumerable<IUsage> usage);
    }
}
