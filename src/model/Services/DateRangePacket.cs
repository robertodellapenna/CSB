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
        private readonly int _days;
        #endregion

        #region Proprietà
        public int Duration => _days;
        public override string InformationString => Name + "." + "Servizio : " + Usable.Name + ". Utilizzi illimitati per " + _days + " giorni";
        #endregion 

        public DateRangePacket(DatePriceDescriptor descriptor, IUsable usable, int days) : base(descriptor, usable)
        {
            #region Precondizioni 
            if (days < 0)
                throw new ArgumentException("days < 0");
            #endregion
            _days = days;
        }

        public override IEnumerable<IUsage> Filter(IEnumerable<IUsage> usage)
        {
            if (usage.Count() == 0)
                return new IUsage[0];

            IEnumerable<IUsage> sortedFilterd = from u in usage where u.Type == Usable orderby u.When ascending select u;
            DateTime startDate = sortedFilterd.First().When;

            IEnumerable<IUsage> validMatch = from u in sortedFilterd where u.When < startDate.AddDays(_days) select u;

            return usage.Except(validMatch);
        }
    }
}
