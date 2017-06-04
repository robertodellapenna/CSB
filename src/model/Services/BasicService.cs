using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Utils;

namespace CSB_Project.src.model.Services
{
    /// <summary>
    /// Rappresenta un servizio immutabile che non è possibile modificare 
    /// (disattivare) successivamente.
    /// </summary>
    public class BasicService : IUsable
    {
        public static int NO_PRICE = 0;

        #region Campi
        private readonly string _name, _description;
        private double _price;
        private DateRange _availability;
        #endregion

        #region Proprietà
        public string Name => _name;
        public string Desciption => _description;
        public double Price => _price;
        /// <summary>
        /// Periodo in cui il servizio risulta disponibile.
        /// </summary>
        public DateRange Availability => _availability;
        #endregion

        #region Costruttori
        public BasicService(string name, string description, double price, DateRange Availability)
        {
            #region Precondizioni
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name non valido, null o soli whitespace");
            if (String.IsNullOrWhiteSpace(description))
                throw new ArgumentException("description non valido, null o soli whitespace");
            if (price < 0)
                throw new ArgumentException("price < 0");
            #endregion

            _name = name;
            _description = description;
            _price = price;
            _availability = Availability;
        }

        public BasicService(string name, string description, double price, DateTime startAvailability, DateTime endAvailability)
            : this(name, description, price, new DateRange(startAvailability, endAvailability)) { }

        public BasicService(string name, string description, DateTime startAvailability, DateTime endAvailability)
            : this(name, description, NO_PRICE, new DateRange(startAvailability, endAvailability)) { }

        public BasicService(string name, string description, DateRange availability)
            : this(name, description, NO_PRICE, availability) { }

        public BasicService(string name, string description, double price, DateTime endAvailability)
            : this(name, description, price, new DateRange(DateTime.Now, endAvailability)) { }

        public BasicService(string name, string description, DateTime endAvailability)
            : this(name, description, NO_PRICE, new DateRange(DateTime.Now, endAvailability)) { }

        public BasicService(string name, string description, double price)
            : this(name, description, price, DateTime.MaxValue) { }

        public BasicService(string name, string description)
            : this(name, description, DateTime.MaxValue) { }
        #endregion

        #region Metodi
        public bool IsActiveIn(DateTime when) => Availability.Contains(when);
        public bool IsActiveIn(DateRange when) => Availability.Contains(when);
        public double PriceFor(int days) {
            #region Precondizioni
            if (days < 0)
                throw new ArgumentException("days < 0");
            #endregion
            return Price * days;
        }

        public double PriceFor(DateTime start, DateTime end)
            => PriceFor( (end.Date - start.Date).Days );

        public double PriceFor(DateRange range) => PriceFor(range.Days); 
        #endregion
    }
}
