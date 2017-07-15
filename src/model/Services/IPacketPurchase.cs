using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Services
{
    public interface IPacketPurchase
    {
        DateTime PurchaseDate { get; }
        IPacket Packet { get; }
    }
}
