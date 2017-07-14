namespace CSB_Project.src.presentation
{
    partial class AddItemPrenotationDialog
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
            this._centralPanel = new System.Windows.Forms.Panel();
            this._pluginListView = new System.Windows.Forms.ListView();
            this._rangeLabelValue = new System.Windows.Forms.Label();
            this._positionLabelValue = new System.Windows.Forms.Label();
            this._locationLabelValue = new System.Windows.Forms.Label();
            this._itemLabelValue = new System.Windows.Forms.Label();
            this._pluginsLabel = new System.Windows.Forms.Label();
            this._rangeLabel = new System.Windows.Forms.Label();
            this._positionLabel = new System.Windows.Forms.Label();
            this._locationLabel = new System.Windows.Forms.Label();
            this._itemLabel = new System.Windows.Forms.Label();
            this._addPluginItemButton = new System.Windows.Forms.Button();
            this._addBookableItemButton = new System.Windows.Forms.Button();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._fromLabel = new System.Windows.Forms.Label();
            this._toLabel = new System.Windows.Forms.Label();
            this._bottomPanel.SuspendLayout();
            this._centralPanel.SuspendLayout();
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
            this._bottomPanel.Location = new System.Drawing.Point(0, 421);
            this._bottomPanel.Name = "_bottomPanel";
            this._bottomPanel.Size = new System.Drawing.Size(586, 60);
            this._bottomPanel.TabIndex = 9;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.BackColor = System.Drawing.SystemColors.Control;
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(494, 18);
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
            this._okButton.Location = new System.Drawing.Point(406, 18);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 8;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = false;
            // 
            // _centralPanel
            // 
            this._centralPanel.BackColor = System.Drawing.Color.White;
            this._centralPanel.Controls.Add(this._toLabel);
            this._centralPanel.Controls.Add(this._fromLabel);
            this._centralPanel.Controls.Add(this._toDateTimePicker);
            this._centralPanel.Controls.Add(this._fromDateTimePicker);
            this._centralPanel.Controls.Add(this._pluginListView);
            this._centralPanel.Controls.Add(this._rangeLabelValue);
            this._centralPanel.Controls.Add(this._positionLabelValue);
            this._centralPanel.Controls.Add(this._locationLabelValue);
            this._centralPanel.Controls.Add(this._itemLabelValue);
            this._centralPanel.Controls.Add(this._pluginsLabel);
            this._centralPanel.Controls.Add(this._rangeLabel);
            this._centralPanel.Controls.Add(this._positionLabel);
            this._centralPanel.Controls.Add(this._locationLabel);
            this._centralPanel.Controls.Add(this._itemLabel);
            this._centralPanel.Controls.Add(this._addPluginItemButton);
            this._centralPanel.Controls.Add(this._addBookableItemButton);
            this._centralPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._centralPanel.Location = new System.Drawing.Point(0, 0);
            this._centralPanel.Name = "_centralPanel";
            this._centralPanel.Size = new System.Drawing.Size(586, 421);
            this._centralPanel.TabIndex = 10;
            // 
            // _pluginListView
            // 
            this._pluginListView.BackColor = System.Drawing.Color.White;
            this._pluginListView.Location = new System.Drawing.Point(124, 308);
            this._pluginListView.Name = "_pluginListView";
            this._pluginListView.Size = new System.Drawing.Size(387, 97);
            this._pluginListView.TabIndex = 11;
            this._pluginListView.UseCompatibleStateImageBehavior = false;
            // 
            // _rangeLabelValue
            // 
            this._rangeLabelValue.AutoSize = true;
            this._rangeLabelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._rangeLabelValue.Location = new System.Drawing.Point(132, 168);
            this._rangeLabelValue.Name = "_rangeLabelValue";
            this._rangeLabelValue.Size = new System.Drawing.Size(0, 13);
            this._rangeLabelValue.TabIndex = 10;
            // 
            // _positionLabelValue
            // 
            this._positionLabelValue.AutoSize = true;
            this._positionLabelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._positionLabelValue.Location = new System.Drawing.Point(132, 134);
            this._positionLabelValue.Name = "_positionLabelValue";
            this._positionLabelValue.Size = new System.Drawing.Size(0, 13);
            this._positionLabelValue.TabIndex = 9;
            // 
            // _locationLabelValue
            // 
            this._locationLabelValue.AutoSize = true;
            this._locationLabelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._locationLabelValue.Location = new System.Drawing.Point(132, 96);
            this._locationLabelValue.Name = "_locationLabelValue";
            this._locationLabelValue.Size = new System.Drawing.Size(0, 13);
            this._locationLabelValue.TabIndex = 8;
            // 
            // _itemLabelValue
            // 
            this._itemLabelValue.AutoSize = true;
            this._itemLabelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._itemLabelValue.Location = new System.Drawing.Point(132, 56);
            this._itemLabelValue.Name = "_itemLabelValue";
            this._itemLabelValue.Size = new System.Drawing.Size(0, 13);
            this._itemLabelValue.TabIndex = 7;
            // 
            // _pluginsLabel
            // 
            this._pluginsLabel.AutoSize = true;
            this._pluginsLabel.Location = new System.Drawing.Point(21, 308);
            this._pluginsLabel.Name = "_pluginsLabel";
            this._pluginsLabel.Size = new System.Drawing.Size(64, 13);
            this._pluginsLabel.TabIndex = 6;
            this._pluginsLabel.Text = "Lista Plug-in";
            // 
            // _rangeLabel
            // 
            this._rangeLabel.AutoSize = true;
            this._rangeLabel.Location = new System.Drawing.Point(43, 168);
            this._rangeLabel.Name = "_rangeLabel";
            this._rangeLabel.Size = new System.Drawing.Size(42, 13);
            this._rangeLabel.TabIndex = 5;
            this._rangeLabel.Text = "Range ";
            // 
            // _positionLabel
            // 
            this._positionLabel.AutoSize = true;
            this._positionLabel.Location = new System.Drawing.Point(33, 134);
            this._positionLabel.Name = "_positionLabel";
            this._positionLabel.Size = new System.Drawing.Size(52, 13);
            this._positionLabel.TabIndex = 4;
            this._positionLabel.Text = "Posizione";
            // 
            // _locationLabel
            // 
            this._locationLabel.AutoSize = true;
            this._locationLabel.Location = new System.Drawing.Point(29, 96);
            this._locationLabel.Name = "_locationLabel";
            this._locationLabel.Size = new System.Drawing.Size(56, 13);
            this._locationLabel.TabIndex = 3;
            this._locationLabel.Text = "Locazione";
            // 
            // _itemLabel
            // 
            this._itemLabel.AutoSize = true;
            this._itemLabel.Location = new System.Drawing.Point(34, 56);
            this._itemLabel.Name = "_itemLabel";
            this._itemLabel.Size = new System.Drawing.Size(51, 13);
            this._itemLabel.TabIndex = 2;
            this._itemLabel.Text = "Elemento";
            // 
            // _addPluginItemButton
            // 
            this._addPluginItemButton.BackColor = System.Drawing.SystemColors.Control;
            this._addPluginItemButton.Location = new System.Drawing.Point(202, 204);
            this._addPluginItemButton.Name = "_addPluginItemButton";
            this._addPluginItemButton.Size = new System.Drawing.Size(168, 23);
            this._addPluginItemButton.TabIndex = 1;
            this._addPluginItemButton.Text = "Associa Plug-in";
            this._addPluginItemButton.UseVisualStyleBackColor = false;
            this._addPluginItemButton.Click += new System.EventHandler(this.AddPluginItemButtonHandler);
            // 
            // _addBookableItemButton
            // 
            this._addBookableItemButton.BackColor = System.Drawing.SystemColors.Control;
            this._addBookableItemButton.Location = new System.Drawing.Point(202, 12);
            this._addBookableItemButton.Name = "_addBookableItemButton";
            this._addBookableItemButton.Size = new System.Drawing.Size(168, 27);
            this._addBookableItemButton.TabIndex = 0;
            this._addBookableItemButton.Text = "Aggiungi elemento prenotabile";
            this._addBookableItemButton.UseVisualStyleBackColor = false;
            this._addBookableItemButton.Click += new System.EventHandler(this.AddBookableItemButtonHandler);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // _fromDateTimePicker
            // 
            this._fromDateTimePicker.Location = new System.Drawing.Point(252, 233);
            this._fromDateTimePicker.Name = "_fromDateTimePicker";
            this._fromDateTimePicker.Size = new System.Drawing.Size(201, 20);
            this._fromDateTimePicker.TabIndex = 12;
            this._fromDateTimePicker.ValueChanged += new System.EventHandler(this.FromDateChangedHandler);
            // 
            // _toDateTimePicker
            // 
            this._toDateTimePicker.Location = new System.Drawing.Point(253, 259);
            this._toDateTimePicker.Name = "_toDateTimePicker";
            this._toDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this._toDateTimePicker.TabIndex = 13;
            this._toDateTimePicker.ValueChanged += new System.EventHandler(this.ToDateChangedHandler);
            // 
            // _fromLabel
            // 
            this._fromLabel.AutoSize = true;
            this._fromLabel.Location = new System.Drawing.Point(199, 239);
            this._fromLabel.Name = "_fromLabel";
            this._fromLabel.Size = new System.Drawing.Size(21, 13);
            this._fromLabel.TabIndex = 14;
            this._fromLabel.Text = "Da";
            // 
            // _toLabel
            // 
            this._toLabel.AutoSize = true;
            this._toLabel.Location = new System.Drawing.Point(199, 265);
            this._toLabel.Name = "_toLabel";
            this._toLabel.Size = new System.Drawing.Size(14, 13);
            this._toLabel.TabIndex = 15;
            this._toLabel.Text = "A";
            // 
            // AddItemPrenotationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 481);
            this.Controls.Add(this._centralPanel);
            this.Controls.Add(this._bottomPanel);
            this.Name = "AddItemPrenotationDialog";
            this.Text = "AddItemPrenotationDialog";
            this._bottomPanel.ResumeLayout(false);
            this._centralPanel.ResumeLayout(false);
            this._centralPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _bottomPanel;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Panel _centralPanel;
        private System.Windows.Forms.Label _pluginsLabel;
        private System.Windows.Forms.Label _rangeLabel;
        private System.Windows.Forms.Label _positionLabel;
        private System.Windows.Forms.Label _locationLabel;
        private System.Windows.Forms.Label _itemLabel;
        private System.Windows.Forms.Button _addPluginItemButton;
        private System.Windows.Forms.Button _addBookableItemButton;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.ListView _pluginListView;
        private System.Windows.Forms.Label _rangeLabelValue;
        private System.Windows.Forms.Label _positionLabelValue;
        private System.Windows.Forms.Label _locationLabelValue;
        private System.Windows.Forms.Label _itemLabelValue;
        private System.Windows.Forms.Label _toLabel;
        private System.Windows.Forms.Label _fromLabel;
        private System.Windows.Forms.DateTimePicker _toDateTimePicker;
        private System.Windows.Forms.DateTimePicker _fromDateTimePicker;
    }
}