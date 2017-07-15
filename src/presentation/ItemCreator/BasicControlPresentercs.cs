using CSB_Project.src.model.Item;
using CSB_Project.src.presentation.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSB_Project.src.presentation.ItemCreator
{
    public class BasicControlPresenter
    {
        private Func<IEnumerable<IItem>> _items;
        private TextBox _identifierBox;
        private ErrorProvider _errorProvider;

        public BasicControlPresenter(BasicItemControl control, Func<IEnumerable<IItem>> items, Style style = null)
        {
            #region Precondizioni
            if (control == null)
                throw new ArgumentNullException("control null");
            if (items == null)
                throw new ArgumentNullException("items null");
            #endregion

            _identifierBox = control.IdentifierBox;
            _errorProvider = control.ErrorProvider;
            _items = items;

            control.ApplyStyle(style);
            control.PriceBox.Minimum = 0;
            control.FriendlyNameBox.TextChanged += NotNullTextHandler;
            control.DescriptionBox.TextChanged += NotNullTextHandler;
            _identifierBox.TextChanged += IdentifierTextChangedHandler;
            IdentifierTextChangedHandler(_identifierBox, EventArgs.Empty);
            NotNullTextHandler(control.FriendlyNameBox, EventArgs.Empty);
            NotNullTextHandler(control.DescriptionBox, EventArgs.Empty);
        }

        private void IdentifierTextChangedHandler(Object o, EventArgs e)
        {
            _errorProvider.SetError(_identifierBox, null);
            if (_identifierBox.Text == "")
            {
                _errorProvider.SetError(_identifierBox, "Il valore non può essere nullo");
                return;
            }

            if((from i in _items() where i.Identifier == _identifierBox.Text select i).Any())
                _errorProvider.SetError(_identifierBox, "Esiste già un item con questo identificativo");
        }

        private void NotNullTextHandler(Object o, EventArgs e)
        {
            if (!(o is TextBox))
                return;
            _errorProvider.SetError((o as TextBox), null);
            if ((o as TextBox).Text == "")
            {
                _errorProvider.SetError((o as TextBox), "Il campo non può essere vuoto");
            }
        }
    }
}
