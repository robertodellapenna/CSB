using CSB_Project.src.business;
using CSB_Project.src.model.Users;
using CSB_Project.src.presentation.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSB_Project.src.presentation
{
    public class MainPresenter
    {
        private const int DEFAULT_COLUMN = 3;
        private const int DEFAULT_ROW = 3;
        private const int DEFAULT_WIDTH = 150;
        private const int DEFAULT_HEIGHT = 150;
        private const string AUTHORIZATION_KEY = "authorizationLevel";

        private AuthorizationLevel _authLevel;
        private MainView _view;
        private Panel _panel;
        private int _row, _column, _width, _height;
        private string _loginName;

        public MainPresenter(MainView view,Func<string, ILoginUser> userRetriever, int row = DEFAULT_ROW, int column = DEFAULT_COLUMN,
            int width = DEFAULT_WIDTH, int height = DEFAULT_HEIGHT)
        {
            #region Precondizioni
            if (view == null)
                throw new ArgumentNullException("view null");
            if (row <= 0)
                throw new ArgumentException("row <= 0");
            if (column <= 0)
                throw new ArgumentException("column <= 0");
            if (width <= 0)
                throw new ArgumentException("width <= 0");
            if (height <= 0)
                throw new ArgumentException("height <= 0");
            if(userRetriever == null)
                throw new ArgumentNullException("userRetriever null");
            #endregion
            _view = view;
            _row = row;
            _column = column;
            _width = width;
            _height = height;

            // Recupero il tag
            //string username = view.RetrieveTagInformation<LoginPresenter.ILoginInformation>("loginInformation").Username;
            
            // DA ELIMINARE
            //string username = RetrieveUsername();  
            //string username = "giovanni.admin"; // STAFF
            string username = ""; // GUEST
            //string username = "lorenzo.antonini"; // CUSTOMER 
            // FINE DA ELIMINARE

            // Recupero la tipologia di utente
            ILoginUser user = userRetriever(username);
            _authLevel = user == null ? AuthorizationLevel.GUEST : user.AuthorizationLevel;
            _loginName = user?.FirstName ?? " opsite";

            SharedInit();

            // Inizializzo in base alla tipologia di utente
            if(user == null || user.AuthorizationLevel == AuthorizationLevel.GUEST)
                GuestInit();
            else if (user.AuthorizationLevel == AuthorizationLevel.CUSTOMER)
                CustomerInit();
            else if (user.AuthorizationLevel >= AuthorizationLevel.CUSTOMER)
                StaffInit();
        }

        private void SharedInit()
        {
            int topPanelHeight = 100;
            int offset = SystemInformation.CaptionHeight;

            Size newViewSize = new Size(_column * _width, topPanelHeight + offset);
            _view.BackColor= Color.White; ;
            _view.FormBorderStyle = FormBorderStyle.FixedSingle;

            Panel topPanel = new Panel();
            topPanel.Size = new Size(newViewSize.Width, topPanelHeight);
            topPanel.Dock = DockStyle.Top;
            topPanel.Margin = new Padding(0);
            topPanel.BackColor = Color.White;
            string msg = "Benvenuto " + _loginName;
            Style style = new Style();
            style.Font = new Font(FontFamily.GenericSansSerif, 22, FontStyle.Bold);
            BorderLabel loginInfoLabel = new BorderLabel(
                msg, Color.DeepSkyBlue, Color.White, Color.White, 0, style);
            loginInfoLabel.Dock = DockStyle.Fill;
            topPanel.Controls.Add(loginInfoLabel);

            Panel tableContainer = new Panel();
            tableContainer.AutoScroll = true;
            tableContainer.AutoSize = false;
            tableContainer.Margin = new Padding(0);
            tableContainer.Location = new Point(0, topPanelHeight);
            tableContainer.BackColor = Color.White;

            TableLayoutPanel tablePanel = new TableLayoutPanel();
            tablePanel = new TableLayoutPanel();
            tablePanel.AutoSize = false;
            tablePanel.BackColor = Color.White;
            tablePanel.Margin = new Padding(0);
            tablePanel.Padding = new Padding(0);
            tablePanel.BackColor = Color.White;

            tablePanel.RowCount = 0;
            tablePanel.RowStyles.Clear();
            tablePanel.ControlAdded += delegate (Object o, ControlEventArgs e)
            {
                tablePanel.RowCount = (int) Math.Ceiling((double)tablePanel.Controls.Count / _column);
                if (tablePanel.RowCount > tablePanel.RowStyles.Count)
                {
                    int tableRow = tablePanel.RowCount > _row ? _row : tablePanel.RowCount;
                    tableContainer.Size = new Size(newViewSize.Width, tableRow * _height);
                    tablePanel.Size = new Size(newViewSize.Width - SystemInformation.VerticalScrollBarWidth, tablePanel.RowCount * _height);
                    tablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, _height));
                }
                _view.Size = new Size(_column * _width, topPanelHeight + offset + tableContainer.Height);
            };

            loginInfoLabel.Click += (obj, e) => _view.Size += new Size(0, 1);

            tablePanel.ColumnStyles.Clear();
            tablePanel.ColumnCount = _column;

            for (int i=0; i<_column; i++)
                tablePanel.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Absolute, (newViewSize.Width - SystemInformation.VerticalScrollBarWidth) /_column));

            _view.Size = newViewSize;
            _view.Controls.Add(topPanel);
            tableContainer.Controls.Add(tablePanel);
            _view.Controls.Add(tableContainer);
            _panel = tablePanel;            
        }

        private void GuestInit()
        {
            CreateButton("Visualizza stato ombrelloni", SpawnBookableView);
            CreateButton("Visualizza servizi disponibili", SpawnServiceView);
            CreateButton("Visualizza Bundle", SpawnBundleView);
            CreateButton("Visualizza Pacchetti", SpawnPacketView);
            CreateButton("Registrati per prenotare", () => MessageBox.Show("Non implementato"));

        }

        #region SpawnMethod
        private void SpawnPacketView()
        {
            PacketManagerView packetView = new PacketManagerView();
            packetView.AddTagInformation(AUTHORIZATION_KEY, _authLevel);
            packetView.AddTagInformation("mode", ActionType.VIEW);
            new PacketManagerPresenter(packetView);
            packetView.Show();
        }

        private void SpawnBundleView()
        {
            BundleManagerView bundleView = new BundleManagerView();
            bundleView.AddTagInformation(AUTHORIZATION_KEY, _authLevel);
            bundleView.AddTagInformation("mode", ActionType.VIEW);
            new BundleManagerPresenter(bundleView);
            bundleView.Show();
        }

        private void SpawnServiceView()
        {
            SelectionService serviceView = new SelectionService();
            serviceView.AddTagInformation(AUTHORIZATION_KEY, _authLevel);
            serviceView.AddTagInformation("mode", ActionType.VIEW);
            serviceView.Show();
        }


        private void SpawnBookableView()
        {
            StructureManagerView structureView = new StructureManagerView();
            structureView.AddTagInformation(AUTHORIZATION_KEY, _authLevel);
            structureView.AddTagInformation("mode", ActionType.VIEW);
            new StructureManagerPresenter(structureView);
            structureView.Show();
        }
        #endregion


        private void CustomerInit()
        {
            CreateButton("Visualizza prenotazioni effettuate", () => MessageBox.Show("Hello"));
            CreateButton("Effettua nuova prenotazione", () => MessageBox.Show("Hello"));
            CreateButton("Modifica prenotazione", () => MessageBox.Show("Hello"));
        }

        private void StaffInit()
        {

        }

        private void CreateButton(string text, Action action)
        {
            Style style = new Style();
            style.Font = new Font(FontFamily.GenericSansSerif, 18, FontStyle.Bold);
            BorderLabel showItemStatusButton = new BorderLabel(text, Color.BlueViolet, Color.Black, Color.White, 1, style);
            showItemStatusButton.Margin = new Padding(0);
            showItemStatusButton.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            showItemStatusButton.Dock = DockStyle.Fill;
            showItemStatusButton.Click += (obj, e) => action();
            _panel.Controls.Add(showItemStatusButton);
        }
    }
}
