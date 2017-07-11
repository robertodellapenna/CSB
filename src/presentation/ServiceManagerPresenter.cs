using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSB_Project.src.model.Services;
using CSB_Project.src.business;
using CSB_Project.src.presentation.Utils;
using CSB_Project.src.model.Utils;
using System.Globalization;

namespace CSB_Project.src.presentation
{
    class ServiceManagerPresenter
    {
        private ListView _serviceList;
        private IEnumerable<IUsable> _services;
        IServiceCoordinator coordinator;

        public ServiceManagerPresenter(ServiceManagerView view)
        {
            view.AddButton.Click += AddHandler;
            _serviceList = view.ListView;
            coordinator = CoordinatorManager.Instance.CoordinatorOfType<IServiceCoordinator>();
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
            //Genero una finestra di dialogo per inserire il parametri della servizio
            string serviceName = "";
            string serviceDescription = "";
            string servicePrice = "";
            DateRange range;
            using (ServiceDialog sd = new ServiceDialog("Inserire parametri servizio"))
            {
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    serviceName = sd.NameText;
                    serviceDescription = sd.Description;
                    servicePrice = sd.Price.ToString();
                    range = new DateRange(sd.Start, sd.End);
                }
                else
                    return;
            }
            double price = Double.Parse(servicePrice);
            coordinator.AddService(new BasicService(new DatePriceDescriptor(serviceName, serviceDescription, range, price)));
            _services = coordinator.Services;
            ServiceChangedHandler(this, EventArgs.Empty);
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
                array[3] = service.Availability.DateStart() + " - " + service.Availability.DateEnd();
                items = new ListViewItem(array);
                _serviceList.Items.Add(items);
            }
            _serviceList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            _serviceList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            #endregion
        }
    }
}
