using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSB_Project.src.presentation.Utils;

namespace CSB_Project.src.presentation
{
    public partial class BundleManagerView : Form
    {
        public Button AddButton => _addButton;
        public ListView ListView => _listView;
        public Panel ActionPanel => _actionPanel;

        public BundleManagerView(Style style = null)
        {
            InitializeComponent();
            this.ApplyStyle(style);
        }
    }
}
