using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Structure
{
    public class Sector
    {
        #region Eventi
        #endregion

        #region Campi
        private readonly BasicDescriptor _descriptor;
        private readonly int _numRows;
        private readonly int _numColumns;
        #endregion

        #region Proprietà
        public string Name => _descriptor.Name;
        public string Description => _descriptor.Description;
        public int Rows => _numRows;
        public int Columns => _numColumns;
        #endregion

        #region Costruttori
        public Sector(BasicDescriptor descriptor,int numRows, int numColumns)
        {
            #region Precondizioni
            if (numRows < 0)
                throw new ArgumentException("invalid number of rows");
            if (numColumns < 0)
                throw new ArgumentException("invalid number of columns");
            #endregion
            _descriptor = descriptor;
            _numRows = numRows;
            _numColumns = numColumns;
        }
        #endregion

        #region Metodi
        #endregion

        #region Handler
        #endregion
    }
}
