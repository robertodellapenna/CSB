using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Services
{
    public class PacketPurchase : IPacketPurchase
    {
        #region Campi
        private DateTime _purchaseDate;
        private IPacket _packet;
        #endregion

        #region Proprietà
        public IPacket Packet => _packet;
        public DateTime PurchaseDate => _purchaseDate;
        #endregion

        #region Costruttori
        public PacketPurchase(DateTime purchaseDate, IPacket packet)
        {
            #region Precondizion
            if (purchaseDate == null)
                throw new ArgumentNullException("purchase date null");
            if (packet == null)
                throw new ArgumentNullException("packet null");
            #endregion
            _packet = packet;
            _purchaseDate = purchaseDate;
        }
        #endregion
    }
}
