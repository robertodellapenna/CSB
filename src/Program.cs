using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Utils;
using System;
using System.Xml;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CSB_Project
{
    public class Program
    {
        public static void Main(String[] args)
        {
            /*
            Console.WriteLine("Hello");
            Console.WriteLine("type -> " + typeof(ItemFactory.BasicParser) );
            foreach(MethodInfo mi in Type.GetType("CSB_Project.src.model.Booking.ItemFactory+BasicParser").GetMethods())
            {
                Console.WriteLine("inversione -> " + mi.Name + " static " + mi.IsStatic);
            }
            */

            //Console.WriteLine("Counted " + ItemFactory.GetItems.Count());
            //Console.WriteLine("Test singleton " + (ItemFactory.GetItem(i.Name) == i));
            StringBuilder br = new StringBuilder();
            br.AppendLine("<Items>");
            br.AppendLine("  <Item>");
            br.AppendLine("    <Class>CSB_Project.src.model.Booking.ItemFactory+BasicParser</Class>");
            br.AppendLine("    <Identifier>MyItem100</Identifier>");
            br.AppendLine("    <Name>MyItem</Name>");
            br.AppendLine("    <Description>MyItemDesc</Description>");
            br.AppendLine("    <Price>100</Price>");
            br.AppendLine("  </Item>");
            br.AppendLine("</Items>");
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(br.ToString());
            XmlElement root = xml.DocumentElement;
            Console.WriteLine("Root -> " + root.Name + ":" + root.Value);
            XmlNodeList xnl = root.SelectNodes("/Items/Item");
            Console.WriteLine("Item Count -> " + xnl.Count);
            //CSB_Project.src.model.Booking.ItemFactory+BasicParser\nF1\nF2\nF3
            try
            {
                //IItem n = ItemFactory.GetItem(i.Name);
                IItem i = ItemFactory.CreateItem(xnl.Item(0));
                Console.WriteLine("name " + i.Identifier);
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore \n " + e);
            }

            Console.WriteLine("Fine");
        }
    }
}