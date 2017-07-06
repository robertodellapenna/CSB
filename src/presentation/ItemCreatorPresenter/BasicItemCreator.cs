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
        public TextBox Price => _priceTextBox;
        public TextBox FriendlyName => _nameTextBox;
        public TextBox Identifier => _identifierTextBox;
        public TextBox Description => _descriptioonTextBox;

        public BasicItemCreator() : this(null) { }

        public BasicItemCreator(Style style = null)
        {
            InitializeComponent();
            this.ApplyStyle(style);
        }
    }
}
