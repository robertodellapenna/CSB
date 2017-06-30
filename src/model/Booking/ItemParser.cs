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
                int price;
                try
                {
                    name = ParserUtils.RetrieveValues<String>(itemToParse, "Name")[0];
                    description = ParserUtils.RetrieveValues<String>(itemToParse, "Description")[0];
                    price = ParserUtils.RetrieveValues<int>(itemToParse, "Price")[0];
                    id = ParserUtils.RetrieveValues<String>(itemToParse, "Identifier")[0];
                }catch(ParsingException e)
                {
                    throw new ItemDescriptorException(e.Message);
                }

                return new BasicItem(id, new PriceDescriptor(name, description, price));
            }
        }
        #endregion

        #region CategorizableItem e Parser
        private class CategorizableItem : AbstractItem
        {
            public CategorizableItem(string id, PriceDescriptor descriptor) : base(id, descriptor)
            {
            }
        }
        #endregion

        // DA RIVEDERE
        private class CategoryItem : AbstractItem
        {

            #region Campi
            private readonly Dictionary<ICategory, PriceDescriptor> _categoryDictionary;
            #endregion

            #region Proprietà
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
            public CategoryItem(PriceDescriptor descriptor) : base("id", descriptor)
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

                if (Identifier != other.Identifier)
                    return false;

                return (_categoryDictionary.Count == other._categoryDictionary.Count && !_categoryDictionary.Except(other._categoryDictionary).Any());
            }
            #endregion

            #region Handler
            #endregion

        }
    }
}
