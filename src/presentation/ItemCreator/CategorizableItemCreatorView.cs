using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSB_Project.src.presentation.Utils;
using CSB_Project.src.business;
using CSB_Project.src.model.Category;

namespace CSB_Project.src.presentation.ItemCreator
{
    public partial class CategorizableItemCreatorView : Form
    {
        public TableLayoutPanel TableLayout => _tableLayout;
        public NumericUpDown PriceBox => _basicItemControl.PriceBox;
        public TextBox FriendlyNameBox => _basicItemControl.FriendlyNameBox;
        public TextBox IdentifierBox => _basicItemControl.IdentifierBox;
        public TextBox DescriptionBox => _basicItemControl.DescriptionBox;
        public BasicItemControl Control => _basicItemControl;
        public Button AddButton => _addButton;

        public CategorizableItemCreatorView()
        {
            InitializeComponent();
        }

    }
}
