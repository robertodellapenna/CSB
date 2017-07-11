using CSB_Project.src.business;
using CSB_Project.src.model.Booking;
using CSB_Project.src.model.Structure;
using CSB_Project.src.presentation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CSB_Project.src.presentation
{
    public class StructureManagerPresenter
    {
        private TreeView _structureTree;
        private IEnumerable<Structure> _structures;
        private IEnumerable<IBookableItem> _bookedItems;
        private IBookingCoordinator _bCoordinator;
        private IPrenotationCoordinator _pCoordinator;

        public StructureManagerPresenter(StructureManagerView view)
        {
            view.AddButton.Click += AddHandler;
            _structureTree = view.TreeView;

            IStructureCoordinator sCoordinator = CoordinatorManager.Instance.CoordinatorOfType<IStructureCoordinator>();
            if (sCoordinator == null)
                throw new InvalidOperationException("Il coordinatore delle strutture non è disponibile");

            _bCoordinator = CoordinatorManager.Instance.CoordinatorOfType<IBookingCoordinator>();
            if (_bCoordinator == null)
                throw new InvalidOperationException("Il coordinatore booking non è disponibile");

            _pCoordinator = CoordinatorManager.Instance.CoordinatorOfType<IPrenotationCoordinator>();
            if (_pCoordinator == null)
                throw new InvalidOperationException("Il coordinatore prenotation non è disponibile");
           
            _structures = sCoordinator.Structures;
            sCoordinator.StructureChanged += StructureChangedHandler;

            // Popolo la tree view all'avvio
            StructureChangedHandler(this, EventArgs.Empty);
        }

        #region Metodi
        #endregion 

        #region Handler
        /// <summary>
        /// Gestisce l'azione dell'add button permettendo l'inserimento di una
        /// nuova categoria
        /// </summary>
        private void AddHandler(Object sender, EventArgs eventArgs)
        {
            
        }

        private void ModifyHandler(Object sender, EventArgs eventArgs)
        {
            
        }

        /// <summary>
        /// Gestisce l'evento aggiornamento delle categorie ripopolando 
        /// la tree view
        /// </summary>
        public void StructureChangedHandler(Object obj, EventArgs e)
        {
            _structureTree.Nodes.Clear();
            _structureTree.Nodes.Populate(_structures, _bCoordinator, _pCoordinator);
            _structureTree.ExpandAll();
        }
        #endregion
    }
}

