using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSB_Project.src.model.Services;
using CSB_Project.src.business;

namespace CSB_Project.src.presentation
{
    class ServiceManagerPresenter
    {
        private ListView _serviceList;
        private IEnumerable<IUsable> _services;

        public ServiceManagerPresenter(ServiceManagerView view)
        {
            view.AddButton.Click += AddHandler;
            _serviceList = view.ListView;
            IServiceCoordinator coordinator = CoordinatorManager.Instance.CoordinatorOfType<IServiceCoordinator>();
            if (coordinator == null)
                throw new InvalidOperationException("Il coordinatore dei servizi non è disponibile");

            _services = coordinator.Services;
            coordinator.ServiceChanged += ServiceChangedHandler;
            // Popolo la list view all'avvio
            ServiceChangedHandler(this, EventArgs.Empty);
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
        /// Gestisce l'evento aggiornamento dei servizi ripopolando 
        /// la list view
        /// </summary>
        public void ServiceChangedHandler(Object obj, EventArgs e)
        {
            _serviceList.Items.Clear();
            foreach (IUsable service in _services)
            {
                string[] array = new string[4];
                ListViewItem items;
                array[0] = service.Name;
                array[1] = service.Description;
                array[2] = service.Price + "";
                array[3] = service.Availability.StartDate.ToString();
                items = new ListViewItem(array);
                _serviceList.Items.Add(items);
            }
            #endregion
        }
    }
}
