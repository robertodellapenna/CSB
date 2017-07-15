using CSB_Project.src.business;
using CSB_Project.src.model.Prenotation;
using CSB_Project.src.model.Services;
using CSB_Project.src.model.TrackingDevice;
using CSB_Project.src.model.Users;
using CSB_Project.src.model.Utils;
using CSB_Project.src.presentation.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSB_Project.src.presentation
{
    public partial class PrenotationCreatorView : Form
    {
        public DateTimePicker FromDateTimePicker => _fromDateTimePicker;
        public DateTimePicker ToDateTimePicker => _toDateTimePicker;
        public ListView ItemPrenotationListView => _itemPrenotationListView;
        public ListView BundleListView => _bundleListView;
        public ListView PacketListView => _packetListView;
        public Button CreateButton => _createButton;
        public Button ClearButton => _clearButton;
        public Button AbortButton => _cancelButton;
        public Button AssociateTrackingDeviceButton => _associateTrackingDeviceButton;
        public Button AddPacketButton => _addPacketButton;
        public Button AddBundleButton => _addBundleButton;
        public Button AddItemPrenotationButton => _addItemPrenotationButton;
        public Label TrackingDeviceLabel => _tdLabelValue;
        public Label CustomerLabel => _customerLabel;
        public ComboBox CustomerComboBox => _clientComboBox;
        public ErrorProvider ErrorProvider => _errorProvider;

        public PrenotationCreatorView()
        {
            InitializeComponent();
        }
    }
}
