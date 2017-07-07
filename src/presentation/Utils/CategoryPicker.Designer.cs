namespace CSB_Project.src.presentation.Utils
{
    partial class CategoryPicker
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
            this._flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // _flowPanel
            // 
            this._flowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._flowPanel.AutoScroll = true;
            this._flowPanel.AutoSize = true;
            this._flowPanel.BackColor = System.Drawing.Color.White;
            this._flowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._flowPanel.Location = new System.Drawing.Point(0, 0);
            this._flowPanel.Margin = new System.Windows.Forms.Padding(0);
            this._flowPanel.Name = "_flowPanel";
            this._flowPanel.Size = new System.Drawing.Size(100, 120);
            this._flowPanel.TabIndex = 0;
            this._flowPanel.WrapContents = false;
            // 
            // CategoryPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this._flowPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CategoryPicker";
            this.Size = new System.Drawing.Size(100, 120);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _flowPanel;
    }
}
