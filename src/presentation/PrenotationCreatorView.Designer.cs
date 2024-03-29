﻿namespace CSB_Project.src.presentation
{
    partial class PrenotationCreatorView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._bottomPanel = new System.Windows.Forms.Panel();
            this._clearButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._createButton = new System.Windows.Forms.Button();
            this._fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._panel = new System.Windows.Forms.Panel();
            this._customerLabel = new System.Windows.Forms.Label();
            this._tdLabelValue = new System.Windows.Forms.Label();
            this._clientComboBox = new System.Windows.Forms.ComboBox();
            this._packetListView = new System.Windows.Forms.ListView();
            this._bundleListView = new System.Windows.Forms.ListView();
            this._itemPrenotationListView = new System.Windows.Forms.ListView();
            this._aLabel = new System.Windows.Forms.Label();
            this._fromLabel = new System.Windows.Forms.Label();
            this._associateTrackingDeviceButton = new System.Windows.Forms.Button();
            this._addPacketButton = new System.Windows.Forms.Button();
            this._addBundleButton = new System.Windows.Forms.Button();
            this._addItemPrenotationButton = new System.Windows.Forms.Button();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._bottomPanel.SuspendLayout();
            this._panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _bottomPanel
            // 
            this._bottomPanel.BackColor = System.Drawing.Color.White;
            this._bottomPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._bottomPanel.Controls.Add(this._clearButton);
            this._bottomPanel.Controls.Add(this._cancelButton);
            this._bottomPanel.Controls.Add(this._createButton);
            this._bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._bottomPanel.Location = new System.Drawing.Point(0, 453);
            this._bottomPanel.Name = "_bottomPanel";
            this._bottomPanel.Size = new System.Drawing.Size(793, 54);
            this._bottomPanel.TabIndex = 10;
            // 
            // _clearButton
            // 
            this._clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._clearButton.BackColor = System.Drawing.SystemColors.Control;
            this._clearButton.Location = new System.Drawing.Point(539, 18);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(75, 23);
            this._clearButton.TabIndex = 10;
            this._clearButton.Text = "Pulisci";
            this._clearButton.UseVisualStyleBackColor = false;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.BackColor = System.Drawing.SystemColors.Control;
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(701, 18);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 9;
            this._cancelButton.Text = "Annulla";
            this._cancelButton.UseVisualStyleBackColor = false;
            // 
            // _createButton
            // 
            this._createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._createButton.BackColor = System.Drawing.SystemColors.Control;
            this._createButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._createButton.Location = new System.Drawing.Point(620, 18);
            this._createButton.Name = "_createButton";
            this._createButton.Size = new System.Drawing.Size(75, 23);
            this._createButton.TabIndex = 8;
            this._createButton.Text = "Crea";
            this._createButton.UseVisualStyleBackColor = false;
            // 
            // _fromDateTimePicker
            // 
            this._fromDateTimePicker.Location = new System.Drawing.Point(346, 23);
            this._fromDateTimePicker.Name = "_fromDateTimePicker";
            this._fromDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this._fromDateTimePicker.TabIndex = 11;
            this._fromDateTimePicker.Value = new System.DateTime(2017, 6, 1, 0, 0, 0, 0);
            // 
            // _toDateTimePicker
            // 
            this._toDateTimePicker.Location = new System.Drawing.Point(346, 49);
            this._toDateTimePicker.Name = "_toDateTimePicker";
            this._toDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this._toDateTimePicker.TabIndex = 12;
            this._toDateTimePicker.Value = new System.DateTime(2017, 9, 30, 0, 0, 0, 0);
            // 
            // _panel
            // 
            this._panel.Controls.Add(this._customerLabel);
            this._panel.Controls.Add(this._tdLabelValue);
            this._panel.Controls.Add(this._clientComboBox);
            this._panel.Controls.Add(this._packetListView);
            this._panel.Controls.Add(this._bundleListView);
            this._panel.Controls.Add(this._itemPrenotationListView);
            this._panel.Controls.Add(this._aLabel);
            this._panel.Controls.Add(this._fromLabel);
            this._panel.Controls.Add(this._associateTrackingDeviceButton);
            this._panel.Controls.Add(this._addPacketButton);
            this._panel.Controls.Add(this._addBundleButton);
            this._panel.Controls.Add(this._addItemPrenotationButton);
            this._panel.Controls.Add(this._fromDateTimePicker);
            this._panel.Controls.Add(this._toDateTimePicker);
            this._panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panel.Location = new System.Drawing.Point(0, 0);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(793, 453);
            this._panel.TabIndex = 13;
            // 
            // _customerLabel
            // 
            this._customerLabel.AutoSize = true;
            this._customerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._customerLabel.Location = new System.Drawing.Point(75, 378);
            this._customerLabel.Name = "_customerLabel";
            this._customerLabel.Size = new System.Drawing.Size(119, 18);
            this._customerLabel.TabIndex = 26;
            this._customerLabel.Text = "Seleziona cliente";
            // 
            // _tdLabelValue
            // 
            this._tdLabelValue.AutoSize = true;
            this._tdLabelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tdLabelValue.Location = new System.Drawing.Point(555, 337);
            this._tdLabelValue.Name = "_tdLabelValue";
            this._tdLabelValue.Size = new System.Drawing.Size(0, 13);
            this._tdLabelValue.TabIndex = 25;
            // 
            // _clientComboBox
            // 
            this._clientComboBox.FormattingEnabled = true;
            this._clientComboBox.Location = new System.Drawing.Point(346, 378);
            this._clientComboBox.Name = "_clientComboBox";
            this._clientComboBox.Size = new System.Drawing.Size(219, 21);
            this._clientComboBox.TabIndex = 24;
            // 
            // _packetListView
            // 
            this._packetListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this._packetListView.Location = new System.Drawing.Point(221, 260);
            this._packetListView.Name = "_packetListView";
            this._packetListView.Size = new System.Drawing.Size(556, 74);
            this._packetListView.TabIndex = 21;
            this._packetListView.UseCompatibleStateImageBehavior = false;
            this._packetListView.View = System.Windows.Forms.View.List;
            // 
            // _bundleListView
            // 
            this._bundleListView.Location = new System.Drawing.Point(221, 189);
            this._bundleListView.Name = "_bundleListView";
            this._bundleListView.Size = new System.Drawing.Size(556, 65);
            this._bundleListView.TabIndex = 20;
            this._bundleListView.UseCompatibleStateImageBehavior = false;
            this._bundleListView.View = System.Windows.Forms.View.List;
            // 
            // _itemPrenotationListView
            // 
            this._itemPrenotationListView.Location = new System.Drawing.Point(221, 104);
            this._itemPrenotationListView.Name = "_itemPrenotationListView";
            this._itemPrenotationListView.Size = new System.Drawing.Size(556, 79);
            this._itemPrenotationListView.TabIndex = 19;
            this._itemPrenotationListView.UseCompatibleStateImageBehavior = false;
            this._itemPrenotationListView.View = System.Windows.Forms.View.List;
            // 
            // _aLabel
            // 
            this._aLabel.AutoSize = true;
            this._aLabel.Location = new System.Drawing.Point(284, 49);
            this._aLabel.Name = "_aLabel";
            this._aLabel.Size = new System.Drawing.Size(14, 13);
            this._aLabel.TabIndex = 18;
            this._aLabel.Text = "A";
            // 
            // _fromLabel
            // 
            this._fromLabel.AutoSize = true;
            this._fromLabel.Location = new System.Drawing.Point(281, 23);
            this._fromLabel.Name = "_fromLabel";
            this._fromLabel.Size = new System.Drawing.Size(21, 13);
            this._fromLabel.TabIndex = 17;
            this._fromLabel.Text = "Da";
            // 
            // _associateTrackingDeviceButton
            // 
            this._associateTrackingDeviceButton.BackColor = System.Drawing.SystemColors.Control;
            this._associateTrackingDeviceButton.Location = new System.Drawing.Point(21, 337);
            this._associateTrackingDeviceButton.Name = "_associateTrackingDeviceButton";
            this._associateTrackingDeviceButton.Size = new System.Drawing.Size(173, 23);
            this._associateTrackingDeviceButton.TabIndex = 16;
            this._associateTrackingDeviceButton.Text = "Recupera Tracking Device";
            this._associateTrackingDeviceButton.UseVisualStyleBackColor = false;
            // 
            // _addPacketButton
            // 
            this._addPacketButton.BackColor = System.Drawing.SystemColors.Control;
            this._addPacketButton.Location = new System.Drawing.Point(21, 260);
            this._addPacketButton.Name = "_addPacketButton";
            this._addPacketButton.Size = new System.Drawing.Size(173, 23);
            this._addPacketButton.TabIndex = 15;
            this._addPacketButton.Text = "Aggiungi Pacchetti";
            this._addPacketButton.UseVisualStyleBackColor = false;
            // 
            // _addBundleButton
            // 
            this._addBundleButton.BackColor = System.Drawing.SystemColors.Control;
            this._addBundleButton.Location = new System.Drawing.Point(21, 189);
            this._addBundleButton.Name = "_addBundleButton";
            this._addBundleButton.Size = new System.Drawing.Size(173, 23);
            this._addBundleButton.TabIndex = 14;
            this._addBundleButton.Text = "Aggiungi Bundles";
            this._addBundleButton.UseVisualStyleBackColor = false;
            // 
            // _addItemPrenotationButton
            // 
            this._addItemPrenotationButton.BackColor = System.Drawing.SystemColors.Control;
            this._addItemPrenotationButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this._addItemPrenotationButton.Location = new System.Drawing.Point(12, 104);
            this._addItemPrenotationButton.Name = "_addItemPrenotationButton";
            this._addItemPrenotationButton.Size = new System.Drawing.Size(182, 23);
            this._addItemPrenotationButton.TabIndex = 13;
            this._addItemPrenotationButton.Text = "Aggiungi Elemento Prenotazione";
            this._addItemPrenotationButton.UseVisualStyleBackColor = false;
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // PrenotationCreatorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(793, 507);
            this.Controls.Add(this._panel);
            this.Controls.Add(this._bottomPanel);
            this.Name = "PrenotationCreatorView";
            this.Text = "PrenotationCreatorView";
            this._bottomPanel.ResumeLayout(false);
            this._panel.ResumeLayout(false);
            this._panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _bottomPanel;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _createButton;
        private System.Windows.Forms.DateTimePicker _fromDateTimePicker;
        private System.Windows.Forms.DateTimePicker _toDateTimePicker;
        private System.Windows.Forms.Panel _panel;
        private System.Windows.Forms.ListView _packetListView;
        private System.Windows.Forms.ListView _bundleListView;
        private System.Windows.Forms.ListView _itemPrenotationListView;
        private System.Windows.Forms.Label _aLabel;
        private System.Windows.Forms.Label _fromLabel;
        private System.Windows.Forms.Button _associateTrackingDeviceButton;
        private System.Windows.Forms.Button _addPacketButton;
        private System.Windows.Forms.Button _addBundleButton;
        private System.Windows.Forms.Button _addItemPrenotationButton;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.ComboBox _clientComboBox;
        private System.Windows.Forms.Label _tdLabelValue;
        private System.Windows.Forms.Button _clearButton;
        private System.Windows.Forms.Label _customerLabel;
    }
}