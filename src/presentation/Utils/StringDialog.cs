using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSB_Project.src.presentation.Utils
{
    public partial class StringDialog : Form
    {

        private bool _emptyResponse;
        public string Response => _answer.Text;


        public StringDialog(string question = "", bool emptyResponse = false, Style style = null)
        {
            #region Precondizioni
            if (question == null)
                throw new ArgumentNullException("question null");
            #endregion
            InitializeComponent();
            _question.Text = question;
            _emptyResponse = emptyResponse;
            ActiveControl = _answer;
            this.ApplyStyle(style);
        }

        public void OkButtonHandler( Object obj, EventArgs e)
        {
            _errorProvider.Clear();
            if(!_emptyResponse && String.IsNullOrWhiteSpace(Response))
            {
                _errorProvider.SetError(_answer, "La risposta non può essere vuota");
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        public void CancelButtonHandler(Object obj, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void StringDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
