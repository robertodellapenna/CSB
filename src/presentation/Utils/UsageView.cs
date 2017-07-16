using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSB_Project.src.business;
using CSB_Project.src.model.Prenotation;
using CSB_Project.src.model.Services;
using CSB_Project.src.model.TrackingDevice;
using CSB_Project.src.model.Users;
using CSB_Project.src.model.Utils;
using static System.Windows.Forms.ListView;

namespace CSB_Project.src.presentation.Utils
{
    public partial class UsageView : Form
    {
        private bool _emptyResponse;
        private IServiceCoordinator coordinator;
        private ListView _usageList;
        private ICustomer _client;
        public ICustomer Client => _client;
        private IEnumerable<IUsage> _usages;
        private IPrenotationCoordinator prenotationCoordinator = CoordinatorManager.Instance.CoordinatorOfType<IPrenotationCoordinator>();


        public UsageView( ICustomer client,  string question = "", bool emptyResponse = false, Style style = null)
        {
            coordinator = CoordinatorManager.Instance.CoordinatorOfType<IServiceCoordinator>();
            #region Precondizioni
            if (client == null)
                throw new ArgumentNullException("client null");
            if (question == null)
                throw new ArgumentNullException("question null");
            if (coordinator == null)
                throw new InvalidOperationException("Il coordinatore degli utilizzi non è disponibile");
            #endregion
            InitializeComponent();
            _client = client;
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
            IEnumerable<IUsage> validUsage = new List<IUsage>();

            // Da ogni prenotazione del cliente
            foreach(IServizablePrenotation p in prenotationCoordinator.GetPrenotationByClient(Client))
            // recupero tutte le card associate
                foreach (ITrackingDevice td in p.TrackingDevices)
                // per ogni servizio verifico se la carta corrisponde e se l'uso è stato durante la prenotazione
                    validUsage = validUsage.Concat((from u in _usages where u.Who.Id == td.Id && p.PrenotationDate.Contains(u.When) select u).Distinct());

            // inserisco tutti gli usi nella view
            string[] array = new string[3];
            ListViewItem items = null;
            foreach (IUsage usage in validUsage)
            {
                array[0] = usage.When.Day + "/" + usage.When.Month + "/" + usage.When.Year;
                array[1] = Client.FirstName + " " + Client.LastName;
                array[2] = usage.Type.Name;
                items = new ListViewItem(array);
                _usageList.Items.Add(items);
            }

            _usageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            _usageList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }
    }
}
