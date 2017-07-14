using CSB_Project.src.model.Prenotation;
using CSB_Project.src.model.Users;
using CSB_Project.src.presentation.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSB_Project.src.presentation
{
    public class PrenotationPresenter
    {
        private Func<string, ReadOnlyCollection<IPrenotation>> _prenotationRetriever;
        private Func<string, ICustomer> _customerRetrieverByUsername;
        private Func<string, IEnumerable<ICustomer>> _customerRetrieverByLastName;

        private ComboBox _customersBox;
        private TabControl _prenotationControl;

        public PrenotationPresenter(PrenotationView view, Func<string, ReadOnlyCollection<IPrenotation>> prenotationRetrieverByFiscaleCode,
            Func<string, ICustomer> customerRetrieverByUsername, Func<string, IEnumerable<ICustomer>> customerRetrieverByLastName)
        {
            #region Precondizioni
            if (view == null)
                throw new ArgumentNullException("view null");
            if (prenotationRetrieverByFiscaleCode == null)
                throw new ArgumentNullException("prenotation Retriever null");
            if (customerRetrieverByUsername == null)
                throw new ArgumentNullException("customer username Retriever null");
            if (customerRetrieverByLastName == null)
                throw new ArgumentNullException("customer lastname Retriever null");
            #endregion
            _prenotationRetriever = prenotationRetrieverByFiscaleCode;
            _customerRetrieverByUsername = customerRetrieverByUsername;
            _customerRetrieverByLastName = customerRetrieverByLastName;
            _customersBox = view.CustomerBox;
            _prenotationControl = view.TabControl;
            AuthorizationLevel authLevel = view.RetrieveTagInformation<AuthorizationLevel>("authorizationLevel");

            if (authLevel == AuthorizationLevel.GUEST)
                throw new InvalidOperationException("I Guest non possono utilizzare questa view");

            if(authLevel == AuthorizationLevel.CUSTOMER)
            {
                view.SearchPanel.Enabled = false;
                view.SearchPanel.Visible = false;
                string fiscalCode = view.RetrieveTagInformation<string>("fiscalCode");
                if (fiscalCode == null)
                    throw new InvalidOperationException("Il cliente che ha aperto la view non ha un codice fiscale");
                ReadOnlyCollection<IPrenotation> prenotations = RetrievePrenotation(fiscalCode);
                if (prenotations.Count <= 0)
                    MessageBox.Show("Non risultano attive prenotazioni a tuo nome");
                else
                    view.TabControl.Populate(prenotations);
                // Ripopolo la view in caso di cambiamenti
                foreach (IPrenotation p in prenotations)
                    p.PrenotationChanged += (sender, pea) 
                        => view.TabControl.Populate(prenotations);
            }
            else
            {
                MessageBox.Show("Inserisci l'username o un il " +
                    "cognome di un cliente per visualizzare le prenotazioni");

                _customersBox.DropDownStyle = ComboBoxStyle.DropDownList;
                _customersBox.DisplayMember = "DisplayInfo";
                _customersBox.SelectedIndexChanged += CustomerSelectedHandler;
                view.SearchBox.TextChanged += SearchBoxChanged;
            }
        }

        private void CustomerSelectedHandler(Object sender, EventArgs e)
        {
            IEnumerable<IPrenotation> prenotations = new IPrenotation[0];
            if (_customersBox.SelectedIndex >= 0)
                prenotations = _prenotationRetriever((_customersBox.Items[_customersBox.SelectedIndex] as ICustomer).FiscalCode);
            
            _prenotationControl.Populate(prenotations);
        }

        private void SearchBoxChanged(Object o, EventArgs e) {
            if (!(o is TextBox))
                return;
            string textValue = (o as TextBox).Text;
            ISet<ICustomer> customers = new HashSet<ICustomer>(_customerRetrieverByLastName(textValue));
            ICustomer usC = _customerRetrieverByUsername(textValue);
            if(usC != null)
                customers.Add(usC);
            PopulateComboBox(customers);
        }

        private void PopulateComboBox(IEnumerable<ICustomer> customers)
        {
            _customersBox.Items.Clear();
            foreach (ICustomer c in customers)
                _customersBox.Items.Add(c);
            if (_customersBox.Items.Count > 0)
                _customersBox.SelectedIndex = 0;
            else
            {
                _customersBox.Text = "";
                _customersBox.SelectedIndex = -1;
            }
        }

        private ReadOnlyCollection<IPrenotation> RetrievePrenotation(string fiscalCode)
        {
            return _prenotationRetriever(fiscalCode);
        }

    }
}
