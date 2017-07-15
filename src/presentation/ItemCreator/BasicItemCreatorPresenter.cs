using CSB_Project.src.model.Item;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CSB_Project.src.presentation.ItemCreator
{
    public class BasicItemCreatorPresenter
    {
        private Func<XmlNode, bool> _addItemDelegate;
        private BasicItemControl _bic;
        private Button _addButton;

        public BasicItemCreatorPresenter(BasicItemCreatorView view, Func<XmlNode, bool> addItemDelegate, Func<IEnumerable<IItem>> items)
        {
            #region Precondizioni
            if (view == null)
                throw new ArgumentNullException("view null");
            if (addItemDelegate == null)
                throw new ArgumentNullException("addItemDelegate");
            if (items == null)
                throw new ArgumentNullException("items null");
            #endregion

            new BasicControlPresenter(view.Control, items);
            _addItemDelegate = addItemDelegate;
            _bic = view.Control;
            _addButton = view.AddButton;
            _addButton.Click += AddButtonHandler;
            _bic.FriendlyNameBox.TextChanged += (obj, e) => CheckButtonStatus();
            _bic.DescriptionBox.TextChanged += (obj, e) => CheckButtonStatus();
            _bic.IdentifierBox.TextChanged += (obj, e) => CheckButtonStatus();
            CheckButtonStatus();
        }

        private void CheckButtonStatus()
        { 
                _addButton.Enabled = _bic.ErrorProvider.GetError(_bic.IdentifierBox) == ""
                && _bic.ErrorProvider.GetError(_bic.DescriptionBox) == ""
                && _bic.ErrorProvider.GetError(_bic.FriendlyNameBox) == "";
        }

        private void AddButtonHandler(Object sender, EventArgs e)
        {
            // Genero un xml node con la struttura dell'item da inserire
            StringBuilder br = new StringBuilder();
            br.AppendLine("<Items>");
            br.AppendLine("  <Item>");
            br.AppendLine("    <Class>CSB_Project.src.model.Item.ItemFactory+BasicParser</Class>");
            br.AppendLine("    <Identifier>" + _bic.IdentifierBox.Text +"</Identifier>");
            br.AppendLine("    <Name>" + _bic.FriendlyNameBox.Text + "</Name>");
            br.AppendLine("    <Description>" + _bic.DescriptionBox.Text + "</Description>");
            br.AppendLine("    <Price>" + _bic.PriceBox.Text + "</Price>");
            br.AppendLine("  </Item>");
            br.AppendLine("</Items>");

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(br.ToString());
            XmlElement root = xml.DocumentElement;
            XmlNodeList xnl = root.SelectNodes("/Items/Item");
            if (_addItemDelegate(xnl[0]))
            {
                _bic.IdentifierBox.Text = "";
                _bic.FriendlyNameBox.Text = "";
                _bic.DescriptionBox.Text = "";
                _bic.PriceBox.Value = 0;
                MessageBox.Show("Item aggiunto correttamente");
            }
            else
                MessageBox.Show("Item non aggiunto al sistema, uno o più campi non validi");
        }
    }
}
