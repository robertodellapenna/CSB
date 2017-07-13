using System;
using System.Collections.Generic;
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
    public partial class SelectionBundle : Form
    {
        private bool _emptyResponse;
        private IServiceCoordinator coordinator;
        public SelectedListViewItemCollection bundles => _view.SelectedItems;
        private ListView _bundleList;
        private IEnumerable<IBundle> _bundles;


        public SelectionBundle(string question = "", bool emptyResponse = false, Style style = null)
        {
            coordinator = CoordinatorManager.Instance.CoordinatorOfType<IServiceCoordinator>();
            #region Precondizioni
            if (question == null)
                throw new ArgumentNullException("question null");
            if (coordinator == null)
                throw new InvalidOperationException("Il coordinatore dei bundle non è disponibile");
            #endregion
            InitializeComponent();
            _question.Text = question;
            _emptyResponse = emptyResponse;
            _bundleList = _view;
            _bundles = coordinator.Bundles;
            ActiveControl = _view;
            this.ApplyStyle(style);
        }

        public void OkButtonHandler(Object obj, EventArgs e)
        {
            _errorProvider.Clear();
            if (bundles.Count <= 0)
                Close();
            DialogResult = DialogResult.OK;
            Close();
        }

        public void CancelButtonHandler(Object obj, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SelectionBundle_Load(object sender, EventArgs e)
        {
            _bundleList.Items.Clear();
            foreach (IBundle bundle in _bundles)
            {
                string[] array = new string[4];
                string pacchetti = "";
                ListViewItem items = null;
                array[0] = bundle.Name;
                array[1] = bundle.Description;
                array[2] = bundle.Price + "";
                for (int i = 0; i < bundle.Packets.Count - 1; i++)
                {
                    pacchetti = pacchetti + bundle.Packets.ElementAt(i).Name + " - ";
                }
                pacchetti = pacchetti + bundle.Packets.ElementAt(bundle.Packets.Count - 1).Name;
                array[3] = pacchetti;
                items = new ListViewItem(array);
                _bundleList.Items.Add(items);
            }
            _bundleList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            _bundleList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        private void _view_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
