using CSB_Project.src.business;
using CSB_Project.src.model.Structure;
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

        public StructureManagerPresenter(StructureManagerView view)
        {
            view.AddButton.Click += AddHandler;
            _structureTree = view.TreeView;
            IStructureCoordinator coordinator = CoordinatorManager.Instance.CoordinatorOfType<IStructureCoordinator>();
            if (coordinator == null)
                throw new InvalidOperationException("Il coordinatore delle strutture non è disponibile");

            _structures = coordinator.Structures;
            coordinator.StructureChanged += StructureChangedHandler;
            // Popolo la tree view all'avvio
            StructureChangedHandler(this, EventArgs.Empty);
        }

        #region Metodi
        /// <summary>
        /// Popola ricorsavamente la tree view partendo dalle strutture esistenti
        /// </summary>
        /// <param name="nodes">Nodo a cui aggiungere i nuovi nodi</param>
        /// <param name="category">Categoria radice con cui popolare i nodi</param>
        private void PopulateTreeView(TreeNodeCollection nodes, IEnumerable<Structure> structures)
        {
            foreach(Structure structure in structures)
            {
                TreeNode tnStructure = new TreeNode(structure.Name);
                tnStructure.Tag = structure;
                foreach(StructureArea area in structure.Areas)
                {
                    TreeNode tnArea = new TreeNode(area.Name);
                    tnArea.Tag = area;
                    foreach(Sector sector in area.Sectors)
                    {
                        TreeNode tnSector = new TreeNode(sector.Name);
                        tnSector.Tag = sector;
                        tnArea.Nodes.Add(tnSector);
                    }
                    tnStructure.Nodes.Add(tnArea);
                }
                nodes.Add(tnStructure);
            }
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
            //ICategory selectedNode = _categoryTree.SelectedNode.Tag as ICategory;
            //if (selectedNode == null)
            //{
            //    MessageBox.Show("Devi selezionare una categoria radice");
            //    return;
            //}
            // Genero una finestra di dialogo per inserire il nome della categoria
            //string catName = "";
            //using (StringDialog sd = new StringDialog("Inserisci il nome della categoria"))
            //{
            //    if (sd.ShowDialog() == DialogResult.OK)
            //        catName = sd.Response;
            //    else
            //        return;
            //}
            // Se il nodo selezionato non è un contenitore lo elimino e lo faccio diventare 
            // un contenitore
            //if (!(selectedNode is IGroupCategory))
            //{
            //    IGroupCategory parent = selectedNode.Parent;
            //    parent.RemoveChild(selectedNode);
            //    selectedNode = CategoryFactory.CreateGroup(selectedNode.Name, parent);
            //}
            // Creo la categoria
            //CategoryFactory.CreateCategory(catName, selectedNode as IGroupCategory);
        }

        private void ModifyHandler(Object sender, EventArgs eventArgs)
        {
            /* PROBABILMENTE NON VA FATTO */
        }

        /// <summary>
        /// Gestisce l'evento aggiornamento delle categorie ripopolando 
        /// la tree view
        /// </summary>
        public void StructureChangedHandler(Object obj, EventArgs e)
        {
            _structureTree.Nodes.Clear();
            PopulateTreeView(_structureTree.Nodes, _structures);
            _structureTree.ExpandAll();
        }
        #endregion
    }
}

