using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Category;
using CSP_Project.src.model.Booking;

namespace CSB_Project.src.model.Booking
{
    class BathHouse_BaseItem : ICategoryBaseItem
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

        public Dictionary<ICategory, Tuple<string, double>> CategoryDictionary => _categoryDictionary; 


        #endregion

        #region Costruttori
        public BathHouse_BaseItem(string name, double baseDailyPrice)
        {
            if(name==null || name.Trim().Length==0)
                throw new ArgumentException("name null, only blank or empty");
            if(baseDailyPrice<0)
                throw new ArgumentException("negative base price");
            _name = name;
            _baseDailyPrice = baseDailyPrice;
        }
        #endregion

        #region Metodi

        private ICollection<ICategory> GetCategories() => CategoryDictionary.Keys;

        private ICollection<Tuple<string, double>> GetValues() => CategoryDictionary.Values;

        public bool HasCategory(ICategory category)
        {
            if (category == null)
                throw new ArgumentException("catetory null");
            //foreach(ICategory c in GetCategories){
            //    if (c.IsSubCategoryOf(category)) return true;
            //}
            return HasStrictCategory(category);
        }

        public bool HasStrictCategory(ICategory category)
        {
            if(category==null)
                throw new ArgumentException("catetory null");
            return CategoryDictionary.ContainsKey(category);
        }

        public void AddCategory(ICategory category, string valueDescription, double pricePercentual)
        {
            if (category == null)
                throw new ArgumentException("catetory null");
            if(valueDescription==null || valueDescription.Trim().Length==0)
                throw new ArgumentException("value description null, only blank or empty");
            if (pricePercentual <= 0)
                throw new ArgumentException("negative or zero price percentual");
            if (HasStrictCategory(category)) ModifyCategory(category, valueDescription, pricePercentual);
            else CategoryDictionary.Add(category, new Tuple<string, double>(valueDescription, pricePercentual));
        }

        public void ModifyCategory(ICategory category, string valueDescription, double pricePercentual)
        {
            if (category == null)
                throw new ArgumentException("catetory null");
            if(!HasStrictCategory(category))
                throw new ArgumentException("category not present in the dictionary");
            if (valueDescription == null || valueDescription.Trim().Length == 0)
                throw new ArgumentException("value description null, only blank or empty");
            if (pricePercentual <= 0)
                throw new ArgumentException("negative or zero price percentual");
            CategoryDictionary[category] = new Tuple<string, double>(valueDescription, pricePercentual);
        }

        public void RemoveCategory(ICategory category)
        {
            if (category == null)
                throw new ArgumentException("catetory null");
            if (!HasStrictCategory(category))
                throw new ArgumentException("category not present in the dictionary");
            CategoryDictionary.Remove(category);
        }

        public Tuple<string, double> getValueOfCategory(ICategory category)
        {
            if(category==null)
                throw new ArgumentException("category null");
            if (!CategoryDictionary.ContainsKey(category))
                throw new ArgumentException("category not present in the dictionary");
            return CategoryDictionary[category];
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
            if (obj == null || !(obj is ICategoryBaseItem))
                return false;
            ICategoryBaseItem other = obj as ICategoryBaseItem;

            if (Name != other.Name || BaseDailyPrice != other.BaseDailyPrice)
                return false;

            return (CategoryDictionary.Count == other.CategoryDictionary.Count && !CategoryDictionary.Except(other.CategoryDictionary).Any());
        }

        #endregion

        #region Handler
        #endregion

    }
}
