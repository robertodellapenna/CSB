using System;
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
        public int Days => (EndDate - StartDate).Days;
        #endregion

        #region Costruttori
        public DateRange(DateTime start, DateTime end)
        {
            #region Precondizioni
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
        /// <summary>
        /// Verifica se range si sovrappone con questo DateRange
        /// </summary>
        /// <param name="range">altra data con cui verificare la sovrapposizione</param>
        /// <returns>True se c'è almeno un giorno in comune altrimenti false</returns>
        public bool OverlapWith(DateRange range) => Contains(range) || ( StartDate <= range.EndDate && EndDate >= range.EndDate )
                                                     || ( StartDate <= range.StartDate && EndDate >= range.StartDate );

        public bool IsComplete(IEnumerable<DateRange> dateCollection)
        {
            #region Precondizioni
            if (dateCollection == null)
                throw new ArgumentNullException("dateCollection null");
            #endregion
    
            IEnumerable<DateRange> ordered = dateCollection.OrderBy(dr => dr.StartDate);
            if (ordered.Count() == 0 || ordered.ElementAt(0).StartDate != StartDate)
                return false;

            DateRange result = ordered.ElementAt(0);

            foreach(DateRange dr in ordered)
            {
                if (dr.StartDate > result.EndDate.AddDays(1))
                    return false;
                result = new DateRange(result.StartDate,
                    dr.EndDate > result.EndDate ? dr.EndDate : result.EndDate);
            }
            
            return StartDate == result.StartDate 
                && EndDate == result.EndDate;
        }

        public string DateStart()
        {
            return this.StartDate.Day + "/" + this.StartDate.Month + "/" + this.StartDate.Year;
        }

        public string DateEnd()
        {
            return this.EndDate.Day + "/" + this.EndDate.Month + "/" + this.EndDate.Year;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (! (obj is DateRange))
                return false;
            DateRange other = obj as DateRange;
            return other.StartDate == StartDate && other.EndDate == EndDate;
        }

        public override int GetHashCode()
        {
            return EndDate.GetHashCode() * StartDate.GetHashCode();
        }

        #endregion
    }
}
