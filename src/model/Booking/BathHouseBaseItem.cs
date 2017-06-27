using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Category;
using CSB_Project.src.model.Booking;

namespace CSB_Project.src.model.Booking
{
    public class BathHouseBaseItem : ICategoryItem, IBaseItem
    {

        #region Eventi
        #endregion

        #region Campi

        private readonly string _name;
        private readonly double _baseDailyPrice;
        private readonly Dictionary<ICategory, Tuple<string, double>> _categoryDictionary;
        #endregion

        #region Proprietà

        public string Name => _name; 

        public double BaseDailyPrice => _baseDailyPrice; 

        #endregion

        #region Costruttori
        public BathHouseBaseItem(string name, double baseDailyPrice)
        {
            if(name==null || name.Trim().Length==0)
                throw new ArgumentException("name null, only blank or empty");
            if(baseDailyPrice<0)
                throw new ArgumentException("negative base price");
            _name = name;
            _baseDailyPrice = baseDailyPrice;
            _categoryDictionary = new Dictionary<ICategory, Tuple<string, double>>();
        }
        #endregion

        #region Metodi

        private ICollection<ICategory> GetCategories() => _categoryDictionary.Keys;

        private ICollection<Tuple<string, double>> GetValues() => _categoryDictionary.Values;

        public bool ContainsCategory(ICategory category)
        {
            if (category == null)
                throw new ArgumentException("catetory null");
            if (!(category is IGroupCategory)) return ContainsStrictCategory(category);
            else foreach (ICategory c in GetCategories())
            {
                if ( c.Equals(category) || c.IsInside(category as IGroupCategory)) return true;
            }
            return false;
        }

        public bool ContainsStrictCategory(ICategory category)
        {
            if(category==null)
                throw new ArgumentException("catetory null");
            return _categoryDictionary.ContainsKey(category);
        }

        public void AddCategory(ICategory category, string valueDescription, double pricePercentual)
        {
            if (category == null)
                throw new ArgumentException("catetory null");
            if(valueDescription==null || valueDescription.Trim().Length==0)
                throw new ArgumentException("value description null, only blank or empty");
            if (pricePercentual <= 0)
                throw new ArgumentException("negative or zero price percentual");
            if (ContainsStrictCategory(category)) ModifyCategory(category, valueDescription, pricePercentual);
            else _categoryDictionary.Add(category, new Tuple<string, double>(valueDescription, pricePercentual));
        }

        public void ModifyCategory(ICategory category, string valueDescription, double pricePercentual)
        {
            if (category == null)
                throw new ArgumentException("catetory null");
            if(!ContainsStrictCategory(category))
                throw new ArgumentException("category not present in the dictionary");
            if (valueDescription == null || valueDescription.Trim().Length == 0)
                throw new ArgumentException("value description null, only blank or empty");
            if (pricePercentual <= 0)
                throw new ArgumentException("negative or zero price percentual");
            _categoryDictionary[category] = new Tuple<string, double>(valueDescription, pricePercentual);
        }

        public void RemoveCategory(ICategory category)
        {
            if (category == null)
                throw new ArgumentException("catetory null");
            if (!ContainsStrictCategory(category))
                throw new ArgumentException("category not present in the dictionary");
            _categoryDictionary.Remove(category);
        }

        public string GetDescriptionOf(ICategory category)
        {
            if (category == null)
                throw new ArgumentException("category null");
            if (!_categoryDictionary.ContainsKey(category))
                throw new ArgumentException("category not present in the dictionary");
            return _categoryDictionary[category].Item1;
        }

        public double GetPricePercentualOf(ICategory category)
        {
            if (category == null)
                throw new ArgumentException("category null");
            if (!_categoryDictionary.ContainsKey(category))
                throw new ArgumentException("category not present in the dictionary");
            return _categoryDictionary[category].Item2;
        }
        /// <summary>
        /// Calcola il prezzo giornaliero moltiplicando il daily price per l'apporto  
        /// di ogni valore associato ad una categoria (es. daily price 8 , categoria materiale telo -> prezzo 1.1 ,
        /// prezzo giornaliero totale 8.8)
        /// </summary>
        /// <returns></returns>
        public double getDailyPrice()
        {
            double dailyPrice = BaseDailyPrice;
            foreach(Tuple<string, double> value in GetValues()) dailyPrice *= value.Item2;
            return dailyPrice;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ICategoryItem))
                return false;
            BathHouseBaseItem other = obj as BathHouseBaseItem;

            if (Name != other.Name || BaseDailyPrice != other.BaseDailyPrice)
                return false;

            return (_categoryDictionary.Count == other._categoryDictionary.Count && !_categoryDictionary.Except(other._categoryDictionary).Any());
        }
        #endregion

        #region Handler
        #endregion

    }
}
