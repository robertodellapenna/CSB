using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSB_Project.src.presentation.Utils;

namespace CSB_Project.src.presentation
{
    public partial class ItemPickerView : Form
    {
        public TextBox SearchBox => _searchBox;
        public ListView ItemListView => _itemsListView;
        public Button BaseItemButton => _baseItemButton;
        public Button AssociateItemButton => _associateItemButton;
        public Button ResetButton => _resetButton;
        public Label Output => _generatedItem;
        
        public ItemPickerView() : this(null)
        {
            
        }

        public ItemPickerView(Style style = null)
        {
            InitializeComponent();
            this.ApplyStyle(style);
        }

        private void ItemPickerControl_Load(object sender, EventArgs e)
        {

        }
    }
}
