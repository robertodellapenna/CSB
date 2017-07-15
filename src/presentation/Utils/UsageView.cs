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
using CSB_Project.src.model.TrackingDevice;
using CSB_Project.src.model.Utils;
using static System.Windows.Forms.ListView;

namespace CSB_Project.src.presentation.Utils
{
    public partial class UsageView : Form
    {
        private bool _emptyResponse;
        private IServiceCoordinator coordinator;
        private ListView _usageList;
        private ITrackingDevice _device;
        public ITrackingDevice Device => _device;
        private IEnumerable<IUsage> _usages;
        private IPrenotationCoordinator prenotationCoordinator = CoordinatorManager.Instance.CoordinatorOfType<IPrenotationCoordinator>();


        public UsageView( ITrackingDevice device = null, string question = "", bool emptyResponse = false, Style style = null)
        {
            coordinator = CoordinatorManager.Instance.CoordinatorOfType<IServiceCoordinator>();
            #region Precondizioni
            if (question == null)
                throw new ArgumentNullException("question null");
            if (coordinator == null)
                throw new InvalidOperationException("Il coordinatore degli utilizzi non è disponibile");
            #endregion
            InitializeComponent();
            _device = device;
            _question.Text = question;
            _emptyResponse = emptyResponse;
            _usageList = _view;
            _usages = coordinator.Usages;
            ActiveControl = _view;
            this.ApplyStyle(style);
        }

        public void OkButtonHandler(Object obj, EventArgs e)
        {
            _errorProvider.Clear();
                Close();
            DialogResult = DialogResult.OK;
            Close();
        }

        public void CancelButtonHandler(Object obj, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SelectionUsage_Load(object sender, EventArgs e)
        {
            _usageList.Items.Clear();
            foreach (IUsage usage in _usages)
            {
                string[] array = new string[3];
                ListViewItem items = null;
                if (usage.Who.Id == Device.Id)
                {
                    array[0] = usage.When.Day + "/" + usage.When.Month + "/" + usage.When.Year;
                    array[1] = prenotationCoordinator.GetPrenotationByCard(usage.Who, usage.When).Client.FirstName + " "
                        + prenotationCoordinator.GetPrenotationByCard(usage.Who, usage.When).Client.LastName;
                    array[2] = usage.Type.Name;
                    items = new ListViewItem(array);
                }
             
                _usageList.Items.Add(items);
            }
            _usageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            _usageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }
    }
}
