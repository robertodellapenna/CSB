using System;
using CSB_Project.src.presentation.Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSB_Project.src.presentation
{
    public partial class ServiceManagerView : Form
    {
        public Button AddButton => _addButton;
        public Button DeleteButton => _deleteButton;
        public ListView ListView => _listView;
        public Panel ActionPanel => _actionPanel;

        public ServiceManagerView(Style style = null)
        {
            InitializeComponent();
            this.ApplyStyle(style);
        }

        private void ServiceManagerView_Load(object sender, EventArgs e)
        {

        }

        private void _listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
