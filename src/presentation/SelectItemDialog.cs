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

        #region Proprietà
        public IItem SelectedItem => _comboBox.SelectedItem as IItem;
        #endregion

        #region Costruttori
        public SelectItemDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodi
        public void LoadItems(IEnumerable items)
        {
            _comboBox.DataSource = items;
        }
        #endregion

        #region Handlers
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
        #endregion
    }
}
