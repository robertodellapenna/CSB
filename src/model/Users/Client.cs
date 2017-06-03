using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Users
{
    class Client : User
    {
        #region Eventi
        #endregion
        #region Campi
        private readonly string _fiscalCode;
        private readonly DateTime _birthDate;
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
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <param name="fiscalCode">fiscl Code</param>
        /// <param name="birthDate">Birthday date</param>
        public Client(string firstName, string lastName, string username, string password, string fiscalCode, string birthDate) 
        : base (firstName, lastName, username, password)
        {
            _fiscalCode = fiscalCode;
            _birthDate = DateTime.Parse(birthDate, System.Globalization.CultureInfo.InvariantCulture);
        }
        #endregion
        #region Metodi
        #endregion
        #region Handler
        #endregion
    }
}
