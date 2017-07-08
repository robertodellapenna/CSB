using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Users
{
    public class Staff : User, IStaff
    {
        #region Eventi
        #endregion
        #region Campi
        private int _authorizationLevel;
        #endregion
        #region Proprieta
        public int AuthorizationLevel { get => _authorizationLevel; set => _authorizationLevel = value; }
        #endregion
        #region Costruttori
        public Staff(int id, string firstName, string lastName, int levelOfAuthorization)
        : base(id, firstName, lastName)
        {
            if (levelOfAuthorization < 0)
                throw new ArgumentException("level of authorization inconsistent");
            _authorizationLevel = levelOfAuthorization;
        }
        #endregion
        #region Metodi
        public override string ToString()
        {
            return base.ToString() + AuthorizationLevel;
        }
        #endregion
        #region Handler
        #endregion

    }


}
