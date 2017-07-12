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
    public partial class ServiceDialog : Form
    {
        private bool _emptyResponse;
        public string NameText => _nameBox.Text;
        public string Description => _descriptionBox.Text;
        public decimal Price => _priceBox.Value;
        public DateTime Start => _startDateBox.Value;
        public DateTime End => _endDateBox.Value;

        public ServiceDialog(string question = "", bool emptyResponse = false, Style style = null)
        {
            #region Precondizioni
            if (question == null)
                throw new ArgumentNullException("question null");
            #endregion
            InitializeComponent();
            _question.Text = question;
            _emptyResponse = emptyResponse;
            _startDateBox.MinDate = DateTime.Now;
            _priceBox.Minimum = 0;
            _startDateBox.ValueChanged += UpdateEndDateBoxHandler;
            _nameBox.TextChanged += CheckNotNullHandler;
            _descriptionBox.TextChanged += CheckNotNullHandler;
            UpdateEndDateBoxHandler(this, EventArgs.Empty);
            CheckNotNullHandler(_nameBox, EventArgs.Empty);
            CheckNotNullHandler(_descriptionBox, EventArgs.Empty);
            this.ApplyStyle(style);
        }

        private void CheckNotNullHandler(object sender, EventArgs e)
        {
            if (!(sender is TextBox))
                return;
            _errorProvider.SetError((sender as TextBox), null);
            if (!_emptyResponse && String.IsNullOrWhiteSpace((sender as TextBox).Text))
                _errorProvider.SetError((sender as TextBox), "Il campo non può essere vuoto");
        }

        public void OkButtonHandler(Object obj, EventArgs e)
        {
            if ((!_emptyResponse && String.IsNullOrWhiteSpace(NameText))
                || (!_emptyResponse && String.IsNullOrWhiteSpace(Description))
                )
                    return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButtonHandler(Object o, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void UpdateEndDateBoxHandler(Object o, EventArgs e)
        {
            if (End.Date < Start.Date)
                _endDateBox.Value = Start;
            _endDateBox.MinDate = Start.Date;
        }

        private void ServiceDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
