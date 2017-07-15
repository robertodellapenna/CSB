using CSB_Project.src.model.Utils;
using System;
using System.Linq;
using CSB_Project.src.business;
using CSB_Project.src.model.Prenotation;
using CSB_Project.src.model.Services;
using CSB_Project.src.model.TrackingDevice;
using CSB_Project.src.model.Users;
using CSB_Project.src.presentation.Utils;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSB_Project.src.presentation
{
    public class PrenotationCreatorPresenter
    {

        #region Campi
        private DateTimePicker _fromDateTimePicker, _toDateTimePicker;
        private ListView _itemPrenotationListView, _bundleListView, _packetListView;
        private Button _createButton, _clearButton, _associateTrackingDeviceButton;
        private ComboBox _customerComboBox;
        private Label _trackingDeviceLabel;
        private ErrorProvider _errorProvider;
        private PrenotationCreatorView _view;
        private AuthorizationLevel _authLevel;


        private IUserCoordinator _uCoord = CoordinatorManager.Instance.CoordinatorOfType<IUserCoordinator>();
        private IPrenotationCoordinator _pCoord = CoordinatorManager.Instance.CoordinatorOfType<IPrenotationCoordinator>();
        private ITrackingDeviceCoordinator _tdCoord = CoordinatorManager.Instance.CoordinatorOfType<ITrackingDeviceCoordinator>();
        
        private ILoginInformation _loginInfo;
        private ICustomer _customer;
        private List<ICustomizableItemPrenotation> _itemsPrenotation;
        private List<IBundle> _bundles;
        private List<IPacket> _packets;
        private ITrackingDevice _baseTrackingDevice;
        private AssociationDescriptor _desc;
        #endregion

        public PrenotationCreatorPresenter(PrenotationCreatorView view){
            #region Precondizioni
            if (view == null)
                throw new ArgumentNullException("view null");
            #endregion
            _itemsPrenotation = new List<ICustomizableItemPrenotation>();
            _bundles = new List<IBundle>();
            _packets = new List<IPacket>();

            _fromDateTimePicker = view.FromDateTimePicker;
            _toDateTimePicker = view.ToDateTimePicker;
            _itemPrenotationListView = view.ItemPrenotationListView;
            _bundleListView = view.BundleListView;
            _createButton = view.CreateButton;
            _clearButton = view.ClearButton;
            _packetListView = view.PacketListView;
            _trackingDeviceLabel = view.TrackingDeviceLabel;
            _customerComboBox = view.CustomerComboBox;
            _associateTrackingDeviceButton = view.AssociateTrackingDeviceButton;
            _errorProvider = view.ErrorProvider;
            _view = view;

            // init handler 
            _clearButton.Click += ClearHandler;
            _view.AbortButton.Click += CancelButtonHandler;
            _createButton.Click += CreateButtonHandler;
            _fromDateTimePicker.ValueChanged += FromDateChangedHandler;
            _toDateTimePicker.ValueChanged += ToDateChangedHandler;
            _customerComboBox.SelectedIndexChanged += CustomerChangedHandler;
            _associateTrackingDeviceButton.Click += AddTrackingDeviceButtonHandler;
            _view.AddBundleButton.Click += AddBundlesButtonHandler;
            _view.AddPacketButton.Click += AddPacketsButtonHandler;
            _view.AddItemPrenotationButton.Click += AddItemPrenotationButtonHandler;

            // init componenti
            _customerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _customerComboBox.DisplayMember = "DisplayInfo";
            _fromDateTimePicker.MinDate = DateTime.Now.Date;
            _authLevel = view.RetrieveTagInformation<AuthorizationLevel>("authorizationLevel");

            if (_authLevel == AuthorizationLevel.GUEST)
                throw new InvalidOperationException("Gli utenti GUEST non posso effettuare prenotazioni");

            if (_authLevel == AuthorizationLevel.CUSTOMER)
            {
                _view.CustomerLabel.Visible = false;
                _view.CustomerLabel.Enabled = false;
                _loginInfo = view.RetrieveTagInformation<ILoginInformation>("loginInformation");
                _customer = (from u in _uCoord.RegisteredUsers
                             where (u is ICustomer && u.Username.Equals(_loginInfo.Username))
                             select u as ICustomer).FirstOrDefault();
                if (_customer == null)
                {
                    MessageBox.Show("Non risultato registrato come cliente nel sistema. Chiama lo staff");
                    _view.Close();
                }
                _customerComboBox.Items.Add(_customer);
                _customerComboBox.SelectedIndex = 0;
                _customerComboBox.Enabled = false;
            }
            
            if(_authLevel >= AuthorizationLevel.BASIC_STAFF)
            {
                _customerComboBox.Items.Clear();
                foreach (ICustomer c in _uCoord.Customers)
                    _customerComboBox.Items.Add(c);
                if (_customerComboBox.Items.Count > 0)
                    _customerComboBox.SelectedIndex = 0;
            }

            _createButton.Enabled = false;
            _clearButton.Enabled = false;
        }

        #region metodi
        private bool CanCreate()
        {
            DateRange range = new DateRange(_fromDateTimePicker.Value, _toDateTimePicker.Value);
            if (_baseTrackingDevice == null || _customer == null)
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
                            _createButton.Enabled = true;
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
                    foreach (IBundle b in sb.SelectedBundles())
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
                if (sd.ShowDialog() == DialogResult.OK)
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
            if (_desc == null)
                _desc = new AssociationDescriptor(range, "Base");
            try
            {
                _baseTrackingDevice = _tdCoord.Next;
            }catch(Exception exception)
            {
                MessageBox.Show("Non è possibile recuperare un tracking device. Chiedi allo staff");
                _view.Close();
            }

            _trackingDeviceLabel.Text = _desc.InformationString + " -> " + _baseTrackingDevice.Id;
            _associateTrackingDeviceButton.Enabled = false;
            if (CanCreate())
                _createButton.Enabled = true;
            _clearButton.Enabled = true;
        }
        public void CustomerChangedHandler(Object obj, EventArgs e)
        {
            _customer = _customerComboBox.SelectedItem as ICustomer;
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
            _trackingDeviceLabel.Text = "";
            _itemsPrenotation.Clear();
            _itemPrenotationListView.Clear();
            _packets.Clear();
            _packetListView.Clear();
            _bundles.Clear();
            _bundleListView.Clear();
            _createButton.Enabled = false;
            _clearButton.Enabled = false;
            _desc = null;
        }

        public void CreateButtonHandler(Object obj, EventArgs e)
        {
            _errorProvider.Clear();

            try
            {
                DateRange range = new DateRange(_fromDateTimePicker.Value, _toDateTimePicker.Value);
                ICustomizableServizablePrenotation prenotation = new CustomizableServizablePrenotation(_customer, range, _itemsPrenotation, _baseTrackingDevice, _desc, _packets, _bundles);
                _pCoord.AddPrenotation(prenotation);
                _tdCoord.LockTrackingDevice(prenotation as IServizablePrenotation);
                MessageBox.Show("Prenotazione creata corretamente");
                _view.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Impossibile creare la prenotazione per il seguente motivo: " + exception.Message);
            }
        }

        public void CancelButtonHandler(Object obj, EventArgs e)
        {
            _view.Close();
        }
        #endregion
    }
}
