using CSB_Project.src.model.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CSB_Project.src.business
{
    public interface IItemCoordinator : ICoordinator
    {
        IEnumerable<IItem> BaseItems { get; }
        IEnumerable<IItem> GetAssociableItemOf(IItem baseItem);
    }

    class ItemCoordinator : AbstractCoordinatorDecorator, IItemCoordinator
    {
        private Compatibilities _compatibilites = Compatibilities.Instance;

        public ItemCoordinator(ICoordinator next) : base(next)
        {
        }

        protected override void Init()
        {
            base.Init();

            /* Hardcoded item */
            #region Creazioni item tramite xml
            StringBuilder br = new StringBuilder();
            br.AppendLine("<Items>");
            br.AppendLine("  <Item>");
            br.AppendLine("    <Class>CSB_Project.src.model.Item.ItemFactory+BasicParser</Class>");
            br.AppendLine("    <Identifier>Plugin1</Identifier>");
            br.AppendLine("    <Name>Lettino</Name>");
            br.AppendLine("    <Description>Lettino piccolino</Description>");
            br.AppendLine("    <Price>2</Price>");
            br.AppendLine("  </Item>");
            br.AppendLine("  <Item>");
            br.AppendLine("    <Class>CSB_Project.src.model.Item.ItemFactory+CategorizableParser</Class>");
            br.AppendLine("    <Identifier>Plugin2</Identifier>");
            br.AppendLine("    <Name>Lettino più bellino</Name>");
            br.AppendLine("    <Description>Lettino con tante cose belle</Description>");
            br.AppendLine("    <Price>4</Price>");
            br.AppendLine("    <Category>");
            br.AppendLine("      <Path>\\ROOT\\materiali\\testa</Path>");
            br.AppendLine("      <Name>Oro</Name>");
            br.AppendLine("      <Description>sembra oro ma non lo è</Description>");
            br.AppendLine("      <Price>1</Price>");
            br.AppendLine("    </Category>");
            br.AppendLine("  </Item>");
            br.AppendLine("</Items>");
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(br.ToString());
            XmlElement root = xml.DocumentElement;
            XmlNodeList xnl = root.SelectNodes("/Items/Item");
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
                throw new Exception("non sono riuscito ad inserire gli hardcoded item");
            }
            #endregion
            IItem plug1 = ItemFactory.GetItem("Plugin1");
            IItem plug2 = ItemFactory.GetItem("Plugin2");
            IItem baseOmbrellone = ItemFactory.GetItem("MyItem100");
            IItem vipOmbrellone = ItemFactory.GetItem("MyItemCustomizable");
            _compatibilites.AddCompatibility(baseOmbrellone, plug1, 2);
            _compatibilites.AddCompatibility(vipOmbrellone, plug2, 1);
            _compatibilites.AddCompatibility(vipOmbrellone, plug1, 10);
        }

        public IEnumerable<IItem> BaseItems => _compatibilites.BaseItems;

        public IEnumerable<IItem> GetAssociableItemOf(IItem baseItem)
            => _compatibilites.GetAllAssociableItems(baseItem);
    }
}
