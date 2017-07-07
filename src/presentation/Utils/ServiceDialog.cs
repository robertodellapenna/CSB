﻿using System;
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
        public string NameText => _name.Text;
        public string Description => _description.Text;
        public string Price => _price.Text;
        public string Start => _start.Text;
        public string End => _end.Text;



        public ServiceDialog(string question = "", bool emptyResponse = false, Style style = null)
        {
            InitializeComponent();
            #region Precondizioni
            if (question == null)
                throw new ArgumentNullException("question null");
            #endregion
            InitializeComponent();
            _question.Text = question;
            _emptyResponse = emptyResponse;
            ActiveControl = _name;
            ActiveControl = _price;
            ActiveControl = _description;
            ActiveControl = _start;
            ActiveControl = _end;
            this.ApplyStyle(style);
        }

        public void OkButtonHandler(Object obj, EventArgs e)
        {
            _errorProvider.Clear();
            if (!_emptyResponse && String.IsNullOrWhiteSpace(NameText))
            {
                _errorProvider.SetError(_name, "Il nome non può essere vuota");
                return;
            }

            if (!_emptyResponse && String.IsNullOrWhiteSpace(Description))
            {
                _errorProvider.SetError(_description, "La descrizione non può essere vuota");
                return;
            }

            if (!_emptyResponse && String.IsNullOrWhiteSpace(Price))
            {
                _errorProvider.SetError(_price, "Il prezzo non può essere vuota");
                return;
            }

            if (!_emptyResponse && String.IsNullOrWhiteSpace(Start))
            {
                _errorProvider.SetError(_start, "Il periodo non può essere vuota");
                return;
            }

            if (!_emptyResponse && String.IsNullOrWhiteSpace(End))
            {
                _errorProvider.SetError(_end, "Il periodo non può essere vuota");
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

        private void ServiceDialog_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void start_TextChanged(object sender, EventArgs e)
        {

        }

        private void _description_TextChanged(object sender, EventArgs e)
        {

        }
    }
}