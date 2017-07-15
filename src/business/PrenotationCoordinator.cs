using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Item;
using CSB_Project.src.model.Services;
using CSB_Project.src.model.Structure;
using CSB_Project.src.model.TrackingDevice;
using CSB_Project.src.model.Users;
using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using CSB_Project.src.model.Prenotation;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace CSB_Project.src.business
{
    public interface IPrenotationCoordinator : ICoordinator
    {
        ReadOnlyCollection<IPrenotation> Prenotations { get; }
        IEnumerable<CustomizableServizablePrenotation> GetPrenotationByClient(ICustomer client, DateTime date);
        void AddPrenotation(ICustomizableServizablePrenotation prenotation);
        IEnumerable<Position> BusyPositions(Sector sector, DateRange rangeData);
        bool IsAvailable(Sector sector,Position position, DateRange rangeData);
        bool CanAdd(ICustomizableItemPrenotation ICustomizableItemPrenotation);
        bool CanAdd(ICustomizableServizablePrenotation prenotation);
        event EventHandler<PrenotationEventArgs> PrenotationChanged;
    }

    class PrenotationCoordinator : AbstractCoordinatorDecorator, IPrenotationCoordinator
    {
        #region Eventi
        public event EventHandler<PrenotationEventArgs> PrenotationChanged;
        #endregion

        #region Campi
        private readonly IList<ICustomizableServizablePrenotation> _prenotations = new List<ICustomizableServizablePrenotation>();
        #endregion

        #region Proprietà
        public ReadOnlyCollection<IPrenotation> Prenotations => 
            new ReadOnlyCollection<IPrenotation>(new List<IPrenotation>(_prenotations));
        
        #endregion

        #region Costruttori
        public PrenotationCoordinator(ICoordinator next) : base(next) { }

        #endregion

        #region Metodi
        protected override void Init()
        {
            base.Init();
            /* Cerco un file di configurazione delle prenotation nel fileSystem,
             * se lo trovo carico le prenotation contenute
             */

            /* Prenotations HardCoded */
            StructureCoordinator sectorCoord = CoordinatorManager.Instance.CoordinatorOfType<StructureCoordinator>();
            Sector mySector = sectorCoord.GetSectorIn("Stabilimento Bologna Via Mario Longhena", "Spiaggia", "Settore base");
            Sector mySectorVip = sectorCoord.GetSectorIn("Stabilimento Bologna Via Mario Longhena", "Spiaggia", "Settore vip");

            BookingCoordinator bookCoord = CoordinatorManager.Instance.CoordinatorOfType<BookingCoordinator>();
            IBookableItem myBookableItem = bookCoord.GetBookableItem(mySector, new Position(1, 3));
            IBookableItem myBookableItemVip = bookCoord.GetBookableItem(mySectorVip, new Position(1, 1));

            DateRange myRange1 = new DateRange(30);
            DateRange myRange2 = new DateRange(new DateTime(2017,08,10), new DateTime(2017,08,15));

            ICustomizableItemPrenotation myIItemPrenotation1 = new CustomizableItemPrenotation(myRange1, myBookableItem);
            ICustomizableItemPrenotation myIItemPrenotation2 = new CustomizableItemPrenotation(myRange2, myBookableItemVip);

            IItemCoordinator itemCoord = CoordinatorManager.Instance.CoordinatorOfType<IItemCoordinator>();
            IItem lettino = itemCoord.GetAssociableItemOf(myBookableItem.BaseItem).First();
            myIItemPrenotation1.AddPlugin(lettino, myRange1);
            myIItemPrenotation1.AddPlugin(lettino, new DateRange(myRange1.StartDate, myRange1.EndDate.AddDays(-2)));

            IItem lettinoVip = itemCoord.GetAssociableItemOf(myBookableItemVip.BaseItem).First();
            IItem lettinoBase = itemCoord.GetAssociableItemOf(myBookableItemVip.BaseItem).ElementAt(1);
            myIItemPrenotation2.AddPlugin(lettinoVip, myRange2);
            myIItemPrenotation2.AddPlugin(lettinoBase, myRange2);
            myIItemPrenotation2.AddPlugin(lettinoBase, myRange2);
            myIItemPrenotation2.AddPlugin(lettinoBase, myRange2);
            myIItemPrenotation2.AddPlugin(lettinoBase, myRange2);

            List<ICustomizableItemPrenotation> myItems = new List<ICustomizableItemPrenotation>();
            myItems.Add(myIItemPrenotation1);

            List<ICustomizableItemPrenotation> myItems2 = new List<ICustomizableItemPrenotation>();
            myItems2.Add(myIItemPrenotation2);

            ITrackingDeviceCoordinator tdCoord = CoordinatorManager.Instance.CoordinatorOfType<TrackingDeviceCoordinator>();
            ITrackingDevice myCard = tdCoord.Next;

            IUserCoordinator userCoord = CoordinatorManager.Instance.CoordinatorOfType<UserCoordinator>();
            ICustomer client=userCoord.Customers.Where(c => c.FiscalCode.Equals("CC3")).First();

            CustomizableServizablePrenotation myPrenotation = new CustomizableServizablePrenotation( client, myRange1, myItems, myCard, new AssociationDescriptor(myRange1, "CardBase"));
            tdCoord.LockTrackingDevice(myPrenotation);

            ITrackingDevice myCard2 = tdCoord.Next;
            CustomizableServizablePrenotation myPrenotation2 = new CustomizableServizablePrenotation( client, myRange2, myItems2, myCard2, new AssociationDescriptor(myRange2, "CardBase"));
            tdCoord.LockTrackingDevice(myPrenotation2);
            
            ServiceCoordinator serviceCoord = CoordinatorManager.Instance.CoordinatorOfType<ServiceCoordinator>();
            myPrenotation.AddPacket(serviceCoord.Packets.ElementAt(0));
            myPrenotation.AddBundle(serviceCoord.Bundles.ElementAt(0));

            _prenotations.Add(myPrenotation);
            _prenotations.Add(myPrenotation2);
        }

        public IEnumerable<CustomizableServizablePrenotation> GetPrenotationByClient(ICustomer client, DateTime date)
        {
            IList<CustomizableServizablePrenotation> result = new List<CustomizableServizablePrenotation>();
            foreach (CustomizableServizablePrenotation prenotation in _prenotations)
            {
               
                if (client.FiscalCode.Equals(prenotation.Client.FiscalCode) && prenotation.PrenotationDate.Contains(date))
                    result.Add(prenotation);
            }

            return result;
        }

        public void AddPrenotation(ICustomizableServizablePrenotation prenotation)
        {
            #region Precondizioni
            if (prenotation == null)
                throw new ArgumentNullException("prenotation null");
            if (!CanAdd(prenotation))
                throw new Exception("prenotation not valid");
            #endregion
            _prenotations.Add(prenotation);
            prenotation.PrenotationChanged += (sender, pea) => OnPrenotationChanged(this, pea);
            OnPrenotationChanged(this, new PrenotationEventArgs(prenotation));
        }
        public IEnumerable<Position> BusyPositions(Sector sector, DateRange rangeData)
        {
            #region Precondizioni
            if (sector == null)
                throw new ArgumentNullException("sector null");
            if (rangeData == null)
                throw new ArgumentNullException("rangeData null");
            #endregion
            IEnumerable<IBookableItem> items;

            items= (from item in BookedItems(rangeData)
                    where item.Sector.Equals(sector)
                    select item);

            IEnumerable<Position> positions = new List<Position>();
            foreach (IBookableItem i in items)
                (positions as List<Position>).Add(i.Position);

            return positions;
        }
        public bool IsAvailable(Sector sector, Position position, DateRange rangeData)
        {
            #region Precondizioni
            if (sector == null)
                throw new ArgumentNullException("sector null");
            if (position == null)
                throw new ArgumentNullException("sector null");
            if (rangeData == null)
                throw new ArgumentNullException("rangeData null");
            if (position.Row > sector.Rows || position.Column > sector.Columns)
                throw new Exception("invalid position for this sector");
            #endregion
            return !BusyPositions(sector, rangeData).Where(pos => pos.Row == position.Row &&
                                                                 pos.Column == position.Column).Any();
        }
        public bool CanAdd(ICustomizableItemPrenotation ICustomizableItemPrenotation)
        {
            #region Precondizioni
            if (ICustomizableItemPrenotation == null)
                throw new ArgumentNullException("item prenotation null");
            #endregion
            return _prenotations.Where(
                prenotation => prenotation.BookedItems.Where(
                    item => item.BaseItem.Sector == ICustomizableItemPrenotation.BaseItem.Sector &&
                            item.BaseItem.Position.Row == ICustomizableItemPrenotation.BaseItem.Position.Row &&
                            item.BaseItem.Position.Column == ICustomizableItemPrenotation.BaseItem.Position.Column &&
                            item.RangeData.OverlapWith(ICustomizableItemPrenotation.RangeData)
                ).Any()
            ).Any();
        }
        public bool CanAdd(ICustomizableServizablePrenotation prenotation)
        {
            #region Precondizioni
            if (prenotation == null)
                throw new ArgumentNullException("prenotation null");
            #endregion
            foreach (ICustomizableItemPrenotation item in prenotation.BookedItems)
                if (!CanAdd(item)) return false;
            return true;
        }
        private IEnumerable<IBookableItem> BookedItems(DateRange rangeData)
        {
            #region Precondizioni
            if (rangeData == null)
                throw new ArgumentNullException("rangeData null");
            #endregion
            List<IBookableItem> result = new List<IBookableItem>();
            foreach (CustomizableServizablePrenotation p in _prenotations)
                foreach (ICustomizableItemPrenotation item in p.BookedItems)
                    if (rangeData.OverlapWith(item.RangeData))
                        result.Add(item.BaseItem);
            return result;
        }
        #endregion

        #region Handler
        private void OnPrenotationChanged(Object sender, PrenotationEventArgs args)
        {
            PrenotationChanged?.Invoke(sender, args);
        }
        #endregion
    }

    
}
