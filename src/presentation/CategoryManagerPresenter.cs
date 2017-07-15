using CSB_Project.src.business;
using CSB_Project.src.model.Category;
using CSB_Project.src.presentation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSB_Project.src.presentation
{
    public class CategoryManagerPresenter
    {
        private TreeView _categoryTree;
        private IGroupCategory _root;

        public CategoryManagerPresenter( CategoryManagerView view, IGroupCategory root)
        {
            view.AddButton.Click += AddHandler;
            _categoryTree = view.TreeView;

            _root = root;
            root.Changed += CategoryChangedHandler;
            // Popolo la tree view all'avvio
            CategoryChangedHandler(this, EventArgs.Empty);
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
            ICategory selectedNode = _categoryTree.SelectedNode?.Tag as ICategory ?? null;
            if (selectedNode == null)
            {
                MessageBox.Show("Devi selezionare una categoria radice");
                return;
            }
            // Genero una finestra di dialogo per inserire il nome della categoria
            string catName = "";
            using ( StringDialog sd = new StringDialog("Inserisci il nome della categoria"))
            {
                if (sd.ShowDialog() == DialogResult.OK)
                    catName = sd.Response;
                else
                    return;
            }
            // Se il nodo selezionato non è un contenitore lo elimino e lo faccio diventare 
            // un contenitore
            if ( ! (selectedNode is IGroupCategory))
            {
                IGroupCategory parent = selectedNode.Parent;
                parent.RemoveChild(selectedNode);
                selectedNode = CategoryFactory.CreateGroup(selectedNode.Name, parent);
            }
            // Creo la categoria
            CategoryFactory.CreateCategory(catName, selectedNode as IGroupCategory);
        }

        /// <summary>
        /// Gestisce l'evento aggiornamento delle categorie ripopolando 
        /// la tree view
        /// </summary>
        public void CategoryChangedHandler(Object obj, EventArgs e)
        {
            _categoryTree.Nodes.Clear();
            _categoryTree.Nodes.Populate(_root);
            _categoryTree.ExpandAll();
        }
        #endregion
    }
}
