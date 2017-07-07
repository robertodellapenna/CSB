namespace CSB_Project.src.presentation.ItemCreatorPresenter
{
    partial class CategorizableItemCreator
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
            this._basicItem = new CSB_Project.src.presentation.ItemCreatorPresenter.BasicItemCreator();
            this._tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this._bottomPanel = new System.Windows.Forms.Panel();
            this._topPanel.SuspendLayout();
            this._bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _topPanel
            // 
            this._topPanel.AutoSize = true;
            this._topPanel.Controls.Add(this._basicItem);
            this._topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._topPanel.Location = new System.Drawing.Point(0, 0);
            this._topPanel.MinimumSize = new System.Drawing.Size(0, 50);
            this._topPanel.Name = "_topPanel";
            this._topPanel.Size = new System.Drawing.Size(453, 222);
            this._topPanel.TabIndex = 0;
            // 
            // _basicItem
            // 
            this._basicItem.AutoSize = true;
            this._basicItem.BackColor = System.Drawing.Color.White;
            this._basicItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this._basicItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this._basicItem.Location = new System.Drawing.Point(0, 0);
            this._basicItem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._basicItem.Name = "_basicItem";
            this._basicItem.Size = new System.Drawing.Size(453, 222);
            this._basicItem.TabIndex = 0;
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
            this._tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 413F));
            this._tableLayout.Location = new System.Drawing.Point(0, 5);
            this._tableLayout.Margin = new System.Windows.Forms.Padding(0);
            this._tableLayout.MinimumSize = new System.Drawing.Size(0, 50);
            this._tableLayout.Name = "_tableLayout";
            this._tableLayout.RowCount = 1;
            this._tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayout.Size = new System.Drawing.Size(453, 50);
            this._tableLayout.TabIndex = 1;
            // 
            // _bottomPanel
            // 
            this._bottomPanel.AutoScroll = true;
            this._bottomPanel.AutoSize = true;
            this._bottomPanel.Controls.Add(this._tableLayout);
            this._bottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._bottomPanel.Location = new System.Drawing.Point(0, 222);
            this._bottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this._bottomPanel.Name = "_bottomPanel";
            this._bottomPanel.Size = new System.Drawing.Size(453, 152);
            this._bottomPanel.TabIndex = 2;
            // 
            // CategorizableItemCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._bottomPanel);
            this.Controls.Add(this._topPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CategorizableItemCreator";
            this.Size = new System.Drawing.Size(453, 374);
            this._topPanel.ResumeLayout(false);
            this._topPanel.PerformLayout();
            this._bottomPanel.ResumeLayout(false);
            this._bottomPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _topPanel;
        private BasicItemCreator _basicItem;
        private System.Windows.Forms.TableLayoutPanel _tableLayout;
        private System.Windows.Forms.Panel _bottomPanel;
    }
}
