using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSB_Project.src.model.Utils;

namespace CSB_Project.src.model.Prenotation
{
    public class ItemPrenotation
    {
        #region Eventi
        #endregion
        #region Campi
        private readonly DateRange _rangeData;
        #endregion
        #region Proprieta
        public DateRange RangeData { get => _rangeData; }
        #endregion
        /// <summary>
        /// Elemento che ingloba una prenotazione di BookableItem con pulgIn
        /// </summary>
        /// <param name="rangeData"></param>
        #region Costruttori
        public ItemPrenotation(DateRange rangeData)
        {
            _rangeData = rangeData ?? throw new ArgumentException("range Data is not defined");
        }
        #endregion
        #region Metodi
        #endregion
        #region Handler
        #endregion
    }
}
