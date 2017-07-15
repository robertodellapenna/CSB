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
using CSB_Project.src.model.Utils;
using static System.Windows.Forms.ListView;

namespace CSB_Project.src.presentation.Utils
{
    public partial class SelectionPacket : Form
    {
        private bool _emptyResponse;
        private IServiceCoordinator coordinator;
        public SelectedListViewItemCollection pacchetti => _view.SelectedItems;
        private ListView _packetList;
        private DateRange _range;
        public DateRange Range => _range;
        private IEnumerable<IPacket> _packets;


        public SelectionPacket(DateRange range = null, string question = "", bool emptyResponse = false, Style style = null)
        {
            coordinator = CoordinatorManager.Instance.CoordinatorOfType<IServiceCoordinator>();
            #region Precondizioni
            if (question == null)
                throw new ArgumentNullException("question null");
            if (coordinator == null)
                throw new InvalidOperationException("Il coordinatore dei pacchetti non è disponibile");
            #endregion
            InitializeComponent();
            _range = range;
            _question.Text = question;
            _emptyResponse = emptyResponse;
            _packetList = _view;
            _packets = coordinator.Packets;
            ActiveControl = _view;
            this.ApplyStyle(style);
        }

        public void OkButtonHandler(Object obj, EventArgs e)
        {
            _errorProvider.Clear();
            if (pacchetti.Count <= 0)
                Close();
            DialogResult = DialogResult.OK;
            Close();
        }

        public void CancelButtonHandler(Object obj, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SelectionPacket_Load(object sender, EventArgs e)
        {
            _packetList.Items.Clear();
            foreach (IPacket packet in _packets)
            {
                string[] array = new string[7];
                ListViewItem items = null;
                if (packet is DateRangePacket && Range != null && Range.OverlapWith(packet.Availability))
                {
                    array[0] = packet.Name;
                    array[1] = packet.Description;
                    array[2] = packet.Price + "";
                    array[3] = packet.Availability.DateStart() + " - " + packet.Availability.DateEnd();
                    array[4] = packet.Usable.Name;
                    array[5] = "";
                    array[6] = (packet as DateRangePacket).Range.DateStart() + " - " + (packet as DateRangePacket).Range.DateEnd();
                    items = new ListViewItem(array);
                }
                if (packet is TicketPacket && Range != null && Range.OverlapWith(packet.Availability))
                {
                    array[0] = packet.Name;
                    array[1] = packet.Description;
                    array[2] = packet.Price + "";
                    array[3] = packet.Availability.DateStart() + " - " + packet.Availability.DateEnd();
                    array[4] = packet.Usable.Name;
                    array[5] = (packet as TicketPacket).Ticket + "";
                    array[6] = "";
                    items = new ListViewItem(array);
                }
                
                if(items != null)
                    _packetList.Items.Add(items);
            }
            _packetList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            _packetList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        public IEnumerable<IPacket> SelectedPackets()
        {
            List<IPacket> selectedPackets = new List<IPacket>();
            foreach (ListViewItem item in pacchetti)
            {
                String nome = item.SubItems[0].Text;
                selectedPackets.Add(coordinator.FilterPacketName(nome).ElementAt(0));
            }

            return selectedPackets.ToArray();
        }
    }
}
