namespace CSB_Project.src.presentation.Utils
{
    partial class BorderLabel
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
            this._borderLabel = new System.Windows.Forms.Label();
            this._innerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _borderLabel
            // 
            this._borderLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._borderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._borderLabel.Location = new System.Drawing.Point(0, 0);
            this._borderLabel.Margin = new System.Windows.Forms.Padding(0);
            this._borderLabel.Name = "_borderLabel";
            this._borderLabel.Size = new System.Drawing.Size(288, 72);
            this._borderLabel.TabIndex = 0;
            // 
            // _innerLabel
            // 
            this._innerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._innerLabel.BackColor = System.Drawing.Color.White;
            this._innerLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._innerLabel.Location = new System.Drawing.Point(10, 10);
            this._innerLabel.Margin = new System.Windows.Forms.Padding(10);
            this._innerLabel.Name = "_innerLabel";
            this._innerLabel.Size = new System.Drawing.Size(268, 52);
            this._innerLabel.TabIndex = 1;
            this._innerLabel.Text = "label1";
            this._innerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BorderLabel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this._innerLabel);
            this.Controls.Add(this._borderLabel);
            this.Name = "BorderLabel";
            this.Size = new System.Drawing.Size(288, 72);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _borderLabel;
        private System.Windows.Forms.Label _innerLabel;
    }
}
