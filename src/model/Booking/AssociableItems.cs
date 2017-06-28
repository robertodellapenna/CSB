using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Booking
{
    public class AssociableItems
    {
        #region Eventi
        #endregion

        #region Campi
        private readonly IEnumerable<Tuple<IItem, int>> _tuples;
        #endregion

        #region Proprietà
        public IEnumerable<Tuple<IItem, int>> Tuples => _tuples;
        #endregion

        #region Costruttori
        public AssociableItems()
        {
            _tuples = new List<Tuple<IItem, int>>();
        }
        public AssociableItems(IEnumerable<Tuple<IItem, int>> tuples)
        {
            #region Precondizioni
            if (tuples == null)
                throw new ArgumentNullException("tuples null");
            #endregion
            _tuples = tuples;
        }
        #endregion

        #region Metodi
        #endregion

        #region Handler
        #endregion
    }
}
