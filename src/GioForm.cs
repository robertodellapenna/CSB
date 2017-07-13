using CSB_Project.src.business;
using CSB_Project.src.presentation;
using CSB_Project.src.presentation.ItemCreatorPresenter;
using CSB_Project.src.presentation.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSB_Project.src
{
    public partial class GioForm : Form
    {
        private CategorizableItemCreator cip;
        public GioForm()
        {
            InitializeComponent();
            ExpandableNode ex = new ExpandableNode();
            ex.Size = new Size(200, 300);
            ex.Children.Add(new ExpandableNode());
            Controls.Add(ex);
            
        }
    }
}
