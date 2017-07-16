using CSB_Project.src.model.Item;
using CSB_Project.src.presentation.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace CSB_Project.src.presentation
{
    public class ItemPickerPresenter
    {
        private Label _itemOutput;
        private ListView _lv;
        private Compatibilities _compatibilites;
        private IItem _baseItem;
        private IDictionary<IItem, int> _associatedItem;
        private ItemPickerView _ip;

        public IItem BaseItem
        {
            get => _baseItem;

            private set
            {
                _baseItem = value;
                Refresh();
            }
        }

        public ItemPickerPresenter( ItemPickerView ip)
        {
            #region Precondizioni
            if (ip == null)
                throw new ArgumentNullException("itemPickerControl null");
            #endregion
            _itemOutput = ip.Output;
            _lv = ip.ItemListView;
            _compatibilites = Compatibilities.Instance;
            _ip = ip;
            _ip.ResetButton.Click += ResetHandler;
            _ip.SearchBox.TextChanged += SearchChanged;
            _ip.BaseItemButton.Click += SelectBaseItemHandler;
            _ip.AssociateItemButton.Click += AssociateItemHandler;
            init();
        }

        #region Metodi
        private void init()
        {
            ResetHandler(this, EventArgs.Empty);
            Refresh();
        }

        private void Refresh()
        {
            if(BaseItem == null)
            {
                _ip.AssociateItemButton.Enabled = false;
                _ip.BaseItemButton.Enabled = true;
            }
            else
            {
                _ip.AssociateItemButton.Enabled = true;
                _ip.BaseItemButton.Enabled = false;
            }
            UpdateItemOutput();
            PopulateListView(FilterSearch(""));
        }

        private void PopulateListView(IEnumerable<IItem> items)
        {
            if (BaseItem == null)
                _lv.Populate(items, item => item.FriendlyName);
            else
                _lv.Populate(items, item => item.FriendlyName 
                    + " MAX : " + _compatibilites.GetMaxQuantity(BaseItem, item));
        }

        private void AssociateItem(IItem i)
        {
            if (_associatedItem.ContainsKey(i))
                _associatedItem[i]++;
            else
                _associatedItem.Add(i, 1);
            Refresh();
        }

        /// <summary>
        /// Aggiorna la label di output visualizzando un descrizione
        /// generale dell'item
        /// </summary>
        private void UpdateItemOutput()
        {
            StringBuilder sb = new StringBuilder();
            if (BaseItem != null)
            {
                sb.Append(BaseItem.FriendlyName);
                foreach (IItem i in _associatedItem.Keys)
                    sb.Append(" + " + i.FriendlyName + 
                        " (" + _associatedItem[i] + ")");
            }
            _itemOutput.Text = sb.ToString();
        }

        private IEnumerable<IItem> FilterSearch(string filter)
        {
            IEnumerable<IItem> result;

            if (BaseItem == null)
                //cerco tra i base item
                result = from i in _compatibilites.BaseItems
                         where FriendlyNameFilter(i, filter)
                         select i;
            else
                //cerco tra gli item associabili del bateItem
                result = from i in _compatibilites.GetAllAssociableItems(BaseItem)
                         where FriendlyNameFilter(i, filter)
                         select i;

            return result;
        }

        private bool FriendlyNameFilter(IItem i, String filter)
            => i.FriendlyName.ToLowerInvariant().Contains(filter.ToLowerInvariant());

        #endregion

        #region Handler
        private void SelectBaseItemHandler(Object obj, EventArgs e)
        {
            #region Precondizioni
            if(_lv.SelectedItems.Count != 1)
            {
                MessageBox.Show("Devi selezionare un solo Item");
                return;
            }
            #endregion
            BaseItem = ((((IList)_lv.SelectedItems)[0] as ListViewItem).Tag as IItem);
        }

        private void AssociateItemHandler(Object obj, EventArgs e)
        {
            #region Precondizioni
            if(BaseItem == null)
            {
                MessageBox.Show("Non hai ancora seleziona un baseItem");
                return;
            }
            if (_lv.SelectedItems.Count < 1)
            {
                MessageBox.Show("Devi selezionare almeno un item da associare");
                return;
            }
            #endregion
            IItem itemToAssociate;
            foreach(ListViewItem lvi in _lv.SelectedItems)
            {
                itemToAssociate = lvi.Tag as IItem;
                // Controllo compatibilità
                if (!_compatibilites.CheckCompatibility(itemToAssociate, BaseItem))
                {
                    //componente non compatibile
                    MessageBox.Show("L'item non è comptabile con " + BaseItem.FriendlyName);
                    continue;
                }
                if(_associatedItem.ContainsKey(itemToAssociate) 
                    && _associatedItem[itemToAssociate] >= _compatibilites.GetMaxQuantity(BaseItem, itemToAssociate))
                {
                    //Non puoi associare altri componenti
                    MessageBox.Show("Hai raggiunto il numero massimo di associazioni");
                    return;
                }
                AssociateItem(itemToAssociate);
            }
        }

        private void ResetHandler(Object obj, EventArgs e)
        {
            _associatedItem = new Dictionary<IItem, int>();
            BaseItem = null;
        }

        private void SearchChanged(Object obj, EventArgs e)
        {
            if (!(obj is TextBox))
                // Non posso gestire l'evento
                return;
            PopulateListView(FilterSearch((obj as TextBox).Text));
        }
        #endregion

    }
}
