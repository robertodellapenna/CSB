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

        public PrenotationPresenter(PrenotationView view, Func<string, ReadOnlyCollection<IPrenotation>> prenotationRetrieverByFiscaleCode)
        {
            #region Precondizioni
            if (view == null)
                throw new ArgumentNullException("view null");
            if (prenotationRetrieverByFiscaleCode == null)
                throw new ArgumentNullException("prenotation Retriever");
            #endregion
            _prenotationRetriever = prenotationRetrieverByFiscaleCode;
            AuthorizationLevel authLevel = view.RetrieveTagInformation<AuthorizationLevel>("authorizationLevel");

            if (authLevel == AuthorizationLevel.GUEST)
                throw new InvalidOperationException("I Guest non possono utilizzare questa view");

            if(authLevel == AuthorizationLevel.CUSTOMER)
            {
                view.SearchPanel.Enabled = false;
                view.SearchPanel.Visible = false;
                ReadOnlyCollection<IPrenotation> prenotations = RetrievePrenotation("CC4");
                if (prenotations.Count <= 0)
                    MessageBox.Show("Non risultano attive prenotazioni a tuo nome");
                else
                    view.TabControl.Populate(prenotations);

            }
            else
            {
                MessageBox.Show("Inserisci l'username o un il " +
                    "cognome di un cliente per visualizzare le prenotazioni");
            }
        }

        private ReadOnlyCollection<IPrenotation> RetrievePrenotation(string fiscalCode)
        {
            return _prenotationRetriever(fiscalCode);
        }

    }
}
