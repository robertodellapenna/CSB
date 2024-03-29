﻿using CSB_Project.src.business;
using CSB_Project.src.model.Item;
using CSB_Project.src.model.Prenotation;
using CSB_Project.src.model.TrackingDevice;
using CSB_Project.src.model.Users;
using CSB_Project.src.presentation.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ILoginInformation _loginInformation;
        private Func<string, ILoginUser> _userRetriever;

        public MainPresenter(MainView view, Func<string, ILoginUser> userRetriever, int row = DEFAULT_ROW, int column = DEFAULT_COLUMN,
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
            if (userRetriever == null)
                throw new ArgumentNullException("userRetriever null");
            #endregion
            view.Shown += InitHandler;
            _view = view;
            _row = row;
            _column = column;
            _width = width;
            _height = height;
            _userRetriever = userRetriever;
        }

        private void InitHandler(Object o, EventArgs e)
        {
            // Recupero il tag
            _loginInformation = _view.RetrieveTagInformation<ILoginInformation>("loginInformation");
            string username = _loginInformation.Username;
            
            // Recupero la tipologia di utente
            ILoginUser user = _userRetriever(username);
            _authLevel = user == null ? AuthorizationLevel.GUEST : user.AuthorizationLevel;
            _loginName = user?.FirstName ?? " opsite";

            SharedInit();

            // Inizializzo in base alla tipologia di utente
            if (user == null || user.AuthorizationLevel == AuthorizationLevel.GUEST)
                GuestInit();
            else if (user.AuthorizationLevel == AuthorizationLevel.CUSTOMER)
                CustomerInit();
            else if (user.AuthorizationLevel > AuthorizationLevel.CUSTOMER)
                StaffInit();
        }

        private void SharedInit()
        {
            int topPanelHeight = 100;
            int offset = SystemInformation.CaptionHeight;

            Size newViewSize = new Size(_column * _width, topPanelHeight + offset);
            _view.BackColor = Color.White; ;
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
                tablePanel.RowCount = (int)Math.Ceiling((double)tablePanel.Controls.Count / _column);
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

            for (int i = 0; i < _column; i++)
                tablePanel.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Absolute, (newViewSize.Width - SystemInformation.VerticalScrollBarWidth) / _column));

            _view.Size = newViewSize;
            _view.Controls.Add(topPanel);
            tableContainer.Controls.Add(tablePanel);
            _view.Controls.Add(tableContainer);
            _panel = tablePanel;
        }

        private void GuestInit()
        {
            CreateButton("Visualizza stato elementi prenotabili", SpawnBookableView);
            CreateButton("Visualizza servizi disponibili", SpawnServiceView);
            CreateButton("Visualizza Bundle", SpawnBundleView);
            CreateButton("Visualizza Pacchetti", SpawnPacketView);
            CreateButton("Registrati per prenotare", () => MessageBox.Show("Non implementato"));
        }

        private void CustomerInit()
        {
            CreateButton("Visualizza prenotazioni effettuate", SpawnPrenotationView);
            CreateButton("Effettua nuova prenotazione", SpawnPrenotationCreator);
            CreateButton("Visualizza servizi utilizzati", SpawnUsageView);
            CreateButton("Modifica prenotazione", () => MessageBox.Show("Non implementato"));

            CreateButton("Visualizza stato elementi prenotabili", SpawnBookableView);
            CreateButton("Visualizza servizi disponibili", SpawnServiceView);
            CreateButton("Visualizza Bundle", SpawnBundleView);
            CreateButton("Visualizza Pacchetti", SpawnPacketView);
            CreateButton("Visualizza resoconto", () => MessageBox.Show("Non implementato"));
        }

        private void StaffInit()
        {
            CreateButton("Visualizza prenotazioni clienti", SpawnPrenotationView);
            CreateButton("Aggiunti un nuovo item al sistema", SpawnItemCreator);
            CreateButton("Effettua nuova prenotazione", SpawnPrenotationCreator);
            CreateButton("Compatibilità", () => MessageBox.Show("Non implementato"));

            CreateButton("Gestisci elementi prenotabili", SpawnBookableView);
            CreateButton("Gestisci servizi disponibili", SpawnServiceView);
            CreateButton("Gestisci Bundle", SpawnBundleView);
            CreateButton("Gestisci Pacchetti", SpawnPacketView);
            CreateButton("Gestisci categorie sistema", SpawnCategoryView);
            CreateButton("Gestisci personale", () => MessageBox.Show("Non implementato") );
            CreateButton("Stampa resoconto", () => MessageBox.Show("Non implementato"));
        }

        #region SpawnMethod
        private void SpawnPrenotationCreator()
        {
            PrenotationCreatorView prenotationCreatorView = new PrenotationCreatorView();
            AddInformation(prenotationCreatorView);
            new PrenotationCreatorPresenter(prenotationCreatorView);
            prenotationCreatorView.Show();
        }

        private void SpawnItemCreator()
        {
            IItemCoordinator iCoord = CoordinatorManager.Instance.CoordinatorOfType<IItemCoordinator>();

            ItemCreatorView itemCreatoreView = new ItemCreatorView();
            AddInformation(itemCreatoreView);
            new ItemCreatorPresenter(itemCreatoreView, iCoord.AddItem, () => iCoord.Items as IEnumerable<IItem>);
            itemCreatoreView.Show();
        }

        private void SpawnCategoryView()
        {
            ICategoryCoordinator cCoor = CoordinatorManager.Instance.CoordinatorOfType<ICategoryCoordinator>();
            CategoryManagerView catView = new CategoryManagerView();
            new CategoryManagerPresenter(catView, cCoor.RootCategory);
            catView.Show();
        }

        private void SpawnPrenotationView()
        {
            IPrenotationCoordinator pCoord = CoordinatorManager.Instance.CoordinatorOfType<IPrenotationCoordinator>();
            IUserCoordinator uCoord = CoordinatorManager.Instance.CoordinatorOfType<IUserCoordinator>();

            PrenotationView prenotationView = new PrenotationView();
            AddInformation(prenotationView);

            Func<string, ReadOnlyCollection<IPrenotation>> prenotationRetriever =
                (str) => new ReadOnlyCollection<IPrenotation>((from p in pCoord.Prenotations
                                                               where p.Client.FiscalCode == str
                                                               select p).ToList());

            Func<string, ICustomer> customerRetrieverByUsername =
                (str) => (from u in uCoord.RegisteredUsers
                          where u is ICustomer
                          && u.Username == str
                          select u as ICustomer).FirstOrDefault();


            Func<string, IEnumerable<ICustomer>> customerRetrieverByLastName =
                (str) => (from c in uCoord.Customers
                          where c.LastName.Contains(str)
                          select c);

            new PrenotationPresenter(prenotationView, prenotationRetriever,
                customerRetrieverByUsername, customerRetrieverByLastName);

            prenotationView.Show();
        }

        private void SpawnUsageView()
        {
            IUserCoordinator uCoord = CoordinatorManager.Instance.CoordinatorOfType<IUserCoordinator>();
            
            ICustomer c = (from u in uCoord.RegisteredUsers where u is ICustomer && u.Username == _loginInformation.Username select u as ICustomer).FirstOrDefault();
            UsageView usageView = new UsageView(c);
            usageView.Show();
        }

        private void SpawnPacketView()
        {
            PacketManagerView packetView = new PacketManagerView();
            AddInformation(packetView);
            new PacketManagerPresenter(packetView);
            packetView.Show();
        }

        private void SpawnBundleView()
        {
            BundleManagerView bundleView = new BundleManagerView();
            AddInformation(bundleView);
            new BundleManagerPresenter(bundleView);
            bundleView.Show();
        }

        private void SpawnServiceView()
        {
            ServiceManagerView serviceView = new ServiceManagerView();
            AddInformation(serviceView);
            new ServiceManagerPresenter(serviceView);
            serviceView.Show();
        }

        private void SpawnBookableView()
        {
            StructureManagerView structureView = new StructureManagerView();
            AddInformation(structureView);
            new StructureManagerPresenter(structureView);
            structureView.Show();
        }

        private void AddInformation(Form v)
        {
            IUserCoordinator uCoor;
            #region Precondizioni
            if (v == null)
                throw new ArgumentNullException("v null");
            uCoor = CoordinatorManager.Instance.CoordinatorOfType<IUserCoordinator>();
            if (uCoor == null)
                throw new InvalidOperationException("coordinatore utenti non disponibile");
            #endregion

            v.AddTagInformation(AUTHORIZATION_KEY, _authLevel);
            v.AddTagInformation("mode", ActionType.VIEW);
            v.AddLoginInformation(_loginInformation);
            v.AddTagInformation("fiscalCode", (from regUser in uCoor.RegisteredUsers
                                              where regUser is ICustomer
                                              && regUser.Username == _loginInformation.Username
                                              select (regUser as ICustomer).FiscalCode).FirstOrDefault());
        }
        #endregion

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
