using CSB_Project.src.model.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSP_Project.src.business
{
    class SimpleCoordinator : ICoordinator
    {

        #region Eventi
        public event EventHandler Changed;
        #endregion

        #region Campi
        #endregion

        #region Proprietà
        #endregion

        #region Costruttori
        public SimpleCoordinator()
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
        #endregion

        #region Handler
        #endregion







    }
}
