using CSB_Project.src.model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.model.Structure
{
    public class Structure
    {
        #region Eventi
        #endregion

        #region Campi
        private readonly BasicDescriptor _descriptor;
        private readonly IEnumerable<StructureArea> _areas;
        #endregion

        #region Proprietà
        public string Name => _descriptor.Name;
        public string Description => _descriptor.Description;
        public IEnumerable<StructureArea> Areas => _areas;
        #endregion

        #region Costruttori
        public Structure(BasicDescriptor descriptor)
        {
            #region Precondizioni
            if (descriptor == null)
                throw new ArgumentException("descriptor null");
            #endregion
            _descriptor = descriptor;
            _areas = new List<StructureArea>();
        }
        public Structure(BasicDescriptor descriptor, IEnumerable<StructureArea> areas)
        {
            #region Precondizioni
            if (descriptor == null)
                throw new ArgumentException("descriptor null");
            if (areas == null)
                throw new ArgumentException("areas null");
            #endregion
            _descriptor = descriptor;
            _areas = areas;
        }
        #endregion

        #region Metodi
        #endregion

        #region Handler
        #endregion
    }
}
