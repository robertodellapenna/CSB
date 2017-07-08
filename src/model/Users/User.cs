using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Users
{
    public class User : IUser
    {
        #region Campi
        private readonly int _id;
        private readonly string _firstName;
        private readonly string _lastName;
        #endregion

        #region Costruttori
        /// <summary>
        /// costruttore classe user
        /// </summary>r
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public User(int id, string firstName, string lastName)
        {
            if(_id < 0)
                throw new ArgumentException("id invalid");
            _id = id;
            if (String.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("firstName null or empty");
            _firstName = firstName;
            if (String.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("lastName null or empty");
            _lastName = lastName;
        }
        #endregion
        #region Proprieta
        public int Id { get => _id; }
        public string FirstName { get => _firstName; }
        public string LastName { get => _lastName; }
        #endregion
        #region Metodi
        public override string ToString()
        {
            return (_firstName + " " + _lastName);
        }
        #endregion

    }
}
