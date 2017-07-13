using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Category;
using CSB_Project.src.model.Item;
using CSB_Project.src.model.Structure;
using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CSB_Project.src.business
{
    public interface IBookingCoordinator : ICoordinator
    {
        IEnumerable<IBookableItem> BookableItems { get; }
        IEnumerable<IBookableItem> Filter(Structure structure);
        IEnumerable<IBookableItem> Filter(StructureArea area);
        IEnumerable<IBookableItem> Filter(Sector sector);
        IBookableItem GetBookableItem(Sector sector, Position position);
        void AddBookableItem(IBookableItem item);
        event EventHandler BookingChanged;
    }

    public class BookingCoordinator : AbstractCoordinatorDecorator, IBookingCoordinator
    {
        #region Eventi
        public event EventHandler BookingChanged;
        #endregion

        #region Campi
        private readonly List<IBookableItem> _bookableItems = new List<IBookableItem>();
        #endregion

        #region Proprietà
        public IEnumerable<IBookableItem> BookableItems => _bookableItems.ToArray();
        #endregion

        #region Costruttori
        public BookingCoordinator(ICoordinator next) : base(next)
        {
        }

        #endregion

        #region Metodi
        protected override void Init()
        {
            base.Init();
            /* Cerco un file di configurazione dei bookable items nel fileSystem,
             * se lo trovo carico i bookable items  contenuti
             */

            /* Bookable Items HardCoded */
            StringBuilder br = new StringBuilder();
            br.AppendLine("<Items>");
            br.AppendLine("  <Item>");
            br.AppendLine("    <Class>CSB_Project.src.model.Item.ItemFactory+BasicParser</Class>");
            br.AppendLine("    <Identifier>MyItem100</Identifier>");
            br.AppendLine("    <Name>OmbrelloneSemplice</Name>");
            br.AppendLine("    <Description>MyItemDesc</Description>");
            br.AppendLine("    <Price>10</Price>");
            br.AppendLine("  </Item>");
            br.AppendLine("  <Item>");
            br.AppendLine("    <Class>CSB_Project.src.model.Item.ItemFactory+CategorizableParser</Class>");
            br.AppendLine("    <Identifier>MyItemCustomizable</Identifier>");
            br.AppendLine("    <Name>OmberllonePaglia</Name>");
            br.AppendLine("    <Description>MyItemDesc</Description>");
            br.AppendLine("    <Price>10</Price>");
            br.AppendLine("    <Category>");
            br.AppendLine("      <Path>\\ROOT\\materiali\\testa</Path>");
            br.AppendLine("      <Name>paglia</Name>");
            br.AppendLine("      <Description>paglia molto buona</Description>");
            br.AppendLine("      <Price>10</Price>");
            br.AppendLine("    </Category>");
            br.AppendLine("    <Category>");
            br.AppendLine("      <Path>\\ROOT\\materiali\\staffa</Path>");
            br.AppendLine("      <Name>legno</Name>");
            br.AppendLine("      <Description>legno</Description>");
            br.AppendLine("      <Price>0</Price>");
            br.AppendLine("    </Category>");
            br.AppendLine("  </Item>");
            br.AppendLine("</Items>");
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(br.ToString());
            XmlElement root = xml.DocumentElement;
            Console.WriteLine("Root -> " + root.Name + ":" + root.Value);
            XmlNodeList xnl = root.SelectNodes("/Items/Item");
            Console.WriteLine("Item Count -> " + xnl.Count);
            try
            {
                for (int i = 0; i < xnl.Count; i++)
                {
                    IItem it = ItemFactory.CreateItem(xnl.Item(i));
                    Console.WriteLine("Name " + it.Identifier);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore \n " + e);
            }
            /*
            foreach (IItem ci in ItemFactory.Items.OfType<IItem>())
            {
                Console.WriteLine("name :" + ci.Identifier );
               
            }

            foreach (ICategorizableItem ci in ItemFactory.Items.OfType<ICategorizableItem>())
            {
                Console.WriteLine("name :" + ci.Identifier + ", num prop :" + ci.Categories.Count());
                foreach (KeyValuePair<ICategory, PriceDescriptor> cat in ci.Properties)
                {
                    Console.WriteLine("\tCat : " + cat.Key.Name + ", Value : " + cat.Value.Name);
                }
            }
            */
            IItem ombrelloneBase = ItemFactory.Items.Where(item => item.Identifier.Equals("MyItem100")).FirstOrDefault();
            ICategorizableItem ombrellonePaglia = ItemFactory.Items.OfType<ICategorizableItem>().Where(item => item.Identifier.Equals("MyItemCustomizable")).FirstOrDefault();

            StructureCoordinator structCoord = CoordinatorManager.Instance.CoordinatorOfType<StructureCoordinator>();
            Sector settoreBase = structCoord.GetSectorIn("Stabilimento Bologna Via Mario Longhena", "Spiaggia", "Settore base");
            Sector settoreVip = structCoord.GetSectorIn("Stabilimento Bologna Via Mario Longhena", "Spiaggia", "Settore vip");

            if (ombrelloneBase == null)
                Console.WriteLine("ombrellone base null");
            else if (ombrelloneBase == null)
                Console.WriteLine("ombrellone vip null");
            else
            {
                for (int row = 1; row <= settoreBase.Rows; row++)
                    for (int col = 1; col <= settoreBase.Columns; col++)
                    {
                        IBookableItem item = new SectorBookableItem(ombrelloneBase, new Position(row, col), settoreBase);
                        _bookableItems.Add(item);
                    }
                for (int row = 1; row <= settoreVip.Rows; row++)
                    for (int col = 1; col <= settoreVip.Columns; col++)
                    {
                        IBookableItem item = new SectorBookableItem(ombrellonePaglia, new Position(row, col), settoreVip);
                        _bookableItems.Add(item);
                    }
            }
            
        }
        public void AddBookableItem(IBookableItem bookableItem)
        {
            #region Precondizioni
            if (bookableItem == null)
                throw new ArgumentNullException("bookable item null");
            foreach (IBookableItem item in Filter(bookableItem.Sector))
                if (item.Position.Row==bookableItem.Position.Row &&
                    item.Position.Column==bookableItem.Position.Column)
                    throw new Exception("position not available");
            #endregion
            (_bookableItems as List<IBookableItem>).Add(bookableItem);
        }
        public IEnumerable<IBookableItem> Filter(Structure structure)
        {
            #region Precondizioni
            if (structure == null)
                throw new ArgumentNullException("area null");
            #endregion
            return _bookableItems.Where(item => structure.Areas.Where(area => area.Sectors.Contains(item.Sector)).Any()).ToArray();
        }
        public IEnumerable<IBookableItem> Filter(StructureArea area)
        {
            #region Precondizioni
            if (area == null)
                throw new ArgumentNullException("area null");
            #endregion
            return _bookableItems.Where(item => area.Sectors.Contains(item.Sector)).ToArray();
        }
        public IEnumerable<IBookableItem> Filter(Sector sector)
        {
            #region Precondizioni
            if (sector == null)
                throw new ArgumentNullException("sector null");
            #endregion
            return _bookableItems.Where(item => item.Sector.Equals(sector)).ToArray();
        }
        public IBookableItem GetBookableItem(Sector sector, Position position)
        {
            #region Precondizioni
            if (sector == null)
                throw new ArgumentNullException("sector null");
            if (position == null)
                throw new ArgumentNullException("position null");
            if (position.Row > sector.Rows ||
                position.Column > sector.Columns)
                throw new ArgumentException("position not valid in this sector");
            #endregion
            return (from item in Filter(sector)
                    where (item.Position.Row == position.Row &&
                    item.Position.Column == position.Column)
                    select item).FirstOrDefault();
                  
        }
        #endregion


        #region Handler
        private void OnBookingChanged(Object sender, EventArgs args)
        {
            BookingChanged?.Invoke(sender, args);
        }
        #endregion
    }
}
