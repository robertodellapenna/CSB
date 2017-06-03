using CSB_Project.src.model.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSP_Project.src.business
{
    public class CategoryCoordinator : AbstractCoordinatorDecorator
    {

        #region Eventi
        #endregion

        #region Campi
        private IGroupCategory _root;
        private readonly ICoordinator _next;
        #endregion

        #region Proprietà
        public IGroupCategory RootCategory => _root;
        #endregion

        #region Costruttori
        public CategoryCoordinator(ICoordinator next) : base(next)
        {
        }
        #endregion

        #region Metodi
        protected override void init()
        {
            /* Cerco un file di configurazione delle categorie nel fileSystem,
             * se lo trovo carico le categorie contenute, altrimenti inizializzo
             * una nuova categoria 
             */
            _root = CategoryFactory.CreateRoot("ROOT");
        }
        #endregion

        #region Handler
        #endregion
    }
}
