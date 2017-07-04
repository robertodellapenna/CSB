using CSB_Project.src.presentation.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSB_Project.src.presentation
{
    public partial class CategoryManagerView : Form
    {
        public Button AddButton => _addButton;
        public TreeView TreeView => _treeView;

        public CategoryManagerView(Style style = null)
        {
            InitializeComponent();
            if (style == null)
                style = new Style();
            Style.SetStyle(style, this);
            //this.MinimumSize = new Size(300, 300);
        }
    }
}
