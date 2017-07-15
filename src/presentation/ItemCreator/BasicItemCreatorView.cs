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
    public partial class BasicItemCreatorView : Form
    {
        public NumericUpDown PriceBox => _basicItemControl.PriceBox;
        public TextBox FriendlyNameBox => _basicItemControl.FriendlyNameBox;
        public TextBox IdentifierBox => _basicItemControl.IdentifierBox;
        public TextBox DescriptionBox => _basicItemControl.DescriptionBox;

        public BasicItemCreatorView() : this(null) { }

        public BasicItemCreatorView(Style style = null)
        {
            InitializeComponent();
            this.ApplyStyle(style);
        }
    }
}
