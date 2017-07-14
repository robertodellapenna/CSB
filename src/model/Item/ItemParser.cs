using CSB_Project.src.business;
using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Category;
using CSB_Project.src.model.Prenotation;
using CSB_Project.src.model.Utils;
using CSB_Project.src.presentation.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Xml;

namespace CSB_Project.src.model.Item
{
    public partial class ItemFactory
    {
        #region BasicItem e Parser
        private class BasicItem : AbstractItem
        {
            public override string InformationString => FriendlyName + " " + BaseDailyPrice;
            public BasicItem(string id, PriceDescriptor priceDescriptor) : base(id, priceDescriptor) { }

            public override void Accept(IPrenotationVisitor visitor)
                => visitor.Visit(this);
        }

        private static class BasicParser
        {
            /// <summary>
            /// Effettua il parsing da nodo Xml a BasicItem
            /// </summary>
            /// <param name="itemToParse"></param>
            /// <returns></returns>
            public static BasicItem Parse(XmlNode itemToParse)
            {
                #region Precondizioni
                if (itemToParse == null)
                    throw new ArgumentException("itemToParse null");
                #endregion

                // Devono esserci 3 elementi, nome, descrizione e prezzzo.
                if (itemToParse.ChildNodes.Count != 5)
                    throw new ItemDescriptorException("Errore nell'elemento da parsare.\nMancano dei campi");
                string name = null, description = null, id = null;
                double price;

                try
                {
                    name = ParserUtils.RetrieveValues<String>(itemToParse, "Name")[0];
                    description = ParserUtils.RetrieveValues<String>(itemToParse, "Description")[0];
                    price = ParserUtils.RetrieveValues<double>(itemToParse, "Price")[0];
                    id = ParserUtils.RetrieveValues<String>(itemToParse, "Identifier")[0];
                }
                catch (ParsingException e)
                {
                    throw new ItemDescriptorException(e.Message);
                }

                return new BasicItem(id, new PriceDescriptor(name, description, price));
            }
        }
        #endregion

        #region CategorizableItem e Parser
        private class CategorizableItem : AbstractItem, ICategorizableItem
        {
            #region Campi
            /// <summary>
            /// Proprietà dell'item. Ad ogni categoria è associato un valore
            /// ed un prezzo da aggiungere all'elemento base.
            /// </summary>
            private readonly IDictionary<ICategory, PriceDescriptor> _properties;
            #endregion

            #region Proprietà
            /// <summary>
            /// Prezzo comprensivo di tutte le proprietà aggiuntive dell'oggetto
            /// </summary>
            public override double DailyPrice => BaseDailyPrice +
                            _properties.Values.Sum(priceDesc => priceDesc.Price);
            public IEnumerable<ICategory> Categories => _properties.Keys.ToArray();
            public ReadOnlyCollection<KeyValuePair<ICategory, PriceDescriptor>> Properties
                => new ReadOnlyCollection<KeyValuePair<ICategory, PriceDescriptor>>(_properties.ToList());

            public override string InformationString
            {
                get
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(FriendlyName + " Prezzo Base -> " +BaseDailyPrice + " Totale -> "+ DailyPrice);
                    sb.AppendLine("\tPERSONALIZZAZIONI:");
                    foreach(ICategory c in Categories)
                    {
                        sb.AppendLine("\t"+c.Name + ":" + _properties[c].Name + " " + _properties[c].Price);
                    }
                    return sb.ToString();
                }
            }
            #endregion

            #region Costruttori
            public CategorizableItem(string id, PriceDescriptor baseDescriptor, Dictionary<ICategory, PriceDescriptor> properties)
                : base(id, baseDescriptor)
            {
                #region Precondizioni
                if (properties == null)
                    throw new ArgumentException("properties null");
                #endregion
                _properties = properties;
            }

            public CategorizableItem(string id, PriceDescriptor baseDescriptor) :
                this(id, baseDescriptor, new Dictionary<ICategory, PriceDescriptor>())
            { }
            #endregion

            #region Metodi
            public bool ContainsCategory(ICategory category)
            {
                #region Precondizioni
                if (category == null)
                    throw new ArgumentException("catetory null");
                #endregion

                return Categories.Contains(category);
            }

            public bool ContainsSubCateogryOf(IGroupCategory category)
            {
                #region Precondizioni
                if (category == null)
                    throw new ArgumentException("catetory null");
                #endregion

                return (from cat in Categories
                        where cat.IsInside(category)
                        select cat).Any();
            }

            public string GetNameOf(ICategory category)
            {
                #region Precondizioni
                if (category == null)
                    throw new ArgumentException("category null");
                if (!_properties.ContainsKey(category))
                    throw new ArgumentException("category not present in the dictionary");
                #endregion
                return _properties[category].Name;
            }

            public string GetDescriptionOf(ICategory category)
            {
                #region Precondizioni
                if (category == null)
                    throw new ArgumentException("category null");
                if (!_properties.ContainsKey(category))
                    throw new ArgumentException("category not present in the dictionary");
                #endregion
                return _properties[category].Description;
            }

            public double GetPriceOf(ICategory category)
            {
                #region Precondizioni
                if (category == null)
                    throw new ArgumentException("category null");
                if (!_properties.ContainsKey(category))
                    throw new ArgumentException("category not present in the dictionary");
                #endregion
                return _properties[category].Price;
            }

            public override void Accept(IPrenotationVisitor visitor) 
                => visitor.Visit(this);
            #endregion
        }

        private static class CategorizableParser
        {
            public static CategorizableItem Parse(XmlNode itemToParse)
            {
                #region Precondizioni
                if (itemToParse == null)
                    throw new ArgumentNullException("itemToParse null");
                ICategoryCoordinator coor = CoordinatorManager.Instance.CoordinatorOfType<ICategoryCoordinator>();
                if (coor == null)
                    throw new ApplicationException("Non è disponibile un category coordinator");
                #endregion

                string id, name, description, categoryName;
                double price;
                Dictionary<ICategory, PriceDescriptor> properties = new Dictionary<ICategory, PriceDescriptor>();

                //Devono esserci almeno 4 elementi, id, name, description, price.
                //Possono esserci da 0 a N categorie. 

                try
                {
                    name = ParserUtils.RetrieveValues<String>(itemToParse, "Name")[0];
                    description = ParserUtils.RetrieveValues<String>(itemToParse, "Description")[0];
                    price = ParserUtils.RetrieveValues<double>(itemToParse, "Price")[0];
                    id = ParserUtils.RetrieveValues<String>(itemToParse, "Identifier")[0];
                }
                catch (ParsingException e)
                {
                    throw new ItemDescriptorException(e.Message);
                }

                PriceDescriptor priceDescriptor = new PriceDescriptor(name, description, price);

                XmlNodeList categoryNode = itemToParse.SelectNodes("Category");
                ICategory category;
                for (int i = 0; i < categoryNode.Count; i++)
                {
                    try
                    {
                        name = ParserUtils.RetrieveValues<String>(categoryNode[i], "Name")[0];
                        description = ParserUtils.RetrieveValues<String>(categoryNode[i], "Description")[0];
                        price = ParserUtils.RetrieveValues<double>(categoryNode[i], "Price")[0];
                        categoryName = ParserUtils.RetrieveValues<String>(categoryNode[i], "Path")[0];
                    }
                    catch (ParsingException e)
                    {
                        throw new ItemDescriptorException(e.Message);
                    }
                    category = coor.getCategoryByPath(categoryName);
                    if (category == null)
                        throw new ApplicationException("Non è stata trovata la categoria " + categoryName);

                    if (properties.ContainsKey(category))
                        throw new ItemDescriptorException("Una categoria è presente più di una volta");
                       
                    properties.Add(category, new PriceDescriptor(name, description, price));
                }                
                return new CategorizableItem(id, priceDescriptor, properties);
            }
        }
        #endregion

    }
}
