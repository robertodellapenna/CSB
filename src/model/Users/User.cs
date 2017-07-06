using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Users
{
    public abstract class User
    {
        #region Campi
        private readonly int _id;
        private readonly string _firstName;
        private readonly string _lastName;
        private string _username;
        private string _password;
        #endregion

        #region Costruttori
        /// <summary>
        /// costruttore classe use
        /// </summary>r
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public User(int id, string firstName, string lastName, string username, string password)
        {
            if(_id < 0)
                throw new ArgumentException("id invalid");
            _id = id;
            if (firstName == null || firstName.Trim().Length == 0)
                throw new ArgumentException("firstName null or empty");
            _firstName = firstName;
            if (lastName == null || lastName.Trim().Length == 0)
                throw new ArgumentException("lastName null or empty");
            _lastName = lastName;
            if (username == null || username.Trim().Length == 0)
                throw new ArgumentException("username null or empty");
            _username = username;
            if (password == null || password.Trim().Length == 0)
                throw new ArgumentException("password null or empty");
            _password = password;
        }
        #endregion
        #region Proprieta
        public int Id { get => _id; }
        public string FirstName { get => _firstName; }
        public string LastName { get => _lastName; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        #endregion
        #region Metodi
        public override string ToString()
        {
            return (_firstName + " " + _lastName + " " + _username + " " + _password);
        }
        #endregion

    }
}
