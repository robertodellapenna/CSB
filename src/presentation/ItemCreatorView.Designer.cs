namespace CSB_Project.src.presentation
{
    partial class ItemCreatorView
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
            this._backPanel = new System.Windows.Forms.Panel();
            this._messageLabel = new System.Windows.Forms.Label();
            this._buttonFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._backPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _backPanel
            // 
            this._backPanel.BackColor = System.Drawing.Color.White;
            this._backPanel.Controls.Add(this._buttonFlowPanel);
            this._backPanel.Controls.Add(this._messageLabel);
            this._backPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._backPanel.Location = new System.Drawing.Point(0, 0);
            this._backPanel.Margin = new System.Windows.Forms.Padding(0);
            this._backPanel.Name = "_backPanel";
            this._backPanel.Size = new System.Drawing.Size(274, 261);
            this._backPanel.TabIndex = 0;
            // 
            // _messageLabel
            // 
            this._messageLabel.AutoSize = true;
            this._messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._messageLabel.Location = new System.Drawing.Point(12, 22);
            this._messageLabel.Name = "_messageLabel";
            this._messageLabel.Size = new System.Drawing.Size(245, 20);
            this._messageLabel.TabIndex = 0;
            this._messageLabel.Text = "Che tipologia di item vuoi creare ?";
            // 
            // _buttonFlowPanel
            // 
            this._buttonFlowPanel.AutoScroll = true;
            this._buttonFlowPanel.BackColor = System.Drawing.Color.White;
            this._buttonFlowPanel.Location = new System.Drawing.Point(16, 49);
            this._buttonFlowPanel.Margin = new System.Windows.Forms.Padding(0);
            this._buttonFlowPanel.Name = "_buttonFlowPanel";
            this._buttonFlowPanel.Size = new System.Drawing.Size(241, 203);
            this._buttonFlowPanel.TabIndex = 1;
            // 
            // ItemCreatorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 261);
            this.Controls.Add(this._backPanel);
            this.Name = "ItemCreatorView";
            this.Text = "ItemCreator";
            this._backPanel.ResumeLayout(false);
            this._backPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _backPanel;
        private System.Windows.Forms.FlowLayoutPanel _buttonFlowPanel;
        private System.Windows.Forms.Label _messageLabel;
    }
}