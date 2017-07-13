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
using static System.Windows.Forms.ListView;

namespace CSB_Project.src.presentation.Utils
{
    public partial class SelectionService : Form
    {
        private bool _emptyResponse;
        private IServiceCoordinator coordinator;
        public SelectedListViewItemCollection servizi => _view.SelectedItems;
        private ListView _serviceList;
        private IEnumerable<IUsable> _services;


        public SelectionService(string question = "", bool emptyResponse = false, Style style = null)
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

        }
    }
}
