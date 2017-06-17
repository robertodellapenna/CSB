using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Utils
{
    public class BasicDescriptor
    {
        #region Campi
        private string _name, _description;
        #endregion

        #region Proprietà
        public string Name => _name;
        public string Description => _description;
        #endregion

        #region Costruttori
        public BasicDescriptor(string name, string description)
        {
            #region Precondizioni
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name non valido, null o soli whitespace");
            if (String.IsNullOrWhiteSpace(description))
                throw new ArgumentException("description non valido, null o soli whitespace");
            #endregion
            _name = name;
            _description = description;
        }
#endregion
    }

    public class PriceDescriptor : BasicDescriptor
    {
        #region Campi
        private double _price;
        #endregion

        #region Proprietà
        public double Price => _price;
        #endregion

        #region Costruttori
        public PriceDescriptor(string name, string description, double price = 0) : base(name, description)
        {
            #region Precondizioni
            if (price < 0)
                throw new ArgumentException("price < 0");
            #endregion
            _price = price;
        }
        #endregion
    }

    public class DatePriceDescriptor : PriceDescriptor
    {
        #region Campi
        private DateRange _range;
        #endregion

        #region Proprietà
        public DateRange Range => _range;
        #endregion

        #region Costruttori
        public DatePriceDescriptor(string name, string description, DateRange range, double price = 0) : base(name, description, price)
        {
            _range = range;
        }

        public DatePriceDescriptor(string name, string description, DateTime start, DateTime end, double price = 0)
            : this(name, description, new DateRange(start, end), price) { }

        public DatePriceDescriptor(string name, string description, DateTime end, double price = 0)
            : this(name, description, new DateRange(DateTime.Now, end), price) { }
        #endregion
    }
}
