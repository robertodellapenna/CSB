namespace CSB_Project.src.presentation.Utils
{
    partial class ServiceDialog
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
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._question = new System.Windows.Forms.Label();
            this._startDateBox = new System.Windows.Forms.DateTimePicker();
            this._descriptionBox = new System.Windows.Forms.TextBox();
            this._nameBox = new System.Windows.Forms.TextBox();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._nameLabel = new System.Windows.Forms.Label();
            this._descriptionLabel = new System.Windows.Forms.Label();
            this._priceLabel = new System.Windows.Forms.Label();
            this._startDateLabel = new System.Windows.Forms.Label();
            this._endDateLabel = new System.Windows.Forms.Label();
            this._endDateBox = new System.Windows.Forms.DateTimePicker();
            this._priceBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._priceBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            this._okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(255)))), ((int)(((byte)(221)))));
            this._okButton.Location = new System.Drawing.Point(23, 268);
            this._okButton.Margin = new System.Windows.Forms.Padding(4);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(76, 26);
            this._okButton.TabIndex = 0;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = false;
            this._okButton.Click += new System.EventHandler(this.OkButtonHandler);
            // 
            // _cancelButton
            // 
            this._cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(308, 268);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(76, 26);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Annulla";
            this._cancelButton.UseVisualStyleBackColor = false;
            this._cancelButton.Click += new System.EventHandler(this.CancelButtonHandler);
            // 
            // _question
            // 
            this._question.AutoSize = true;
            this._question.Location = new System.Drawing.Point(122, 9);
            this._question.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._question.Name = "_question";
            this._question.Size = new System.Drawing.Size(112, 17);
            this._question.TabIndex = 2;
            this._question.Text = "Inserisci Parametri";
            // 
            // _startDateBox
            // 
            this._startDateBox.Location = new System.Drawing.Point(219, 181);
            this._startDateBox.Margin = new System.Windows.Forms.Padding(4);
            this._startDateBox.Name = "_startDateBox";
            this._startDateBox.Size = new System.Drawing.Size(165, 24);
            this._startDateBox.TabIndex = 3;
            // 
            // _descriptionBox
            // 
            this._descriptionBox.Location = new System.Drawing.Point(219, 91);
            this._descriptionBox.Multiline = true;
            this._descriptionBox.Name = "_descriptionBox";
            this._descriptionBox.Size = new System.Drawing.Size(165, 24);
            this._descriptionBox.TabIndex = 5;
            this._descriptionBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _nameBox
            // 
            this._nameBox.Location = new System.Drawing.Point(219, 47);
            this._nameBox.Name = "_nameBox";
            this._nameBox.Size = new System.Drawing.Size(165, 24);
            this._nameBox.TabIndex = 6;
            this._nameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // _nameLabel
            // 
            this._nameLabel.AutoSize = true;
            this._nameLabel.Location = new System.Drawing.Point(20, 47);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(42, 17);
            this._nameLabel.TabIndex = 7;
            this._nameLabel.Text = "Name";
            // 
            // _descriptionLabel
            // 
            this._descriptionLabel.AutoSize = true;
            this._descriptionLabel.Location = new System.Drawing.Point(20, 91);
            this._descriptionLabel.Name = "_descriptionLabel";
            this._descriptionLabel.Size = new System.Drawing.Size(72, 17);
            this._descriptionLabel.TabIndex = 8;
            this._descriptionLabel.Text = "Description";
            // 
            // _priceLabel
            // 
            this._priceLabel.AutoSize = true;
            this._priceLabel.Location = new System.Drawing.Point(20, 135);
            this._priceLabel.Name = "_priceLabel";
            this._priceLabel.Size = new System.Drawing.Size(36, 17);
            this._priceLabel.TabIndex = 9;
            this._priceLabel.Text = "Price";
            // 
            // _startDateLabel
            // 
            this._startDateLabel.AutoSize = true;
            this._startDateLabel.Location = new System.Drawing.Point(20, 181);
            this._startDateLabel.Name = "_startDateLabel";
            this._startDateLabel.Size = new System.Drawing.Size(36, 17);
            this._startDateLabel.TabIndex = 10;
            this._startDateLabel.Text = "Start";
            // 
            // _endDateLabel
            // 
            this._endDateLabel.AutoSize = true;
            this._endDateLabel.Location = new System.Drawing.Point(20, 223);
            this._endDateLabel.Name = "_endDateLabel";
            this._endDateLabel.Size = new System.Drawing.Size(29, 17);
            this._endDateLabel.TabIndex = 11;
            this._endDateLabel.Text = "End";
            // 
            // _endDateBox
            // 
            this._endDateBox.Location = new System.Drawing.Point(219, 223);
            this._endDateBox.Margin = new System.Windows.Forms.Padding(4);
            this._endDateBox.Name = "_endDateBox";
            this._endDateBox.Size = new System.Drawing.Size(165, 24);
            this._endDateBox.TabIndex = 12;
            // 
            // _priceBox
            // 
            this._priceBox.DecimalPlaces = 2;
            this._priceBox.Location = new System.Drawing.Point(219, 135);
            this._priceBox.Name = "_priceBox";
            this._priceBox.Size = new System.Drawing.Size(165, 24);
            this._priceBox.TabIndex = 13;
            this._priceBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ServiceDialog
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(400, 307);
            this.Controls.Add(this._priceBox);
            this.Controls.Add(this._endDateBox);
            this.Controls.Add(this._endDateLabel);
            this.Controls.Add(this._startDateLabel);
            this.Controls.Add(this._priceLabel);
            this.Controls.Add(this._descriptionLabel);
            this.Controls.Add(this._nameLabel);
            this.Controls.Add(this._startDateBox);
            this.Controls.Add(this._descriptionBox);
            this.Controls.Add(this._nameBox);
            this.Controls.Add(this._question);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServiceDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._priceBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _question;
        private System.Windows.Forms.DateTimePicker _startDateBox;
        private System.Windows.Forms.TextBox _descriptionBox;
        private System.Windows.Forms.TextBox _nameBox;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.Label _startDateLabel;
        private System.Windows.Forms.Label _priceLabel;
        private System.Windows.Forms.Label _descriptionLabel;
        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.Label _endDateLabel;
        private System.Windows.Forms.DateTimePicker _endDateBox;
        private System.Windows.Forms.NumericUpDown _priceBox;
    }
}
