using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSB_Project.src.presentation.Utils;
using CSB_Project.src.business;
using CSB_Project.src.model.Users;
using CSB_Project.src.model.Prenotation;
using CSB_Project.src.model.Utils;
using CSB_Project.src.model.Services;
using CSB_Project.src.model.TrackingDevice;

namespace CSB_Project.src.presentation
{
    public partial class AddPrenotationDialog : Form
    {
        #region Campi
        private IUserCoordinator _uCoord = CoordinatorManager.Instance.CoordinatorOfType<IUserCoordinator>();
        private IPrenotationCoordinator _pCoord = CoordinatorManager.Instance.CoordinatorOfType<IPrenotationCoordinator>();
        private ITrackingDeviceCoordinator _tdCoord = CoordinatorManager.Instance.CoordinatorOfType<ITrackingDeviceCoordinator>();
        private AuthorizationLevel _level;
        private ILoginInformation _loginInfo;
        private ICustomer _customer;
        private List<ICustomizableItemPrenotation> _itemsPrenotation;
        private List<IBundle> _bundles;
        private List<IPacket> _packets;
        private ITrackingDevice _baseTrackingDevice;
        private AssociationDescriptor _desc;
        #endregion

        #region Proprietà
        #endregion

        #region Costruttori
        public AddPrenotationDialog()
        {
            InitializeComponent();
            //_level = this.RetrieveTagInformation<AuthorizationLevel>("authorizationLevel");
            //if (_level == AuthorizationLevel.CUSTOMER)
            //{
            //    _loginInfo = this.RetrieveTagInformation<ILoginInformation>("loginInformation");
            //    _customer = (from u in _uCoord.RegisteredUsers
            //                 where (u is ICustomer && u.Username.Equals(_loginInfo.Username))
            //                 select u as ICustomer).First();
            //    _clientComboBox.Items.Add(_customer);
            //    _clientComboBox.Enabled = false;
            //}
            //else
            //{
                _clientComboBox.DataSource = _uCoord.Customers;
            //}
            _itemsPrenotation = new List<ICustomizableItemPrenotation>();
            _bundles = new List<IBundle>();
            _packets = new List<IPacket>();
            _okButton.Enabled = false;
            _clearButton.Enabled = false;
        }

        #endregion

        #region metodi
        private bool CanCreate()
        {
            DateRange range = new DateRange(_fromDateTimePicker.Value, _toDateTimePicker.Value);
            if (_baseTrackingDevice == null || _customer==null)
                return false;
            return range.IsComplete(from i in _itemsPrenotation
                                    select i.RangeData);
        }
        #endregion

        #region Handlers
        public void AddItemPrenotationButtonHandler(Object obj, EventArgs e)
        {
            DateRange range = new DateRange(_fromDateTimePicker.Value, _toDateTimePicker.Value);
            using (AddItemPrenotationDialog sd = new AddItemPrenotationDialog(range))
            {
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    ICustomizableItemPrenotation itemPrenotation = sd.SelectedItem;
                    if (itemPrenotation != null)
                    {
                        _itemsPrenotation.Add(itemPrenotation);
                        _itemPrenotationListView.Items.Add(itemPrenotation.InformationString);
                        if (CanCreate())
                            _okButton.Enabled = true;
                    }
                    _clearButton.Enabled = true;
                }
                else
                    return;
            }
        }
        public void AddBundlesButtonHandler(Object obj, EventArgs e)
        {
            DateRange range = new DateRange(_fromDateTimePicker.Value, _toDateTimePicker.Value);
            using (SelectionBundle sb = new SelectionBundle(range))
            {
                if (sb.ShowDialog() == DialogResult.OK)
                {
                    foreach(IBundle b in sb.SelectedBundles())
                    {
                        _bundles.Add(b);
                        _bundleListView.Items.Add(b.InformationString);
                    }
                    _clearButton.Enabled = true;
                }
                else
                    return;
            }
        }
        public void AddPacketsButtonHandler(Object obj, EventArgs e)
        {
            DateRange range = new DateRange(_fromDateTimePicker.Value, _toDateTimePicker.Value);
            using (SelectionPacket sp = new SelectionPacket(range))
            {
                if (sp.ShowDialog() == DialogResult.OK)
                {

                    foreach (IPacket p in sp.SelectedPackets())
                    {
                        _packets.Add(p);
                        _packetListView.Items.Add(p.InformationString);
                    }
                    _clearButton.Enabled = true;
                }
                else
                    return;
            }
        }
        public void AddTrackingDeviceButtonHandler(Object obj, EventArgs e)
        {
            DateRange range = new DateRange(_fromDateTimePicker.Value, _toDateTimePicker.Value);
            using (StringDialog sd = new StringDialog("Nome da associare a prenotazione base: "))
            {
                if(sd.ShowDialog()== DialogResult.OK)
                {
                    string name = sd.Response;
                   
                    if (name != null)
                    {
                        _desc = new AssociationDescriptor(range, name);
                    }
                }
                else
                    return;
            }
            if(_desc==null)
                _desc= new AssociationDescriptor(range, "Base");
            _baseTrackingDevice = _tdCoord.Next;
            _tdLabelValue.Text =_desc.InformationString + " -> " + _baseTrackingDevice.Id;
            _associateTrackingDeviceButton.Enabled = false;
            if (CanCreate())
                _okButton.Enabled = true;
            _clearButton.Enabled = true;
        }
        public void CustomerChangedHandler(Object obj, EventArgs e)
        {
            _customer = _clientComboBox.SelectedItem as ICustomer;
        }
        public void FromDateChangedHandler(Object obj, EventArgs e)
        {
            if (_fromDateTimePicker.Value > _toDateTimePicker.Value)
            {
                //MessageBox.Show("Range inconsistente");
                _fromDateTimePicker.Value = _toDateTimePicker.Value.AddDays(-1);
            }
            ClearHandler(this, EventArgs.Empty);
        }
        public void ToDateChangedHandler(Object obj, EventArgs e)
        {

            if (_toDateTimePicker.Value < _fromDateTimePicker.Value)
            {
                //MessageBox.Show("Range inconsistente");
                _toDateTimePicker.Value = _fromDateTimePicker.Value.AddDays(1);
            }
            ClearHandler(this, EventArgs.Empty);
        }
        public void ClearHandler(Object obj, EventArgs e)
        {
            _baseTrackingDevice = null;
            _associateTrackingDeviceButton.Enabled = true;
            _tdLabelValue.Text= "";
            _itemsPrenotation.Clear();
            _itemPrenotationListView.Clear();
            _packets.Clear();
            _packetListView.Clear();
            _bundles.Clear();
            _bundleListView.Clear();
            _okButton.Enabled = false;
            _clearButton.Enabled = false;
            _desc = null;
        }
        public void OkButtonHandler(Object obj, EventArgs e)
        {
            _errorProvider.Clear();

            try
            {
                DateRange range = new DateRange(_fromDateTimePicker.Value, _toDateTimePicker.Value);
                ICustomizablePrenotation prenotation = new CustomizableServizablePrenotation(_customer, range, _itemsPrenotation, _baseTrackingDevice, _desc );
                DialogResult = DialogResult.OK;
                Close();
            }catch(Exception exception)
            {
                MessageBox.Show("Impossibile creare la prenotazione per il seguente motivo: " + exception.Message);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        public void CancelButtonHandler(Object obj, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion
    }
}
