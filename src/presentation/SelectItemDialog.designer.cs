namespace CSB_Project.src.presentation
{
    partial class SelectItemDialog
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
            this._comboBox = new System.Windows.Forms.ComboBox();
            this._label = new System.Windows.Forms.Label();
            this._bottomPanel = new System.Windows.Forms.Panel();
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _comboBox
            // 
            this._comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBox.Location = new System.Drawing.Point(152, 24);
            this._comboBox.Name = "_comboBox";
            this._comboBox.Size = new System.Drawing.Size(280, 21);
            this._comboBox.TabIndex = 5;
            // 
            // _label
            // 
            this._label.Location = new System.Drawing.Point(24, 24);
            this._label.Name = "_label";
            this._label.Size = new System.Drawing.Size(128, 23);
            this._label.TabIndex = 4;
            this._label.Text = "Selezionare l\'elemento:";
            this._label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _bottomPanel
            // 
            this._bottomPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._bottomPanel.Controls.Add(this._cancelButton);
            this._bottomPanel.Controls.Add(this._okButton);
            this._bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._bottomPanel.Location = new System.Drawing.Point(0, 70);
            this._bottomPanel.Name = "_bottomPanel";
            this._bottomPanel.Size = new System.Drawing.Size(452, 60);
            this._bottomPanel.TabIndex = 8;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(360, 18);
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
            this._okButton.Location = new System.Drawing.Point(272, 18);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 8;
            this._okButton.Text = "OK";
            this._okButton.Click += new System.EventHandler(this.OkButtonHandler);
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // SelectItemDialog
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(452, 130);
            this.Controls.Add(this._bottomPanel);
            this.Controls.Add(this._comboBox);
            this.Controls.Add(this._label);
            this.Name = "SelectItemDialog";
            this.Text = "SelectItemDialog";
            this._bottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox _comboBox;
        private System.Windows.Forms.Label _label;
        private System.Windows.Forms.Panel _bottomPanel;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.ErrorProvider _errorProvider;
    }
}