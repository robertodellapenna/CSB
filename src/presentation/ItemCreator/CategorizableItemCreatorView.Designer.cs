namespace CSB_Project.src.presentation.ItemCreator
{
    partial class CategorizableItemCreatorView
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
            this._topPanel = new System.Windows.Forms.Panel();
            this._basicItemControl = new CSB_Project.src.presentation.ItemCreator.BasicItemControl();
            this._tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this._middlePanel = new System.Windows.Forms.Panel();
            this._bottomPanel = new System.Windows.Forms.Panel();
            this._addButton = new System.Windows.Forms.Button();
            this._topPanel.SuspendLayout();
            this._middlePanel.SuspendLayout();
            this._bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _topPanel
            // 
            this._topPanel.AutoSize = true;
            this._topPanel.Controls.Add(this._basicItemControl);
            this._topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._topPanel.Location = new System.Drawing.Point(0, 0);
            this._topPanel.MinimumSize = new System.Drawing.Size(0, 50);
            this._topPanel.Name = "_topPanel";
            this._topPanel.Size = new System.Drawing.Size(467, 253);
            this._topPanel.TabIndex = 0;
            // 
            // _basicItemControl
            // 
            this._basicItemControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this._basicItemControl.Location = new System.Drawing.Point(0, 0);
            this._basicItemControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._basicItemControl.Name = "_basicItemControl";
            this._basicItemControl.Size = new System.Drawing.Size(450, 248);
            this._basicItemControl.TabIndex = 0;
            // 
            // _tableLayout
            // 
            this._tableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tableLayout.AutoSize = true;
            this._tableLayout.BackColor = System.Drawing.Color.White;
            this._tableLayout.ColumnCount = 4;
            this._tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 427F));
            this._tableLayout.Location = new System.Drawing.Point(0, 5);
            this._tableLayout.Margin = new System.Windows.Forms.Padding(0);
            this._tableLayout.MinimumSize = new System.Drawing.Size(0, 50);
            this._tableLayout.Name = "_tableLayout";
            this._tableLayout.RowCount = 1;
            this._tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayout.Size = new System.Drawing.Size(467, 50);
            this._tableLayout.TabIndex = 1;
            // 
            // _middlePanel
            // 
            this._middlePanel.AutoScroll = true;
            this._middlePanel.AutoSize = true;
            this._middlePanel.Controls.Add(this._tableLayout);
            this._middlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._middlePanel.Location = new System.Drawing.Point(0, 253);
            this._middlePanel.Margin = new System.Windows.Forms.Padding(0);
            this._middlePanel.Name = "_middlePanel";
            this._middlePanel.Size = new System.Drawing.Size(467, 211);
            this._middlePanel.TabIndex = 2;
            // 
            // _bottomPanel
            // 
            this._bottomPanel.Controls.Add(this._addButton);
            this._bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._bottomPanel.Location = new System.Drawing.Point(0, 464);
            this._bottomPanel.Name = "_bottomPanel";
            this._bottomPanel.Size = new System.Drawing.Size(467, 46);
            this._bottomPanel.TabIndex = 3;
            // 
            // _addButton
            // 
            this._addButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._addButton.Location = new System.Drawing.Point(0, 0);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(467, 46);
            this._addButton.TabIndex = 0;
            this._addButton.Text = "Aggiunti item al sistema";
            this._addButton.UseVisualStyleBackColor = true;
            // 
            // CategorizableItemCreatorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(467, 510);
            this.Controls.Add(this._middlePanel);
            this.Controls.Add(this._bottomPanel);
            this.Controls.Add(this._topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CategorizableItemCreatorView";
            this._topPanel.ResumeLayout(false);
            this._middlePanel.ResumeLayout(false);
            this._middlePanel.PerformLayout();
            this._bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _topPanel;
        private System.Windows.Forms.TableLayoutPanel _tableLayout;
        private System.Windows.Forms.Panel _middlePanel;
        private BasicItemControl _basicItemControl;
        private System.Windows.Forms.Panel _bottomPanel;
        private System.Windows.Forms.Button _addButton;
    }
}
