using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Structure
{
    public class StructureArea
    {
        #region Eventi
        #endregion

        #region Campi
        private readonly BasicDescriptor _descriptor;
        private readonly IEnumerable<Sector> _sectors;
        #endregion

        #region Proprietà
        public string Name => _descriptor.Name;
        public string Description => _descriptor.Description;
        public IEnumerable<Sector> Sectors => _sectors;
        #endregion

        #region Costruttori
        public StructureArea(BasicDescriptor descriptor)
        {
            #region Precondizioni
            if (descriptor == null)
                throw new ArgumentException("descriptor null");
            #endregion
            _descriptor = descriptor;
            _sectors = new List<Sector>();
        }
        public StructureArea(BasicDescriptor descriptor, IEnumerable<Sector> sectors)
        {
            #region Precondizioni
            if (descriptor == null)
                throw new ArgumentException("descriptor null");
            if (sectors == null)
                throw new ArgumentException("areas null");
            #endregion
            _descriptor = descriptor;
            _sectors = sectors;
        }
        #endregion

        #region Metodi
        #endregion

        #region Handler
        #endregion
    }
}
