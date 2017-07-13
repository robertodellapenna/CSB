namespace Lab3.Presentation
{
    partial class SelectBookableItemDialog
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
            this._comboBoxStructure = new System.Windows.Forms.ComboBox();
            this._labelStructure = new System.Windows.Forms.Label();
            this._bottomPanel = new System.Windows.Forms.Panel();
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._labelArea = new System.Windows.Forms.Label();
            this._comboBoxArea = new System.Windows.Forms.ComboBox();
            this._labelSector = new System.Windows.Forms.Label();
            this._comboBoxSector = new System.Windows.Forms.ComboBox();
            this._labelRow = new System.Windows.Forms.Label();
            this._labeItem = new System.Windows.Forms.Label();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this._dateTimePickerDa = new System.Windows.Forms.DateTimePicker();
            this._labelA = new System.Windows.Forms.Label();
            this._dateTimePickerA = new System.Windows.Forms.DateTimePicker();
            this._labelDa = new System.Windows.Forms.Label();
            this._comboBoxRow = new System.Windows.Forms.ComboBox();
            this._labelColumn = new System.Windows.Forms.Label();
            this._comboBoxColumn = new System.Windows.Forms.ComboBox();
            this._labelItemValue = new System.Windows.Forms.Label();
            this._bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _comboBoxStructure
            // 
            this._comboBoxStructure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxStructure.Location = new System.Drawing.Point(163, 57);
            this._comboBoxStructure.Name = "_comboBoxStructure";
            this._comboBoxStructure.Size = new System.Drawing.Size(280, 21);
            this._comboBoxStructure.TabIndex = 5;
            this._comboBoxStructure.SelectedIndexChanged += new System.EventHandler(this.SelectedStructureHandler);
            // 
            // _labelStructure
            // 
            this._labelStructure.Location = new System.Drawing.Point(29, 57);
            this._labelStructure.Name = "_labelStructure";
            this._labelStructure.Size = new System.Drawing.Size(128, 23);
            this._labelStructure.TabIndex = 4;
            this._labelStructure.Text = "Selezionare la struttura";
            this._labelStructure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _bottomPanel
            // 
            this._bottomPanel.BackColor = System.Drawing.Color.White;
            this._bottomPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._bottomPanel.Controls.Add(this._cancelButton);
            this._bottomPanel.Controls.Add(this._okButton);
            this._bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._bottomPanel.Location = new System.Drawing.Point(0, 350);
            this._bottomPanel.Name = "_bottomPanel";
            this._bottomPanel.Size = new System.Drawing.Size(493, 54);
            this._bottomPanel.TabIndex = 8;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(401, 12);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 9;
            this._cancelButton.Text = "Annulla";
            this._cancelButton.Click += new System.EventHandler(this.CancelButtonHandler);
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(313, 12);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 8;
            this._okButton.Text = "OK";
            this._okButton.Click += new System.EventHandler(this.OkButtonHandler);
            // 
            // _labelArea
            // 
            this._labelArea.Location = new System.Drawing.Point(38, 102);
            this._labelArea.Name = "_labelArea";
            this._labelArea.Size = new System.Drawing.Size(128, 23);
            this._labelArea.TabIndex = 9;
            this._labelArea.Text = "Selezionare l\'area";
            this._labelArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _comboBoxArea
            // 
            this._comboBoxArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxArea.Location = new System.Drawing.Point(163, 104);
            this._comboBoxArea.Name = "_comboBoxArea";
            this._comboBoxArea.Size = new System.Drawing.Size(280, 21);
            this._comboBoxArea.TabIndex = 10;
            this._comboBoxArea.SelectedIndexChanged += new System.EventHandler(this.SelectedAreaHandler);
            // 
            // _labelSector
            // 
            this._labelSector.Location = new System.Drawing.Point(22, 144);
            this._labelSector.Name = "_labelSector";
            this._labelSector.Size = new System.Drawing.Size(128, 23);
            this._labelSector.TabIndex = 11;
            this._labelSector.Text = "Selezionare il settore";
            this._labelSector.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _comboBoxSector
            // 
            this._comboBoxSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxSector.Location = new System.Drawing.Point(163, 146);
            this._comboBoxSector.Name = "_comboBoxSector";
            this._comboBoxSector.Size = new System.Drawing.Size(280, 21);
            this._comboBoxSector.TabIndex = 12;
            this._comboBoxSector.SelectedIndexChanged += new System.EventHandler(this.SelectedSectorHandler);
            // 
            // _labelRow
            // 
            this._labelRow.Location = new System.Drawing.Point(22, 192);
            this._labelRow.Name = "_labelRow";
            this._labelRow.Size = new System.Drawing.Size(128, 23);
            this._labelRow.TabIndex = 15;
            this._labelRow.Text = "Selezionare la riga";
            this._labelRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _labeItem
            // 
            this._labeItem.Location = new System.Drawing.Point(24, 286);
            this._labeItem.Name = "_labeItem";
            this._labeItem.Size = new System.Drawing.Size(128, 23);
            this._labeItem.TabIndex = 16;
            this._labeItem.Text = "Elemento";
            this._labeItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this._labelItemValue);
            this.panel1.Controls.Add(this._comboBoxColumn);
            this.panel1.Controls.Add(this._labelColumn);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this._labelStructure);
            this.panel1.Controls.Add(this._labeItem);
            this.panel1.Controls.Add(this._comboBoxRow);
            this.panel1.Controls.Add(this._comboBoxStructure);
            this.panel1.Controls.Add(this._comboBoxSector);
            this.panel1.Controls.Add(this._labelRow);
            this.panel1.Controls.Add(this._comboBoxArea);
            this.panel1.Controls.Add(this._labelArea);
            this.panel1.Controls.Add(this._labelSector);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(493, 350);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this._dateTimePickerDa);
            this.panel2.Controls.Add(this._labelA);
            this.panel2.Controls.Add(this._dateTimePickerA);
            this.panel2.Controls.Add(this._labelDa);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(493, 51);
            this.panel2.TabIndex = 18;
            // 
            // _dateTimePickerDa
            // 
            this._dateTimePickerDa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dateTimePickerDa.Location = new System.Drawing.Point(80, 3);
            this._dateTimePickerDa.Name = "_dateTimePickerDa";
            this._dateTimePickerDa.Size = new System.Drawing.Size(409, 20);
            this._dateTimePickerDa.TabIndex = 1;
            this._dateTimePickerDa.Value = new System.DateTime(2017, 7, 11, 14, 38, 4, 0);
            this._dateTimePickerDa.ValueChanged += new System.EventHandler(this.DateFromChangedHandler);
            // 
            // _labelA
            // 
            this._labelA.AutoSize = true;
            this._labelA.BackColor = System.Drawing.Color.White;
            this._labelA.Location = new System.Drawing.Point(29, 33);
            this._labelA.Name = "_labelA";
            this._labelA.Size = new System.Drawing.Size(14, 13);
            this._labelA.TabIndex = 4;
            this._labelA.Text = "A";
            // 
            // _dateTimePickerA
            // 
            this._dateTimePickerA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dateTimePickerA.Location = new System.Drawing.Point(80, 27);
            this._dateTimePickerA.Name = "_dateTimePickerA";
            this._dateTimePickerA.Size = new System.Drawing.Size(409, 20);
            this._dateTimePickerA.TabIndex = 2;
            this._dateTimePickerA.Value = new System.DateTime(2017, 9, 30, 0, 0, 0, 0);
            this._dateTimePickerA.ValueChanged += new System.EventHandler(this.DateToChangedHandler);
            // 
            // _labelDa
            // 
            this._labelDa.AutoSize = true;
            this._labelDa.BackColor = System.Drawing.Color.White;
            this._labelDa.Location = new System.Drawing.Point(22, 9);
            this._labelDa.Name = "_labelDa";
            this._labelDa.Size = new System.Drawing.Size(21, 13);
            this._labelDa.TabIndex = 3;
            this._labelDa.Text = "Da";
            // 
            // _comboBoxRow
            // 
            this._comboBoxRow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxRow.Location = new System.Drawing.Point(163, 194);
            this._comboBoxRow.Name = "_comboBoxRow";
            this._comboBoxRow.Size = new System.Drawing.Size(280, 21);
            this._comboBoxRow.TabIndex = 13;
            this._comboBoxRow.SelectedIndexChanged += new System.EventHandler(this.SelectedRowHandler);
            // 
            // _labelColumn
            // 
            this._labelColumn.AutoSize = true;
            this._labelColumn.Location = new System.Drawing.Point(38, 242);
            this._labelColumn.Name = "_labelColumn";
            this._labelColumn.Size = new System.Drawing.Size(114, 13);
            this._labelColumn.TabIndex = 21;
            this._labelColumn.Text = "Selezionare la colonna";
            // 
            // _comboBoxColumn
            // 
            this._comboBoxColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxColumn.Location = new System.Drawing.Point(163, 239);
            this._comboBoxColumn.Name = "_comboBoxColumn";
            this._comboBoxColumn.Size = new System.Drawing.Size(280, 21);
            this._comboBoxColumn.TabIndex = 23;
            this._comboBoxColumn.SelectedIndexChanged += new System.EventHandler(this.SelectedColumnHandler);
            // 
            // _labelItemValue
            // 
            this._labelItemValue.AutoSize = true;
            this._labelItemValue.Location = new System.Drawing.Point(206, 291);
            this._labelItemValue.Name = "_labelItemValue";
            this._labelItemValue.Size = new System.Drawing.Size(0, 13);
            this._labelItemValue.TabIndex = 24;
            // 
            // SelectBookableItemDialog
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(493, 404);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._bottomPanel);
            this.Name = "SelectBookableItemDialog";
            this.Text = "SelectDialog";
            this._bottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox _comboBoxStructure;
        private System.Windows.Forms.Label _labelStructure;
        private System.Windows.Forms.Panel _bottomPanel;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Label _labelArea;
        private System.Windows.Forms.ComboBox _comboBoxArea;
        private System.Windows.Forms.Label _labelSector;
        private System.Windows.Forms.ComboBox _comboBoxSector;
        private System.Windows.Forms.Label _labelRow;
        private System.Windows.Forms.Label _labeItem;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker _dateTimePickerDa;
        private System.Windows.Forms.Label _labelA;
        private System.Windows.Forms.DateTimePicker _dateTimePickerA;
        private System.Windows.Forms.Label _labelDa;
        private System.Windows.Forms.ComboBox _comboBoxRow;
        private System.Windows.Forms.ComboBox _comboBoxColumn;
        private System.Windows.Forms.Label _labelColumn;
        private System.Windows.Forms.Label _labelItemValue;
    }
}