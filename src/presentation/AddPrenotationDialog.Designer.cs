namespace CSB_Project.src.presentation
{
    partial class AddPrenotationDialog
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
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this._trackingDeviceListView = new System.Windows.Forms.ListView();
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
            this._clientButton = new System.Windows.Forms.Button();
            this._clientComboBox = new System.Windows.Forms.ComboBox();
            this._bottomPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _bottomPanel
            // 
            this._bottomPanel.BackColor = System.Drawing.Color.White;
            this._bottomPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._bottomPanel.Controls.Add(this._cancelButton);
            this._bottomPanel.Controls.Add(this._okButton);
            this._bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._bottomPanel.Location = new System.Drawing.Point(0, 687);
            this._bottomPanel.Name = "_bottomPanel";
            this._bottomPanel.Size = new System.Drawing.Size(793, 54);
            this._bottomPanel.TabIndex = 10;
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
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.BackColor = System.Drawing.SystemColors.Control;
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(620, 18);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 8;
            this._okButton.Text = "Crea";
            this._okButton.UseVisualStyleBackColor = false;
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
            // panel1
            // 
            this.panel1.Controls.Add(this._clientComboBox);
            this.panel1.Controls.Add(this._clientButton);
            this.panel1.Controls.Add(this._trackingDeviceListView);
            this.panel1.Controls.Add(this._packetListView);
            this.panel1.Controls.Add(this._bundleListView);
            this.panel1.Controls.Add(this._itemPrenotationListView);
            this.panel1.Controls.Add(this._aLabel);
            this.panel1.Controls.Add(this._fromLabel);
            this.panel1.Controls.Add(this._associateTrackingDeviceButton);
            this.panel1.Controls.Add(this._addPacketButton);
            this.panel1.Controls.Add(this._addBundleButton);
            this.panel1.Controls.Add(this._addItemPrenotationButton);
            this.panel1.Controls.Add(this._fromDateTimePicker);
            this.panel1.Controls.Add(this._toDateTimePicker);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 687);
            this.panel1.TabIndex = 13;
            // 
            // _trackingDeviceListView
            // 
            this._trackingDeviceListView.Location = new System.Drawing.Point(221, 556);
            this._trackingDeviceListView.Name = "_trackingDeviceListView";
            this._trackingDeviceListView.Size = new System.Drawing.Size(556, 96);
            this._trackingDeviceListView.TabIndex = 22;
            this._trackingDeviceListView.UseCompatibleStateImageBehavior = false;
            // 
            // _packetListView
            // 
            this._packetListView.Location = new System.Drawing.Point(221, 448);
            this._packetListView.Name = "_packetListView";
            this._packetListView.Size = new System.Drawing.Size(556, 102);
            this._packetListView.TabIndex = 21;
            this._packetListView.UseCompatibleStateImageBehavior = false;
            // 
            // _bundleListView
            // 
            this._bundleListView.Location = new System.Drawing.Point(221, 328);
            this._bundleListView.Name = "_bundleListView";
            this._bundleListView.Size = new System.Drawing.Size(556, 114);
            this._bundleListView.TabIndex = 20;
            this._bundleListView.UseCompatibleStateImageBehavior = false;
            // 
            // _itemPrenotationListView
            // 
            this._itemPrenotationListView.Location = new System.Drawing.Point(221, 104);
            this._itemPrenotationListView.Name = "_itemPrenotationListView";
            this._itemPrenotationListView.Size = new System.Drawing.Size(556, 218);
            this._itemPrenotationListView.TabIndex = 19;
            this._itemPrenotationListView.UseCompatibleStateImageBehavior = false;
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
            this._associateTrackingDeviceButton.Location = new System.Drawing.Point(21, 556);
            this._associateTrackingDeviceButton.Name = "_associateTrackingDeviceButton";
            this._associateTrackingDeviceButton.Size = new System.Drawing.Size(173, 23);
            this._associateTrackingDeviceButton.TabIndex = 16;
            this._associateTrackingDeviceButton.Text = "Associa Tracking Device";
            this._associateTrackingDeviceButton.UseVisualStyleBackColor = false;
            // 
            // _addPacketButton
            // 
            this._addPacketButton.BackColor = System.Drawing.SystemColors.Control;
            this._addPacketButton.Location = new System.Drawing.Point(21, 448);
            this._addPacketButton.Name = "_addPacketButton";
            this._addPacketButton.Size = new System.Drawing.Size(173, 23);
            this._addPacketButton.TabIndex = 15;
            this._addPacketButton.Text = "Aggiungi Pacchetto";
            this._addPacketButton.UseVisualStyleBackColor = false;
            // 
            // _addBundleButton
            // 
            this._addBundleButton.BackColor = System.Drawing.SystemColors.Control;
            this._addBundleButton.Location = new System.Drawing.Point(21, 328);
            this._addBundleButton.Name = "_addBundleButton";
            this._addBundleButton.Size = new System.Drawing.Size(173, 23);
            this._addBundleButton.TabIndex = 14;
            this._addBundleButton.Text = "Aggiungi Bundle";
            this._addBundleButton.UseVisualStyleBackColor = false;
            // 
            // _addItemPrenotationButton
            // 
            this._addItemPrenotationButton.BackColor = System.Drawing.SystemColors.Control;
            this._addItemPrenotationButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this._addItemPrenotationButton.Location = new System.Drawing.Point(12, 104);
            this._addItemPrenotationButton.Name = "_addItemPrenotationButton";
            this._addItemPrenotationButton.Size = new System.Drawing.Size(173, 23);
            this._addItemPrenotationButton.TabIndex = 13;
            this._addItemPrenotationButton.Text = "Aggiungi Elemento Prenotazione";
            this._addItemPrenotationButton.UseVisualStyleBackColor = false;
            this._addItemPrenotationButton.Click += new System.EventHandler(this.AddItemPrenotationButtonHandler);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // _clientButton
            // 
            this._clientButton.BackColor = System.Drawing.SystemColors.Control;
            this._clientButton.Location = new System.Drawing.Point(21, 658);
            this._clientButton.Name = "_clientButton";
            this._clientButton.Size = new System.Drawing.Size(173, 23);
            this._clientButton.TabIndex = 23;
            this._clientButton.Text = "Seleziona Cliente";
            this._clientButton.UseVisualStyleBackColor = false;
            // 
            // _clientComboBox
            // 
            this._clientComboBox.FormattingEnabled = true;
            this._clientComboBox.Location = new System.Drawing.Point(558, 658);
            this._clientComboBox.Name = "_clientComboBox";
            this._clientComboBox.Size = new System.Drawing.Size(219, 21);
            this._clientComboBox.TabIndex = 24;
            // 
            // AddPrenotationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(793, 741);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._bottomPanel);
            this.Name = "AddPrenotationDialog";
            this.Text = "AddPrenotationDialog";
            this._bottomPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _bottomPanel;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.DateTimePicker _fromDateTimePicker;
        private System.Windows.Forms.DateTimePicker _toDateTimePicker;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView _trackingDeviceListView;
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
        private System.Windows.Forms.Button _clientButton;
    }
}