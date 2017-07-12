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
        private const int COLUMN_NUMBER = 3;
        private const int ROW_HEIGHT = 200;
        private const string AUTHORIZATION_KEY = "authorizationLevel";
        private AuthorizationLevel _authLevel;
        private MainView _view;
        private Panel _panel;

        public MainPresenter(MainView view)
        {
            #region Precondizioni
            if (view == null)
                throw new ArgumentNullException("view null");
            #endregion
            _view = view;
            SharedInit();
            // Recupero il tag
            //string username = view.RetrieveTagInformation<LoginPresenter.ILoginInformation>("loginInformation").Username;
            
            // DA ELIMINARE
            //string username = RetrieveUsername();  
            //string username = "giovanni.admin"; // STAFF
            //string username = ""; // GUEST
            string username = "lorenzo.antonini"; // CUSTOMER 
            // FINE DA ELIMINARE

            // Recupero la tipologia di utente
            IUserCoordinator coord = CoordinatorManager.Instance.CoordinatorOfType<IUserCoordinator>();
            if (coord == null)
                throw new InvalidOperationException("Impossibile proseguire, non è presente un coordinatore di utenti");
            ILoginUser user = coord.Filter((u) => u.Username == username).FirstOrDefault();
            _authLevel = user == null ? AuthorizationLevel.GUEST : user.AuthorizationLevel;
            // Inizializzo in base alla tipologia di utente
            
            GuestInit();

            if (user.AuthorizationLevel == AuthorizationLevel.CUSTOMER)
                CustomerInit();

            if (user.AuthorizationLevel >= AuthorizationLevel.CUSTOMER)
                StaffInit();
        }

        private void SharedInit()
        {
            TableLayoutPanel panel = new TableLayoutPanel();
            panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;

            panel.RowCount = _view.Height / ROW_HEIGHT;
            panel.BackColor = Color.White;
            panel.RowStyles.Clear();
            for (int i = 0; i < panel.RowCount; i++)
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, ROW_HEIGHT));
            
            panel.ColumnStyles.Clear();
            panel.ColumnCount = COLUMN_NUMBER;
            for (int i=0; i<COLUMN_NUMBER;i++)
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _view.Width/ COLUMN_NUMBER));
            
            _view.Controls.Add(panel);
            _panel = panel;            
        }

        private void GuestInit()
        {
            CreateButton("Visualizza stato ombrelloni", () => MessageBox.Show("Hello"));
            CreateButton("Visualizza servizi disponibili", SpawnServiceView);
        }

        private void SpawnServiceView()
        {
            SelectionService serviceView = new SelectionService();
            serviceView.AddTagInformation(AUTHORIZATION_KEY, _authLevel);
            serviceView.AddTagInformation("mode", ActionType.VIEW);
            serviceView.Show();
        }

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
            BorderLabel showItemStatusButton = new BorderLabel(text, Color.BlueViolet, Color.Black, Color.White, 3, style);
            showItemStatusButton.Dock = DockStyle.Fill;
            showItemStatusButton.Click += (obj, e) => action();
            _panel.Controls.Add(showItemStatusButton);
        }
    }
}
