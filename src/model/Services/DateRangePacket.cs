using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Services
{
    public class DateRangePacket : AbstractPacket
    {
        #region Campi
        private readonly DateRange _range;
        #endregion

        #region Proprietà
        public DateRange Range => _range;
        #endregion 

        public DateRangePacket(DatePriceDescriptor descriptor, IUsable usable, DateRange range) : base(descriptor, usable)
        {
            #region Precondizioni 
            if (range == null)
                throw new ArgumentException("range null");
            #endregion
            _range = range;
        }

        public override IEnumerable<IUsage> filter(IEnumerable<IUsage> usage)
        {
            IEnumerable<IUsage> validMatch = from i in usage
                         where i.Type == Usable && Range.Contains(i.When)
                         select i;
            return usage.Except(validMatch);
        }
    }
}
