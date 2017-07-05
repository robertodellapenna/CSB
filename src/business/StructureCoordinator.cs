using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.business
{
    public interface IStructureCoordinator : ICoordinator
    {

    }

    public class StructureCoordinator : AbstractCoordinatorDecorator, IStructureCoordinator
    {
        #region Eventi
        #endregion

        #region Campi
        #endregion

        #region Proprietà
        #endregion

        #region Costruttori
        public StructureCoordinator(ICoordinator next) : base(next)
        {
        }
        #endregion

        #region Metodi

        #endregion

        #region Handler
        #endregion

    }
}
