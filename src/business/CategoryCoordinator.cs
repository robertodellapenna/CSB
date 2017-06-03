using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSP_Project.src.business
{
    class CategoryCoordinator : ICoordinatorDecorator
    {

        #region Eventi
        public event EventHandler Changed;
        #endregion

        #region Campi
        #endregion

        #region Proprietà
        public ICoordinator Coordinator => throw new NotImplementedException();
        #endregion

        #region Costruttori
        public CategoryCoordinator()
        {
            init();
        }
        #endregion

        #region Metodi
        private void init()
        {
        }

        public void Reload()
        {
            init();
        }

        public bool ContainsCoordinator(Type type)
        {
            throw new NotImplementedException();
        }

        public ICoordinator getCoordinatorOf(Type type)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Handler
        #endregion
    }
}
