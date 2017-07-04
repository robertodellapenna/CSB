using CSB_Project.src.business;
using CSB_Project.src.model.Category;
using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace CSB_Project.src.model.Item
{
    public partial class ItemFactory
    {
        #region BasicItem e Parser
        private class BasicItem : AbstractItem
        {
            public BasicItem(string id, PriceDescriptor priceDescriptor) : base(id, priceDescriptor) { }
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
            public IEnumerable<ICategory> Categories => _properties.Keys;
            public IEnumerable<PriceDescriptor> Values => _properties.Values;
            public IEnumerable<KeyValuePair<ICategory, PriceDescriptor>> Properties
            {
                get {
                    KeyValuePair<ICategory, PriceDescriptor>[] copy = new KeyValuePair<ICategory, PriceDescriptor>[_properties.Count];
                    _properties.CopyTo(copy, 0);
                    return copy;
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



            /*
            public bool ContainsCategory(ICategory category, bool parentSearch = false)
            {
                #region Precondizioni
                if (category == null)
                    throw new ArgumentException("catetory null");
                #endregion
                if (!(category is IGroupCategory)) return ContainsStrictCategory(category);
                else foreach (ICategory c in GetCategories())
                    {
                        if (c.Equals(category) || c.IsInside(category as IGroupCategory)) return true;
                    }
                return false;
            }

            public bool ContainsStrictCategory(ICategory category)
            {
                #region Precondizioni
                if (category == null)
                    throw new ArgumentException("catetory null");
                #endregion
                return _properties.ContainsKey(category);
            }
            */

            /*
            public void AddCategory(ICategory category, PriceDescriptor descriptor)
            {
                #region Precondizioni
                if (category == null)
                    throw new ArgumentException("catetory null");
                if (descriptor == null)
                    throw new ArgumentException("descriptor null");
                #endregion
                if (ContainsStrictCategory(category)) ModifyCategory(category, descriptor);
                else _properties.Add(category, descriptor);
            }

            public void ModifyCategory(ICategory category, PriceDescriptor descriptor)
            {
                #region Precondizioni
                if (category == null)
                    throw new ArgumentException("catetory null");
                if (!ContainsStrictCategory(category))
                    throw new ArgumentException("category not present in the dictionary");
                if (descriptor == null)
                    throw new ArgumentException("descriptor null, only blank or empty");
                #endregion
                _properties[category] = descriptor;
            }

            public void RemoveCategory(ICategory category)
            {
                #region Precondizioni
                if (category == null)
                    throw new ArgumentException("catetory null");
                if (!ContainsStrictCategory(category))
                    throw new ArgumentException("category not present in the dictionary");
                #endregion
                _properties.Remove(category);
            }
            */

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
