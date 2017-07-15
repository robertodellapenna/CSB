namespace CSB_Project.src.presentation.ItemCreator
{
    partial class BasicItemCreatorView
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
            this._basicItemControl = new CSB_Project.src.presentation.ItemCreator.BasicItemControl();
            this._addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _basicItemControl
            // 
            this._basicItemControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this._basicItemControl.Location = new System.Drawing.Point(0, -2);
            this._basicItemControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._basicItemControl.Name = "_basicItemControl";
            this._basicItemControl.Size = new System.Drawing.Size(450, 248);
            this._basicItemControl.TabIndex = 0;
            // 
            // _addButton
            // 
            this._addButton.Location = new System.Drawing.Point(12, 249);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(438, 49);
            this._addButton.TabIndex = 1;
            this._addButton.Text = "Prova ad aggiungere l\'elemento al sistema";
            this._addButton.UseVisualStyleBackColor = true;
            // 
            // BasicItemCreatorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 310);
            this.Controls.Add(this._addButton);
            this.Controls.Add(this._basicItemControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BasicItemCreatorView";
            this.ResumeLayout(false);

        }

        #endregion

        private BasicItemControl _basicItemControl;
        private System.Windows.Forms.Button _addButton;
    }
}
