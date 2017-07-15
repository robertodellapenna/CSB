using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSB_Project.src.business;
using CSB_Project.src.model.Services;
using CSB_Project.src.model.Utils;
using static System.Windows.Forms.ListView;

namespace CSB_Project.src.presentation.Utils
{
    public partial class SelectionService : Form
    {
        private bool _emptyResponse;
        private IServiceCoordinator coordinator;
        public SelectedListViewItemCollection servizi => _view.SelectedItems;
        private ListView _serviceList;
        private DateRange _range;
        public DateRange Range => _range;
        private IEnumerable<IUsable> _services;


        public SelectionService(DateRange range = null, string question = "", bool emptyResponse = false, Style style = null)
        {
            coordinator = CoordinatorManager.Instance.CoordinatorOfType<IServiceCoordinator>();
            #region Precondizioni
            if (question == null)
                throw new ArgumentNullException("question null");
            if (coordinator == null)
                throw new InvalidOperationException("Il coordinatore dei servizi non è disponibile");
            #endregion
            InitializeComponent();
            _question.Text = question;
            _emptyResponse = emptyResponse;
            _serviceList = _view;
            _range = range;
            _services = coordinator.Services;
            ActiveControl = _view;
            this.ApplyStyle(style);
        }

        public void OkButtonHandler(Object obj, EventArgs e)
        {
            _errorProvider.Clear();
            if (servizi.Count <= 0)
                Close();
            DialogResult = DialogResult.OK;
            Close();
        }

        public void CancelButtonHandler(Object obj, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SelectionService_Load(object sender, EventArgs e)
        {
            _serviceList.Items.Clear();
            foreach (IUsable service in _services)
            {
                if (Range != null )
                {
                    // elenco solo quelli che rispettano la condizione scelta
                    if (Range.Contains(service.Availability))
                        AddService(service);
                }
                else
                {
                    // elenco tutti i servizi
                    AddService(service);
                }
            }
            _serviceList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            _serviceList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        private void AddService(IUsable usable)
        {
            string[] array = new string[4];
            ListViewItem items;
            array[0] = usable.Name;
            array[1] = usable.Description;
            array[2] = usable.Price + "";
            array[3] = usable.Availability.DateStart() + " - " + usable.Availability.DateEnd();
            items = new ListViewItem(array);
            _serviceList.Items.Add(items);
        }

        public IEnumerable<IUsable> SelectedServices()
        {
            List<IUsable> selectedServices = new List<IUsable>();
            foreach (ListViewItem item in servizi)
            {
                String nome = item.SubItems[0].Text;
                selectedServices.Add(coordinator.FilterServiceName(nome).ElementAt(0));
            }

            return selectedServices.ToArray();
        }
    }
}
