﻿using System;
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
        #region Campi
        private readonly DatePriceDescriptor _descriptor;
        #endregion

        #region Proprietà
        public string Name => _descriptor.Name;
        public string Description => _descriptor.Description;
        public double Price => _descriptor.Price;
        /// <summary>
        /// Periodo in cui il servizio risulta disponibile.
        /// </summary>
        public DateRange Availability => _descriptor.Range;
        #endregion

        #region Costruttori
        public BasicService(DatePriceDescriptor descriptor)
        {
            #region Precondizioni
            if (descriptor == null)
                throw new ArgumentException("descriptor null");
            #endregion
            _descriptor = descriptor;
        }
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
