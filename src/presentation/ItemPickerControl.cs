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
    public partial class ItemPickerControl : UserControl
    {
        public TextBox SearchBox => _searchBox;
        public ListView ItemListView => _itemsListView;
        public Button BaseItemButton => _baseItemButton;
        public Button AssociateItemButton => _associateItemButton;
        public Button ResetButton => _resetButton;
        public Label Output => _generatedItem;
        
        public ItemPickerControl() : this(null)
        {
            
        }

        public ItemPickerControl(Style style = null)
        {
            InitializeComponent();
            this.ApplyStyle(style);
        }
    }
}
