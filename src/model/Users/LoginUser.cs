using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Users
{
    public class LoginUser : ILoginUser
    {
        #region Campi
        private IUser _baseUser;
        private AuthorizationLevel _authorizationLevel;
        private readonly string _username, _passwordHash;
        #endregion
        
        #region Proprieta
        public AuthorizationLevel AuthorizationLevel { get => _authorizationLevel; set => _authorizationLevel = value; }
        public string Username => _username;
        public string PasswordHash => _passwordHash;
        public string FirstName => _baseUser.FirstName;
        public string LastName => _baseUser.LastName;
        #endregion

        #region Costruttori
        public LoginUser(IUser baseUser, string username, string passwordHash, AuthorizationLevel authorizationLevel)
        {
            #region Precondizioni
            if (baseUser == null)
                throw new ArgumentNullException("baseUser null");
            if (String.IsNullOrWhiteSpace(username))
                throw new ArgumentException("username null or blank");
            if (String.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("passwor null or blank");
            #endregion 
            _baseUser = baseUser;
            _username = username;
            _passwordHash = passwordHash;
            _authorizationLevel = authorizationLevel;
        }

        public LoginUser(string firstName, string lastName, string username, string passwordHash, AuthorizationLevel authorizationLevel)
            : this(new User(firstName, lastName), username, passwordHash, authorizationLevel) { }
        #endregion

        #region Metodi
        public override string ToString()
        {
            return base.ToString() + AuthorizationLevel;
        }
        #endregion
    }

    public class CustomerLoginUser : LoginUser, ICustomer
    {
        #region Campi
        private string _fiscalCode;
        private DateTime _birthDate;
        #endregion

        #region Proprieta
        public string FiscalCode => _fiscalCode;
        public DateTime BirthDate => _birthDate;
        #endregion

        #region Costruttori
        public CustomerLoginUser(string firstName, string lastName, string username, string passwordHash, AuthorizationLevel authorizationLevel, string fiscalCode, DateTime birthDate)
           : base(firstName, lastName, username, passwordHash, authorizationLevel) {
            #region Precondizioni
            if (authorizationLevel != AuthorizationLevel.CUSTOMER)
                throw new ArgumentNullException("not a customer");
            if (String.IsNullOrWhiteSpace(fiscalCode))
                throw new ArgumentException("fiscal null or blank");
            if (birthDate > DateTime.Now)
                throw new ArgumentException("birthdate non valida");
            #endregion 
            _fiscalCode = fiscalCode;
            _birthDate = birthDate;
        }

        public CustomerLoginUser(ILoginUser baseUser, string fiscalCode, DateTime birthDate)
            : base(Preconditions.CheckNotNull(baseUser, "baseUser null").FirstName, baseUser.LastName, baseUser.Username, baseUser.PasswordHash, baseUser.AuthorizationLevel) { }

        public CustomerLoginUser(ICustomer baseUser, string username, string passwordHash, AuthorizationLevel authorizationLevel)
            : this(Preconditions.CheckNotNull(baseUser, "baseUser null").FirstName, baseUser.LastName, username, passwordHash, authorizationLevel, baseUser.FiscalCode, baseUser.BirthDate) { }

        public CustomerLoginUser(IUser baseUser, string username, string passwordHash, AuthorizationLevel authorizationLevel, string fiscalCode, DateTime birthDate)
            : this(Preconditions.CheckNotNull(baseUser, "baseUser null").FirstName, baseUser.LastName, username, passwordHash, authorizationLevel, fiscalCode, birthDate) { }

        #endregion

        #region Metodi
        public override string ToString()
        {
            return base.ToString() + AuthorizationLevel;
        }
        #endregion
    }
}
