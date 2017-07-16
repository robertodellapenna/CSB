using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSB_Project.src.business;
using CSB_Project.src.model.Services;
using CSB_Project.src.presentation.Utils;
using CSB_Project.src.model.Users;

namespace CSB_Project.src.presentation
{
    public class PacketManagerPresenter
    {
        private ListView _packetList;
        private IEnumerable<IPacket> _packets;
        private IServiceCoordinator coordinator;

        public PacketManagerPresenter(PacketManagerView view)
        {
            #region Precondizioni
            if (view == null)
                throw new ArgumentNullException("view null");
            #endregion
            view.AddButton.Click += AddHandler;
            
            if (view.RetrieveTagInformation<AuthorizationLevel>("authorizationLevel") < AuthorizationLevel.BASIC_STAFF)
            {
                view.ActionPanel.Enabled = false;
                view.ActionPanel.Visible = false;
            }
            
            _packetList = view.ListView;
            coordinator = CoordinatorManager.Instance.CoordinatorOfType<IServiceCoordinator>();
            if (coordinator == null)
                throw new InvalidOperationException("Il coordinatore dei paccheti non è disponibile");

            _packets = coordinator.Packets;
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
            /* NON PER IL PROTOTIPO
            */
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
            _packetList.Items.Clear();
            foreach (IPacket packet in _packets)
            {
                string[] array = new string[7];
                ListViewItem items = null;
                if (packet is DateRangePacket)
                {
                    array[0] = packet.Name;
                    array[1] = packet.Description;
                    array[2] = packet.Price + "";
                    array[3] = packet.Availability.DateStart() + " - " + packet.Availability.DateEnd();
                    array[4] = packet.Usable.Name;
                    array[5] = "";
                    array[6] = (packet as DateRangePacket).Duration + "";
                    items = new ListViewItem(array);
                }
                if (packet is TicketPacket)
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

                _packetList.Items.Add(items);
            }
            _packetList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            _packetList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            #endregion
        }
    }
}
