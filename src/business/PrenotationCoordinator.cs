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

namespace CSB_Project.src.business
{
    public interface IPrenotationCoordinator : ICoordinator
    {
        IEnumerable<CustomizableServizablePrenotation> Prenotations { get; }
        void AddPrenotation(CustomizableServizablePrenotation prenotation);
        void AddIItemPrenotation(int idPrenotation, ICustomizableItemPrenotation ICustomizableItemPrenotation);
        void AddPacket(int idPrenotation, IPacket packet);
        IEnumerable<Position> BusyPositions(Sector sector, DateRange rangeData);
        bool IsAvailable(Sector sector,Position position, DateRange rangeData);
        bool CanAdd(ICustomizableItemPrenotation ICustomizableItemPrenotation);
        bool CanAdd(CustomizableServizablePrenotation prenotation);
        event EventHandler PrenotationChanged;
    }

    class PrenotationCoordinator : AbstractCoordinatorDecorator, IPrenotationCoordinator
    {
        #region Eventi
        public event EventHandler PrenotationChanged;
        #endregion

        #region Campi
        private readonly List<CustomizableServizablePrenotation> _prenotations = new List<CustomizableServizablePrenotation>();
        #endregion

        #region Proprietà
        public IEnumerable<CustomizableServizablePrenotation> Prenotations
        {

            get
            {
                CustomizableServizablePrenotation[] copy = new CustomizableServizablePrenotation[_prenotations.Count];
                _prenotations.CopyTo(copy);
                return copy;
            }
        }
        
        #endregion

        #region Costruttori
        public PrenotationCoordinator(ICoordinator next) : base(next)
        {
        }

        #endregion

        #region Metodi
        protected override void init()
        {
            base.init();
            /* Cerco un file di configurazione delle prenotation nel fileSystem,
             * se lo trovo carico le prenotation contenute
             */

            /* Prenotations HardCoded */
            StructureCoordinator sectorCoord = CoordinatorManager.Instance.CoordinatorOfType<StructureCoordinator>();
            Sector mySector = sectorCoord.GetSectorIn("Stabilimento Bologna Via Mario Longhena", "Spiaggia", "Settore base");

            BookingCoordinator bookCoord = CoordinatorManager.Instance.CoordinatorOfType<BookingCoordinator>();
            IBookableItem myBookableItem = bookCoord.GetBookableItem(mySector, new Position(1, 3));

            DateRange myRange1 = new DateRange(30);

            ICustomizableItemPrenotation myIItemPrenotation1 = new CustomizableItemPrenotation(myRange1, myBookableItem);

            ItemCoordinator itemCoord = CoordinatorManager.Instance.CoordinatorOfType<ItemCoordinator>();
            IItem sdraio = itemCoord.GetAssociableItemOf(myBookableItem.BaseItem).Where(plugin => plugin.Identifier.Equals("Sdraio1")).ElementAt(0);
            myIItemPrenotation1.AddPlugin(sdraio, myRange1);
            myIItemPrenotation1.AddPlugin(sdraio, myRange1);
            IItem lettino = itemCoord.GetAssociableItemOf(myBookableItem.BaseItem).Where(plugin => plugin.Identifier.Equals("Lettino1")).ElementAt(0);
            myIItemPrenotation1.AddPlugin(lettino, myRange1);

            List<ICustomizableItemPrenotation> myItems = new List<ICustomizableItemPrenotation>();
            myItems.Add(myIItemPrenotation1);

            TrackingDeviceCoordinator tdCoord = CoordinatorManager.Instance.CoordinatorOfType<TrackingDeviceCoordinator>();
            ITrackingDevice myCard = tdCoord.Next;

            IUserCoordinator userCoord = CoordinatorManager.Instance.CoordinatorOfType<UserCoordinator>();
            Client client = new Client(1, "Roberto", "Della Penna", "RDP1295", "12/04/1995");

            CustomizableServizablePrenotation myPrenotation = new CustomizableServizablePrenotation(1, client, myRange1, myItems, myCard, new AssociationDescriptor(myRange1, "CardBase"));

            ServiceCoordinator serviceCoord = CoordinatorManager.Instance.CoordinatorOfType<ServiceCoordinator>();
            IPacket doccia=serviceCoord.FilterPacketDate(myRange1).Where(packet => packet.Name.Equals("Doccia calda")).ElementAt(0);

            myPrenotation.AddPacket(doccia);

            _prenotations.Add(myPrenotation);

        }

        public void AddPrenotation(CustomizableServizablePrenotation prenotation)
        {
            #region Precondizioni
            if (prenotation == null)
                throw new ArgumentNullException("prenotation null");
            if (!CanAdd(prenotation))
                throw new Exception("prenotation not valid");
            #endregion
            _prenotations.Add(prenotation);
        }
        public void AddIItemPrenotation(int idPrenotation, ICustomizableItemPrenotation ICustomizableItemPrenotation)
        {
            #region Precondizioni
            if (idPrenotation < 0)
                throw new ArgumentException("id not valid");
            if (ICustomizableItemPrenotation == null)
                throw new ArgumentNullException("item prenotation null");
            if (GetPrenotation(idPrenotation)==null)
                throw new Exception("prenotation not found");
            if(!CanAdd(ICustomizableItemPrenotation))
                throw new Exception("item prenotation not valid");
            #endregion
            GetPrenotation(idPrenotation).AddItem(ICustomizableItemPrenotation);
        }
        public void AddPacket(int idPrenotation, IPacket packet)
        {
            #region Precondizioni
            if (idPrenotation < 0)
                throw new ArgumentException("id not valid");
            if (packet == null)
                throw new ArgumentNullException("packet null");
            if (GetPrenotation(idPrenotation) == null)
                throw new Exception("prenotation not found");
            #endregion
            GetPrenotation(idPrenotation).AddPacket(packet);
        }
        public IEnumerable<Position> BusyPositions(Sector sector, DateRange rangeData)
        {
            #region Precondizioni
            if (sector == null)
                throw new ArgumentNullException("sector null");
            if (rangeData == null)
                throw new ArgumentNullException("rangeData null");
            #endregion
            return (from item in BookedItems(rangeData)
                    where item.Sector == sector
                    select item.Position);
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
        public bool CanAdd(CustomizableServizablePrenotation prenotation)
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
                    if (item.RangeData.OverlapWith(rangeData))
                        result.Add(item.BaseItem);
            return result;
        }
        private CustomizableServizablePrenotation GetPrenotation(int idPrenotation)
        {
            #region Precondizioni
            if (idPrenotation < 0)
                throw new ArgumentException("id not valid");
            #endregion
            if (!_prenotations.Where(prenotation => prenotation.Id == idPrenotation).Any())
                return null;
            return _prenotations.Where(prenotation => prenotation.Id == idPrenotation).ElementAt(0);
        }
        #endregion

        #region Handler
        private void OnStructureChanged(Object sender, EventArgs args)
        {
            PrenotationChanged?.Invoke(sender, args);
        }
        #endregion
    }
}
