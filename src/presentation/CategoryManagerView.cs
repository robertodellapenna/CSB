﻿using System;
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

        public CategoryManagerView()
        {
            InitializeComponent();
        }
    }
}
