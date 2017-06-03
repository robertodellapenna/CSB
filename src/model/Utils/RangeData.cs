﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Utils
{
    /// <summary>
    /// Oggetto immutabile che rappresenta un range di date.
    /// L'oggeto si costruisce indicando la data di inizio, l'ora non 
    /// viene presa in considerazione e un numero di giorno. Il range di date
    /// include la data di partenza più i giorni indicati in duration.
    /// Ad esempio un DateRange(18/10/15, 1) include i giorni 18/10/15 e 
    /// 19/10/15.
    /// </summary>
    public class DateRange
    {
        #region Campi
        private DateTime _start;
        private DateTime _end;
        #endregion

        #region Proprietà
        public DateTime StartDate => _start;
        public DateTime EndDate => _end;
        #endregion

        #region Costruttori
        public DateRange(DateTime start, DateTime end)
        {
            #region Precondizioni
            if (start == null)
                throw new ArgumentNullException("start date null");
            if (end == null)
                throw new ArgumentNullException("end date null");
            if (end < start)
                throw new ArgumentException("end < start");
            #endregion
            _start = start.Date;
            _end = end.Date;
        }

        /// <summary>
        /// Crea una duration partenda da start e includendo i giorni indicati 
        /// in duration. Ad esempio un DateRange(18/10/15, 1) include i giorni 
        /// 18/10/15 e 19/10/15.
        /// </summary>
        /// <param name="start">Giorno di inizio</param>
        /// <param name="duration">Giorni ulteriori</param>
        public DateRange(DateTime start, int duration) : this(start, start.AddDays(duration)) { }

        /// <summary>
        /// Usa DateTime.Now come giorno di partenza
        /// </summary>
        /// <param name="duration">Giorni ulteriori compresi nel range</param>
        public DateRange(int duration) : this(DateTime.Now, duration) { }
        #endregion

        #region Metodi
        /// <summary>
        /// Verifica se il giorno indicato è compreso tra inizio e fine. 
        /// NOTA: Non tiene conto dell'ora.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool Contains(DateTime date) => StartDate <= date.Date && date.Date <= EndDate;
        public bool Contains(DateRange range) => StartDate <= range.StartDate && range.EndDate <= EndDate; 
        #endregion
    }
}