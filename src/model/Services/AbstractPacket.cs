using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Utils;

namespace CSB_Project.src.model.Services
{
    public abstract class AbstractPacket : IPacket
    {

        #region Campi
        private readonly DatePriceDescriptor _descriptor;
        private readonly IUsable _usable;
        #endregion

        #region Proprietà
        public string Name => _descriptor.Name;
        public string Description => _descriptor.Description;
        public double Price => _descriptor.Price;
        public abstract string InformationString { get; }
        /// <summary>
        /// Periodo in cui il pacchetto risulta disponibile.
        /// </summary>
        public DateRange Availability => _descriptor.Range;
        public IUsable Usable => _usable;
        #endregion

        #region Costruttori
        public AbstractPacket(DatePriceDescriptor descriptor, IUsable usable)
        {
            #region Precondizioni
            if (descriptor == null || usable == null)
                throw new ArgumentException("descriptor o usable null");
            if (!usable.Availability.Contains(descriptor.Range))
                throw new ArgumentException("descriptor out of service's range");
            #endregion
            _descriptor = descriptor;
            _usable = usable;
        }
        #endregion
        
        #region Metodi
        public bool IsActiveIn(DateTime when) => Availability.Contains(when);
        public bool IsActiveIn(DateRange when) => Availability.Contains(when);
        public abstract IEnumerable<IUsage> Filter(IEnumerable<IUsage> usage);
        #endregion
    }
}
