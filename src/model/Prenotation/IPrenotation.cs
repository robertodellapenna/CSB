using CSB_Project.src.model.Services;
using CSB_Project.src.model.TrackingDevice;
using CSB_Project.src.model.Users;
using CSB_Project.src.model.Utils;
using CSB_Project.src.presentation.Utils;
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
        ICustomer Client { get; }
        double Price { get; }
        ReadOnlyCollection<IItemPrenotation> BookedItems { get; }
        void AddItem(IItemPrenotation item);
        string InformationString { get; }
        event EventHandler<PrenotationEventArgs> PrenotationChanged;
        void Accept(IPrenotationVisitor visitor);
    }

    public interface ICustomizableServizablePrenotation : IPrenotation
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

    public class PrenotationEventArgs : EventArgs
    {
        private readonly IPrenotation _prenotation;
        public IPrenotation Prenotation => _prenotation;
        public PrenotationEventArgs(IPrenotation prenotation)
        {
            _prenotation = prenotation;
        }
    }
}
