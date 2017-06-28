using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Booking
{
    public class Sector
    {
        #region Eventi
        #endregion

        #region Campi
        private readonly long _id;
        private readonly int _capacity;
        #endregion

        #region Proprietà
        public long Id => _id;
        public int Capacity => _capacity;
        #endregion

        #region Costruttori
        public Sector(long id, int capacity)
        {
            #region Precondizioni
            if (capacity <0)
                throw new ArgumentException("capacity < 0");
            #endregion
            _id = id;
            _capacity = capacity;
        }
        #endregion

        #region Metodi
        #endregion

        #region Handler
        #endregion
    }
}
