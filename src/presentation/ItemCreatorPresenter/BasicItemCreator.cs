using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSB_Project.src.presentation.Utils;

namespace CSB_Project.src.presentation.ItemCreatorPresenter
{
    public partial class BasicItemCreator : UserControl
    {
        public NumericUpDown PriceBox => _priceBox;
        public TextBox FriendlyNameBox => _nameTextBox;
        public TextBox IdentifierBox => _identifierTextBox;
        public TextBox DescriptionBox => _descriptioonTextBox;

        public BasicItemCreator() : this(null) { }

        public BasicItemCreator(Style style = null)
        {
            InitializeComponent();
            this.ApplyStyle(style);
        }
    }
}
