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
        public override string InformationString => "Utilizzi illimitati compresi dal " + Range.StartDate + " al " + Range.EndDate;
        #endregion 

        public DateRangePacket(DatePriceDescriptor descriptor, IUsable usable, DateRange range) : base(descriptor, usable)
        {
            #region Precondizioni 
            if (range == null)
                throw new ArgumentException("range null");
            if(range.StartDate > descriptor.Range.EndDate)
                throw new ArgumentException("range out of bound");
            #endregion
            _range = range;
        }

        public override IEnumerable<IUsage> Filter(IEnumerable<IUsage> usage)
        {
            IEnumerable<IUsage> validMatch = from i in usage
                         where i.Type == Usable && Range.Contains(i.When)
                         select i;
            return usage.Except(validMatch);
        }
    }
}
