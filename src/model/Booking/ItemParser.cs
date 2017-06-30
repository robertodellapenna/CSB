using CSB_Project.src.model.Category;
using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace CSB_Project.src.model.Booking
{
    public partial class ItemFactory
    {
        #region BasicItem e Parser
        private class BasicItem : AbstractItem
        {
            public BasicItem(PriceDescriptor priceDescriptor) : base(priceDescriptor) { }
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
                if (itemToParse.ChildNodes.Count != 4)
                    throw new ItemDescriptorException("Errore nell'elemento da parsare.\nMancano dei campi");

                XmlNodeList xnl = itemToParse.SelectNodes("Name");
                if ( xnl.Count != 1 ) 
                        throw new ItemDescriptorException("Molteplicità 'Name' non valida");
                string name = xnl.Item(0).InnerText;

                xnl = itemToParse.SelectNodes("Description");
                if (xnl.Count != 1)
                    throw new ItemDescriptorException("Molteplicità 'Description' non valida");
                string description = xnl.Item(0).InnerText;

                xnl = itemToParse.SelectNodes("Price");
                if (xnl.Count != 1)
                    throw new ItemDescriptorException("Molteplicità 'Price' non valida");
                double price;
                try
                {
                    price = Convert.ToDouble(xnl.Item(0).InnerText);
                }
                catch (Exception e)
                {
                    throw new ItemDescriptorException("Il prezzo non è nel formato giusto");
                }

                return new BasicItem(new PriceDescriptor(name, description, price));
            }
        }
        #endregion

        // DA RIVEDERE
        private class CategoryItem : AbstractItem
        {

            #region Eventi
            #endregion

            #region Campi
            private readonly PriceDescriptor _descriptor;
            private readonly Dictionary<ICategory, PriceDescriptor> _categoryDictionary;
            #endregion

            #region Proprietà
            public string Name => _descriptor.Name;
            public string Description => _descriptor.Description;
            public double BaseDailyPrice => _descriptor.Price;
            public double DailyPrice
            {
                get
                {
                    double dailyPrice = BaseDailyPrice;
                    foreach (PriceDescriptor desc in GetValues())
                        dailyPrice += desc.Price;
                    return dailyPrice;
                }
            }
            #endregion

            #region Costruttori
            public CategoryItem(PriceDescriptor descriptor) : base(descriptor)
            {
            }

            public CategoryItem(PriceDescriptor descriptor, Dictionary<ICategory, PriceDescriptor> dictionary) : this(descriptor)
            {

                #region Precondizioni
                if (dictionary == null)
                    throw new ArgumentException("dictionary null");
                #endregion
                _categoryDictionary = dictionary;

            }
            #endregion

            #region Metodi

            private ICollection<ICategory> GetCategories() => _categoryDictionary.Keys;

            private ICollection<PriceDescriptor> GetValues() => _categoryDictionary.Values;

            public bool ContainsCategory(ICategory category)
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
                return _categoryDictionary.ContainsKey(category);
            }

            public void AddCategory(ICategory category, PriceDescriptor descriptor)
            {
                #region Precondizioni
                if (category == null)
                    throw new ArgumentException("catetory null");
                if (descriptor == null)
                    throw new ArgumentException("descriptor null");
                #endregion
                if (ContainsStrictCategory(category)) ModifyCategory(category, descriptor);
                else _categoryDictionary.Add(category, descriptor);
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
                _categoryDictionary[category] = descriptor;
            }

            public void RemoveCategory(ICategory category)
            {
                #region Precondizioni
                if (category == null)
                    throw new ArgumentException("catetory null");
                if (!ContainsStrictCategory(category))
                    throw new ArgumentException("category not present in the dictionary");
                #endregion
                _categoryDictionary.Remove(category);
            }

            public string GetNameOf(ICategory category)
            {
                #region Precondizioni
                if (category == null)
                    throw new ArgumentException("category null");
                if (!_categoryDictionary.ContainsKey(category))
                    throw new ArgumentException("category not present in the dictionary");
                #endregion
                return _categoryDictionary[category].Name;
            }

            public string GetDescriptionOf(ICategory category)
            {
                #region Precondizioni
                if (category == null)
                    throw new ArgumentException("category null");
                if (!_categoryDictionary.ContainsKey(category))
                    throw new ArgumentException("category not present in the dictionary");
                #endregion
                return _categoryDictionary[category].Description;
            }

            public double GetPriceOf(ICategory category)
            {
                #region Precondizioni
                if (category == null)
                    throw new ArgumentException("category null");
                if (!_categoryDictionary.ContainsKey(category))
                    throw new ArgumentException("category not present in the dictionary");
                #endregion
                return _categoryDictionary[category].Price;
            }

            public override bool Equals(object obj)
            {
                #region Precondizioni
                if (obj == null || !(obj is CategoryItem))
                    return false;
                #endregion
                CategoryItem other = obj as CategoryItem;

                if (Name != other.Name)
                    return false;

                return (_categoryDictionary.Count == other._categoryDictionary.Count && !_categoryDictionary.Except(other._categoryDictionary).Any());
            }
            #endregion

            #region Handler
            #endregion

        }
    }
}
