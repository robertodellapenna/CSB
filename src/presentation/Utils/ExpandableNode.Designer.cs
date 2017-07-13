namespace CSB_Project.src.presentation.Utils
{
    partial class ExpandableNode
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
            this._backPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._label = new CSB_Project.src.presentation.Utils.BorderLabel();
            this._backPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _backPanel
            // 
            this._backPanel.AutoScroll = true;
            this._backPanel.AutoSize = true;
            this._backPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._backPanel.Controls.Add(this._label);
            this._backPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._backPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._backPanel.Location = new System.Drawing.Point(0, 0);
            this._backPanel.Name = "_backPanel";
            this._backPanel.Size = new System.Drawing.Size(730, 205);
            this._backPanel.TabIndex = 2;
            this._backPanel.WrapContents = false;
            // 
            // _label
            // 
            this._label.BackColorHover = System.Drawing.Color.Black;
            this._label.BorderSize = 3;
            this._label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this._label.ForeColorHover = System.Drawing.Color.White;
            this._label.Location = new System.Drawing.Point(0, 0);
            this._label.Margin = new System.Windows.Forms.Padding(0);
            this._label.Name = "_label";
            this._label.Size = new System.Drawing.Size(288, 67);
            this._label.TabIndex = 0;
            this._label.TextColor = System.Drawing.Color.Black;
            this._label.TextColorHover = System.Drawing.Color.Black;
            // 
            // ExpandableNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._backPanel);
            this.Name = "ExpandableNode";
            this.Size = new System.Drawing.Size(730, 205);
            this._backPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _backPanel;
        private BorderLabel _label;
    }
}
