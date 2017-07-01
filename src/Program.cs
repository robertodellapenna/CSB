using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Utils;
using System;
using System.Xml;
using System.Linq;
using System.Reflection;
using System.Text;
using CSB_Project.src.model.Item;
using System.Text.RegularExpressions;
using static CSB_Project.src.model.Item.ItemFactory;
using CSB_Project.src.model.Category;
using System.Collections.Generic;

namespace CSB_Project
{
    public class Program
    {
        public static void Main(String[] args)
        {

            /* Test regex */
            //Console.WriteLine(Regex.IsMatch("\\root", @"^(\\[^\\]+){1,}$"));
            //Console.WriteLine(Regex.IsMatch("\\root\\hello", "^(\\[^\\]+){1,}$", RegexOptions.ECMAScript));

            StringBuilder br = new StringBuilder();
            br.AppendLine("<Items>");
            br.AppendLine("  <Item>");
            br.AppendLine("    <Class>CSB_Project.src.model.Item.ItemFactory+BasicParser</Class>");
            br.AppendLine("    <Identifier>MyItem100</Identifier>");
            br.AppendLine("    <Name>MyItem</Name>");
            br.AppendLine("    <Description>MyItemDesc</Description>");
            br.AppendLine("    <Price>100</Price>");
            br.AppendLine("  </Item>");
            br.AppendLine("  <Item>");
            br.AppendLine("    <Class>CSB_Project.src.model.Item.ItemFactory+CategorizableParser</Class>");
            br.AppendLine("    <Identifier>MyItemCustomizable</Identifier>");
            br.AppendLine("    <Name>Omberllone</Name>");
            br.AppendLine("    <Description>MyItemDesc</Description>");
            br.AppendLine("    <Price>200</Price>");
            br.AppendLine("    <Category>");
            br.AppendLine("      <Path>\\ROOT\\materiali\\testa</Path>");
            br.AppendLine("      <Name>velluto brasiliano</Name>");
            br.AppendLine("      <Description>velluto super costoso</Description>");
            br.AppendLine("      <Price>20000</Price>");
            br.AppendLine("    </Category>");
            br.AppendLine("    <Category>");
            br.AppendLine("      <Path>\\ROOT\\materiali\\staffa</Path>");
            br.AppendLine("      <Name>legno marcio</Name>");
            br.AppendLine("      <Description>legno scadente</Description>");
            br.AppendLine("      <Price>2</Price>");
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

            foreach(ICategorizableItem ci in ItemFactory.GetItems.OfType<ICategorizableItem>())
            {
                Console.WriteLine("name :" + ci.Identifier + ", num prop :" + ci.Categories.Count());
                foreach(KeyValuePair<ICategory, PriceDescriptor> cat in ci.Properties)
                {
                    Console.WriteLine("\tCat : " + cat.Key.Name + ", Value : " + cat.Value.Name);
                }
            }

            Console.WriteLine("Fine");
        }
    }
}