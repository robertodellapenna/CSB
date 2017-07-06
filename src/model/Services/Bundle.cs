using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Utils;

namespace CSB_Project.src.model.Services
{
    class Bundle : IBundle
    {
        #region Eventi
        #endregion
        #region Campi
        private readonly ISet<IPacket> _packets;
        private readonly DatePriceDescriptor _descriptor;
        #endregion
        #region Proprieta
        public ISet<IPacket> Packets => _packets;

        public double Price => _descriptor.Price;

        public DateRange Availability => _descriptor.Range;

        public string Name => _descriptor.Name;

        public string Description => _descriptor.Description;
        #endregion
        #region Costruttori
        
        public Bundle(ISet<IPacket> packets, DatePriceDescriptor descriptor)
        {
            if (packets == null || packets.Count == 0)
                throw new ArgumentException("packets not valid");
            foreach (IPacket packet in packets)
                if (!packet.Availability.Contains(descriptor.Range))
                    throw new ArgumentException("packet range not valid" + packet.Name);
            _packets = packets;
            if (descriptor == null)
                throw new ArgumentException("descriptor not valid");
            _descriptor = descriptor;
        }
        #endregion
        #region Metodi
        public bool IsActiveIn(DateTime when)
        {
            return Availability.Contains(when);
        }

        public bool IsActiveIn(DateRange when)
        {
            return Availability.Contains(when);
        }
        #endregion
        #region Handler
        #endregion
    }
}
