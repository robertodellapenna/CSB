using CSB_Project.src.business;
using CSB_Project.src.model.Category;
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

        public CategoryManagerPresenter( CategoryManagerView view)
        {
            view.AddButton.Click += addHandler;
            _categoryTree = view.TreeView;
            ICoordinator coordinator = CoordinatorManager.Instance.Coordinator.GetCoordinatorOf(typeof(ICategoryCoordinator));
            if ( coordinator == null)
                throw new InvalidOperationException("Il coordinatore delle categorie non è disponibile");
            IGroupCategory root = (coordinator as ICategoryCoordinator).RootCategory;
            
            PopulateTreeView(_categoryTree.Nodes, root);
            _categoryTree.ExpandAll();
        }

        private void PopulateTreeView( TreeNodeCollection nodes, ICategory category)
        {
            TreeNode tn = new TreeNode(category.Name);
            tn.Tag = category;
            if(category is IGroupCategory)
                foreach (ICategory c in (category as IGroupCategory).Children)
                    PopulateTreeView(tn.Nodes, c);
            nodes.Add(tn);
        }

        private void addHandler( Object sender, EventArgs eventArgs)
        {
            MessageBox.Show("Stai selezionando " + (_categoryTree.SelectedNode.Tag as ICategory).Path);           
        }
    }
}
