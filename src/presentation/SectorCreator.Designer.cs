namespace CSB_Project.src.presentation
{
    partial class SectorCreator
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
            this._rowsLabel = new System.Windows.Forms.Label();
            this._rowsTextBox = new System.Windows.Forms.TextBox();
            this._colsLabel = new System.Windows.Forms.Label();
            this._colsTextBox = new System.Windows.Forms.TextBox();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._descriptioonTextBox = new System.Windows.Forms.TextBox();
            this._descriptionLabel = new System.Windows.Forms.Label();
            this._priceLabel = new System.Windows.Forms.Label();
            this._priceTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _rowsLabel
            // 
            this._rowsLabel.AutoSize = true;
            this._rowsLabel.Location = new System.Drawing.Point(14, 131);
            this._rowsLabel.Name = "_rowsLabel";
            this._rowsLabel.Size = new System.Drawing.Size(35, 13);
            this._rowsLabel.TabIndex = 0;
            this._rowsLabel.Text = "Righe";
            // 
            // _rowsTextBox
            // 
            this._rowsTextBox.Location = new System.Drawing.Point(109, 163);
            this._rowsTextBox.Name = "_rowsTextBox";
            this._rowsTextBox.Size = new System.Drawing.Size(186, 20);
            this._rowsTextBox.TabIndex = 1;
            // 
            // _colsLabel
            // 
            this._colsLabel.AutoSize = true;
            this._colsLabel.Location = new System.Drawing.Point(14, 163);
            this._colsLabel.Name = "_colsLabel";
            this._colsLabel.Size = new System.Drawing.Size(46, 13);
            this._colsLabel.TabIndex = 0;
            this._colsLabel.Text = "Colonne";
            // 
            // _colsTextBox
            // 
            this._colsTextBox.Location = new System.Drawing.Point(109, 131);
            this._colsTextBox.Name = "_colsTextBox";
            this._colsTextBox.Size = new System.Drawing.Size(186, 20);
            this._colsTextBox.TabIndex = 1;
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(109, 3);
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(186, 20);
            this._nameTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome";
            // 
            // _descriptioonTextBox
            // 
            this._descriptioonTextBox.Location = new System.Drawing.Point(109, 36);
            this._descriptioonTextBox.Multiline = true;
            this._descriptioonTextBox.Name = "_descriptioonTextBox";
            this._descriptioonTextBox.Size = new System.Drawing.Size(186, 45);
            this._descriptioonTextBox.TabIndex = 5;
            // 
            // _descriptionLabel
            // 
            this._descriptionLabel.AutoSize = true;
            this._descriptionLabel.Location = new System.Drawing.Point(14, 36);
            this._descriptionLabel.Name = "_descriptionLabel";
            this._descriptionLabel.Size = new System.Drawing.Size(62, 13);
            this._descriptionLabel.TabIndex = 4;
            this._descriptionLabel.Text = "Descrizione";
            // 
            // _priceLabel
            // 
            this._priceLabel.AutoSize = true;
            this._priceLabel.Location = new System.Drawing.Point(14, 96);
            this._priceLabel.Name = "_priceLabel";
            this._priceLabel.Size = new System.Drawing.Size(39, 13);
            this._priceLabel.TabIndex = 7;
            this._priceLabel.Text = "Prezzo";
            // 
            // _priceTextBox
            // 
            this._priceTextBox.Location = new System.Drawing.Point(109, 96);
            this._priceTextBox.Name = "_priceTextBox";
            this._priceTextBox.Size = new System.Drawing.Size(186, 20);
            this._priceTextBox.TabIndex = 8;
            // 
            // SectorCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._rowsTextBox);
            this.Controls.Add(this._rowsLabel);
            this.Controls.Add(this._colsTextBox);
            this.Controls.Add(this._colsLabel);
            this.Controls.Add(this._nameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._descriptioonTextBox);
            this.Controls.Add(this._descriptionLabel);
            this.Controls.Add(this._priceTextBox);
            this.Controls.Add(this._priceLabel);
            this.Name = "SectorCreator";
            this.Size = new System.Drawing.Size(314, 195);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _rowsLabel;
        private System.Windows.Forms.TextBox _rowsTextBox;
        private System.Windows.Forms.Label _colsLabel;
        private System.Windows.Forms.TextBox _colsTextBox;
        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _descriptioonTextBox;
        private System.Windows.Forms.Label _descriptionLabel;
        private System.Windows.Forms.Label _priceLabel;
        private System.Windows.Forms.TextBox _priceTextBox;

    }
}
