using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSB_Project.src.presentation.Utils;

namespace CSB_Project.src.presentation.ItemCreator
{
    public partial class BasicItemControl : UserControl
    {
        public NumericUpDown PriceBox => _priceBox;
        public TextBox FriendlyNameBox => _nameTextBox;
        public TextBox IdentifierBox => _identifierTextBox;
        public TextBox DescriptionBox => _descriptioonTextBox;
        public ErrorProvider ErrorProvider => _errorProvider;

        public BasicItemControl() {
            InitializeComponent();
        }
    }
}
