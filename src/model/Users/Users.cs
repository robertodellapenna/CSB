using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Users
{
    public class User : IUser
    {
        #region Campi
        private readonly string _firstName;
        private readonly string _lastName;
        #endregion

        #region Costruttori
        /// <summary>
        /// costruttore classe user
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public User(string firstName, string lastName)
        {
            if (String.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("firstName null or empty");
            _firstName = firstName;
            if (String.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("lastName null or empty");
            _lastName = lastName;
        }
        #endregion
        #region Proprieta
        public string FirstName => _firstName;
        public string LastName => _lastName;
        public virtual string DisplayInfo => _firstName + " " + _lastName;
        #endregion
        #region Metodi
        public override string ToString()
        {
            return (_firstName + " " + _lastName);
        }
        #endregion

    }

    public class Customer : User, ICustomer
    {
        #region Campi
        private readonly string _fiscalCode;
        private readonly DateTime _birthDate;
        private static string pattern = "dd/MM/yy";
        #endregion
        #region Proprieta
        public string FiscalCode => _fiscalCode;
        public override string DisplayInfo => base.DisplayInfo + " " + FiscalCode;
        public DateTime BirthDate => _birthDate;
        #endregion
        #region Costruttori
        /// <summary>
        /// costruttore client
        /// </summary>
        /// <param name="firstName">firstName</param>
        /// <param name="lastName">lastName</param>
        /// <param name="fiscalCode">fiscal Code</param>
        /// <param name="birthDate">Birthday date</param>
        public Customer(string firstName, string lastName, string fiscalCode, string birthDate)
        : base(firstName, lastName)
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
    }
}
