﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model
{
    class BookableItem : IBookableItem
    {

        private readonly string _name;
        private readonly double _basePrice;
        private readonly 
        private readonly ISet<Property> _properties;

        

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public double DailyPrice
        {
            get
            {
                return _dailyPrice;
            }
        }

        public double BaseDailyPrice
        {
            get
            {
                return 
            }
        }

        public ICollection<Property> Properties
        {
            get
            {
                return _properties;
            }
        }

        /*
        public virtual void GetProperties(ref Dictionary<string, string> properties)
        {
            if (properties == null)
                throw new ArgumentNullException("Elemento Prenotabile - Properties Map null");
            if (properties.ContainsKey(PropertyName))
                throw new InvalidOperationException("Property alredy exists");
            properties.Add(PropertyName, PropertyValue);
        }


        public string FindProperty(string property)
        {
            return PropertyName == property ? PropertyValue : null;
        }
        */

    }
}
