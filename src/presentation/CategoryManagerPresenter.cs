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

        public CategoryManagerPresenter( CategoryManagerView view)
        {
            view.AddButton.Click += AddHandler;
            _categoryTree = view.TreeView;
            ICoordinator coordinator = CoordinatorManager.Instance.Coordinator.GetCoordinatorOf(typeof(ICategoryCoordinator));
            if ( coordinator == null)
                throw new InvalidOperationException("Il coordinatore delle categorie non è disponibile");

            ICategoryCoordinator castedCoordinator = coordinator as ICategoryCoordinator;
            _root = castedCoordinator.RootCategory;
            castedCoordinator.CategoryChanged += CategoryChangedHandler;
            // Popolo la tree view all'avvio
            CategoryChangedHandler(this, EventArgs.Empty);
        }

        #region Metodi
        /// <summary>
        /// Popola ricorsavamente la tree view partendo da una categoria radice
        /// </summary>
        /// <param name="nodes">Nodo a cui aggiungere i nuovi nodi</param>
        /// <param name="category">Categoria radice con cui popolare i nodi</param>
        private void PopulateTreeView( TreeNodeCollection nodes, ICategory category)
        {
            TreeNode tn = new TreeNode(category.Name);
            tn.Tag = category;
            if(category is IGroupCategory)
                foreach (ICategory c in (category as IGroupCategory).Children)
                    PopulateTreeView(tn.Nodes, c);
            nodes.Add(tn);
        }

        #endregion 

        #region Handler
        /// <summary>
        /// Gestisce l'azione dell'add button permettendo l'inserimento di una
        /// nuova categoria
        /// </summary>
        private void AddHandler(Object sender, EventArgs eventArgs)
        {
            //MessageBox.Show(""+_categoryTree.SelectedNode);
            ICategory selectedNode = _categoryTree.SelectedNode.Tag as ICategory;
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

        private void ModifyHandler(Object sender, EventArgs eventArgs)
        {
            /* PROBABILMENTE NON VA FATTO */
        }

        /// <summary>
        /// Gestisce l'evento aggiornamento delle categorie ripopolando 
        /// la tree view
        /// </summary>
        public void CategoryChangedHandler(Object obj, EventArgs e)
        {
            _categoryTree.Nodes.Clear();
            PopulateTreeView(_categoryTree.Nodes, _root);
            _categoryTree.ExpandAll();
        }
        #endregion
    }
}
