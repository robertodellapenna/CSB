﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Users
{
    public class Staff : User
    {
        #region Eventi
        #endregion
        #region Campi
        private int _levelOfAuthorization;
        #endregion
        #region Proprieta
        public int LevelOfAuthorization { get => _levelOfAuthorization; set => _levelOfAuthorization = value; }
        #endregion
        #region Costruttori
        public Staff(int id, string firstName, string lastName, string username, string password, int levelOfAuthorization)
        : base(id, firstName, lastName, username, password)
        {
            if (levelOfAuthorization < 0)
                throw new ArgumentException("level of authorization inconsistent");
            _levelOfAuthorization = levelOfAuthorization;
        }
        #endregion
        #region Metodi
        public override string ToString()
        {
            return base.ToString() + this.LevelOfAuthorization;
        }
        #endregion
        #region Handler
        #endregion

    }


}
