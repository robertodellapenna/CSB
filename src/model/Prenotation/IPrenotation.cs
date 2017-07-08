using CSB_Project.src.model.Services;
using CSB_Project.src.model.TrackingDevice;
using CSB_Project.src.model.Users;
using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Prenotation
{
    public interface IPrenotation
    {
        DateRange PrenotationDate { get; }
        IClient Client { get; }
        double Price { get; }
        ReadOnlyCollection<IItemPrenotation> BookedItems { get; }
        void AddItem(IItemPrenotation item);
    }

    public interface ICustomizablePrenotation : IPrenotation
    {
        ReadOnlyCollection<IPacket> Packets { get; }
        ReadOnlyCollection<IBundle> Bundles { get; }
        void AddPacket(IPacket packet);
        void AddBundle(IBundle bundle);
    }

    public interface IServizablePrenotation : IPrenotation
    {
        ReadOnlyCollection<KeyValuePair<ITrackingDevice, AssociationDescriptor>> TrackingDeviceAssociations { get; }
        ReadOnlyCollection<ITrackingDevice> TrackingDevices { get; }
        void AddTrackingDevice(ITrackingDevice trackingDevice, AssociationDescriptor associationDescriptor);
    }
}
