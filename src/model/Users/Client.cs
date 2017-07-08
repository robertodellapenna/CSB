using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Users
{
    public class Client : User, IClient
    {
        #region Eventi
        #endregion
        #region Campi
        private readonly string _fiscalCode;
        private readonly DateTime _birthDate;
        private static string pattern = "dd/MM/yy";
        #endregion
        #region Proprieta
        public string FiscalCode { get => _fiscalCode; }

        public DateTime BirthDate { get => _birthDate; }
        #endregion
        #region Costruttori
        /// <summary>
        /// costruttore client
        /// </summary>
        /// <param name="firstName">firstName</param>
        /// <param name="lastName">lastName</param>
        /// <param name="fiscalCode">fiscal Code</param>
        /// <param name="birthDate">Birthday date</param>
        public Client(int id, string firstName, string lastName, string fiscalCode, string birthDate) 
        : base (id, firstName, lastName)
        {
            DateTime date;
            try
            {
                date = DateTime.ParseExact(birthDate, pattern, CultureInfo.InvariantCulture);
            }
            catch
            {
                throw new ArgumentException("formato data errato");
            }
            _fiscalCode = fiscalCode;
            _birthDate = date;
        }
        #endregion
        #region Metodi
        public override string ToString()
        {
            return (base.ToString() + " " + _fiscalCode + " " + _birthDate.ToString());
        }
        #endregion
        #region Handler
        #endregion
    }
}
