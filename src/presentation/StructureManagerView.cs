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
    public partial class StructureManagerView : Form
    {
        public Button AddButton => _addButton;
        public Button ModifyButton => _modifyButton;
        public Button DeleteButton => _deleteButton;

        public TreeView TreeView => _treeView;
        public DateTimePicker FromDate => _dateTimePickerDa;
        public DateTimePicker ToDate => _dateTimePickerA;
        public Panel BottomPanel => _actionPanel;

        public StructureManagerView(Style style = null)
        {
            InitializeComponent();
            this.ApplyStyle(style);
        }
    }
}
