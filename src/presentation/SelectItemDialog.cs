using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;
using CSB_Project.src.model.Item;

namespace CSB_Project.src.presentation
{
    public partial class SelectItemDialog : Form
    {
        public SelectItemDialog()
        {
            InitializeComponent();
        }

        public IItem SelectedItem =>  _comboBox.SelectedItem as IItem;

        public void LoadItems(IEnumerable items)
        {
            _comboBox.DataSource = items;
        }

        public void OkButtonHandler(Object obj, EventArgs e)
        {
            _errorProvider.Clear();
            if (SelectedItem == null)
                Close();
            DialogResult = DialogResult.OK;
            Close();
        }

        public void CancelButtonHandler(Object obj, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
