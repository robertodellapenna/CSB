namespace CSB_Project.src.presentation.ItemCreatorPresenter
{
    partial class BasicItemCreator
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._identifierLabel = new System.Windows.Forms.Label();
            this._identifierTextBox = new System.Windows.Forms.TextBox();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._descriptioonTextBox = new System.Windows.Forms.TextBox();
            this._descriptionLabel = new System.Windows.Forms.Label();
            this._priceLabel = new System.Windows.Forms.Label();
            this._priceBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this._priceBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _identifierLabel
            // 
            this._identifierLabel.AutoSize = true;
            this._identifierLabel.Location = new System.Drawing.Point(3, 19);
            this._identifierLabel.Name = "_identifierLabel";
            this._identifierLabel.Size = new System.Drawing.Size(68, 13);
            this._identifierLabel.TabIndex = 0;
            this._identifierLabel.Text = "Identificatore";
            // 
            // _identifierTextBox
            // 
            this._identifierTextBox.Location = new System.Drawing.Point(109, 16);
            this._identifierTextBox.Name = "_identifierTextBox";
            this._identifierTextBox.Size = new System.Drawing.Size(186, 20);
            this._identifierTextBox.TabIndex = 1;
            this._identifierTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(109, 47);
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(186, 20);
            this._nameTextBox.TabIndex = 3;
            this._nameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome";
            // 
            // _descriptioonTextBox
            // 
            this._descriptioonTextBox.Location = new System.Drawing.Point(109, 73);
            this._descriptioonTextBox.Multiline = true;
            this._descriptioonTextBox.Name = "_descriptioonTextBox";
            this._descriptioonTextBox.Size = new System.Drawing.Size(186, 45);
            this._descriptioonTextBox.TabIndex = 5;
            this._descriptioonTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _descriptionLabel
            // 
            this._descriptionLabel.AutoSize = true;
            this._descriptionLabel.Location = new System.Drawing.Point(3, 88);
            this._descriptionLabel.Name = "_descriptionLabel";
            this._descriptionLabel.Size = new System.Drawing.Size(62, 13);
            this._descriptionLabel.TabIndex = 4;
            this._descriptionLabel.Text = "Descrizione";
            // 
            // _priceLabel
            // 
            this._priceLabel.AutoSize = true;
            this._priceLabel.Location = new System.Drawing.Point(3, 131);
            this._priceLabel.Name = "_priceLabel";
            this._priceLabel.Size = new System.Drawing.Size(31, 13);
            this._priceLabel.TabIndex = 7;
            this._priceLabel.Text = "Price";
            // 
            // _priceBox
            // 
            this._priceBox.DecimalPlaces = 2;
            this._priceBox.Location = new System.Drawing.Point(109, 124);
            this._priceBox.Name = "_priceBox";
            this._priceBox.Size = new System.Drawing.Size(186, 20);
            this._priceBox.TabIndex = 8;
            this._priceBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BasicItemCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._priceBox);
            this.Controls.Add(this._priceLabel);
            this.Controls.Add(this._descriptioonTextBox);
            this.Controls.Add(this._descriptionLabel);
            this.Controls.Add(this._nameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._identifierTextBox);
            this.Controls.Add(this._identifierLabel);
            this.Name = "BasicItemCreator";
            this.Size = new System.Drawing.Size(314, 158);
            ((System.ComponentModel.ISupportInitialize)(this._priceBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _identifierLabel;
        private System.Windows.Forms.TextBox _identifierTextBox;
        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _descriptioonTextBox;
        private System.Windows.Forms.Label _descriptionLabel;
        private System.Windows.Forms.Label _priceLabel;
        private System.Windows.Forms.NumericUpDown _priceBox;
    }
}
