using CSB_Project.src.model.Prenotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSB_Project.src.business
{
    public interface IPrenotationCoordinator : ICoordinator
    {

    }

    class PrenotationCoordinator : AbstractCoordinatorDecorator, ICoordinator
    {
        #region Eventi
        public event EventHandler PrenotationChanged;
        #endregion

        #region Campi
        private readonly List<Prenotation> _prenotations = new List<Prenotation>();
        #endregion

        #region Proprietà
        public IEnumerable<Prenotation> Prenotations => _prenotations.ToArray();
        #endregion

        #region Costruttori
        public PrenotationCoordinator(ICoordinator next) : base(next)
        {
        }

        #endregion

        #region Metodi
        protected override void init()
        {
            base.init();
            /* Cerco un file di configurazione delle structures nel fileSystem,
             * se lo trovo carico le structures contenute
             */

            /* Structures HardCoded */
            
        }

        public void AddPrenotation(Prenotation prenotation)
        {
            #region Precondizioni
            if (prenotation == null)
                throw new ArgumentNullException("structure null");
            #endregion
            
        }
        #endregion

        #region Handler
        private void OnPrenotationeChanged(Object sender, EventArgs args)
        {
            PrenotationChanged?.Invoke(sender, args);
        }
        #endregion
    }
}
