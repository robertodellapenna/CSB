using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Utils;

namespace CSB_Project.src.model.Services
{
    public class TicketPacket : AbstractPacket
    {

        #region Campi
        private readonly int _ticket;
        #endregion

        #region Proprietà
        public int Ticket => _ticket;
        #endregion 

        public TicketPacket(DatePriceDescriptor descriptor, IUsable usable, int ticket) : base(descriptor, usable)
        {
            #region Precondizioni 
            if(ticket < 0)
                throw new ArgumentException("ticket < 0");
            #endregion
            _ticket = ticket;
        }

        public override IEnumerable<IUsage> filter(IEnumerable<IUsage> usage)
        {
            IEnumerable<IUsage> validMatch = usage.Where((i) => i.Type == Usable).Take(_ticket);
            return usage.Except(validMatch);
        }
    }
}
