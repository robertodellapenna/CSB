using CSB_Project.src.model.Category;
using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Booking
{
    public class ItemFactory
    {
        private static readonly Dictionary<string, IItem> _items =
           new Dictionary<string, IItem>();

        public static IItem GetCategoryItem(string name)
        {
            #region Precondizioni
            if (name == null || name.Trim().Length == 0)
                throw new ArgumentException("name null, empty or blank");
            #endregion
            if (!_items.ContainsKey(name))
            {
                AddItem(name, CreateItem(name));
            }
            
            return _items[name];
        }

        public static IEnumerable<IItem> GetCategoryItems()
        {
            return _items.Values;
        }

        private static CategoryItem CreateItem(String name)
        {
            //maxiswitch sui vari item
            return null;
        }

        private static void AddItem(String name, IItem item)
        {
            #region Precondizioni
            if (name == null || name.Trim().Length == 0)
                throw new ArgumentException("name null, empty or blank");
            if (item == null)
                throw new ArgumentException("item null");
            if (_items.ContainsKey(name))
                throw new Exception("plugin item already exists");
            #endregion
            _items.Add(name, item);


        }

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

                if (Name != other.Name )
                    return false;

                return (_categoryDictionary.Count == other._categoryDictionary.Count && !_categoryDictionary.Except(other._categoryDictionary).Any());
            }
            #endregion

            #region Handler
            #endregion

        }

    }
}
