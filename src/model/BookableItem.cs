using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model
{
    class BookableItem : IBookableItem
    {

        private readonly string _name;
        private Dictionary<ICategory, Tuple<string, double>> _dictionary;
        private readonly double _baseDailyPrice;

        public double BaseDailyPrice
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double DailyPrice
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public ICollection<ICategory> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Tuple<string, double> GetValueCategory(ICategory category)
        {
            throw new NotImplementedException();
        }

        public ICollection<Tuple<string, double>> GetValues()
        {
            throw new NotImplementedException();
        }
    }
}
