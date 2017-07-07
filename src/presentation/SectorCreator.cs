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
    public partial class SectorCreator : UserControl
    {
        public TextBox Rows => this._rowsTextBox;
        public TextBox Cols => this._colsTextBox;
        public TextBox FriendlyName => this._nameTextBox;
        public TextBox Description => this._descriptioonTextBox;
        public TextBox Price => this._priceTextBox;

        public SectorCreator()
        {
            InitializeComponent();
        }

        public SectorCreator(Style style = null)
        {
            InitializeComponent();
            this.ApplyStyle(style);
        }

    }
}
