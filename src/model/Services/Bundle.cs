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
        private readonly double _price;
        private readonly DateRange _availability;
        private readonly string _name;
        private readonly string _description;
        #endregion
        #region Proprieta
        public ISet<IPacket> Packets => _packets;

        public double Price => _price;

        public DateRange Availability => _availability;

        public string Name => _name;

        public string Description => _description;
        #endregion
        #region Costruttori
        public Bundle(ISet<IPacket> packets, double price, DateRange availability, string name, string description)
        {
            _packets = packets;
            _price = price;
            _availability = availability;
            _name = name;
            _description = description;
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
