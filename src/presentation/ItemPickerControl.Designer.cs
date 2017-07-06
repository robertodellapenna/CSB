namespace CSB_Project.src.presentation
{
    partial class ItemPickerControl
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Item1");
            this._searchBox = new System.Windows.Forms.TextBox();
            this._itemsListView = new System.Windows.Forms.ListView();
            this._baseItemButton = new System.Windows.Forms.Button();
            this._generatedItem = new System.Windows.Forms.Label();
            this._associateItemButton = new System.Windows.Forms.Button();
            this._filterLabel = new System.Windows.Forms.Label();
            this._resetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _searchBox
            // 
            this._searchBox.Location = new System.Drawing.Point(0, 30);
            this._searchBox.Name = "_searchBox";
            this._searchBox.Size = new System.Drawing.Size(357, 20);
            this._searchBox.TabIndex = 0;
            // 
            // _itemsListView
            // 
            this._itemsListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this._itemsListView.Location = new System.Drawing.Point(0, 56);
            this._itemsListView.Name = "_itemsListView";
            this._itemsListView.Size = new System.Drawing.Size(357, 176);
            this._itemsListView.TabIndex = 1;
            this._itemsListView.UseCompatibleStateImageBehavior = false;
            this._itemsListView.View = System.Windows.Forms.View.List;
            // 
            // _baseItemButton
            // 
            this._baseItemButton.Location = new System.Drawing.Point(0, 290);
            this._baseItemButton.Name = "_baseItemButton";
            this._baseItemButton.Size = new System.Drawing.Size(126, 23);
            this._baseItemButton.TabIndex = 2;
            this._baseItemButton.Text = "Select Base Item";
            this._baseItemButton.UseVisualStyleBackColor = true;
            // 
            // _generatedItem
            // 
            this._generatedItem.AutoSize = true;
            this._generatedItem.Location = new System.Drawing.Point(3, 245);
            this._generatedItem.Name = "_generatedItem";
            this._generatedItem.Size = new System.Drawing.Size(71, 13);
            this._generatedItem.TabIndex = 3;
            this._generatedItem.Text = "Item Risultato";
            // 
            // _associateItemButton
            // 
            this._associateItemButton.Location = new System.Drawing.Point(132, 290);
            this._associateItemButton.Name = "_associateItemButton";
            this._associateItemButton.Size = new System.Drawing.Size(126, 23);
            this._associateItemButton.TabIndex = 4;
            this._associateItemButton.Text = "Associate Item";
            this._associateItemButton.UseVisualStyleBackColor = true;
            // 
            // _filterLabel
            // 
            this._filterLabel.AutoSize = true;
            this._filterLabel.Location = new System.Drawing.Point(-3, 14);
            this._filterLabel.Name = "_filterLabel";
            this._filterLabel.Size = new System.Drawing.Size(77, 13);
            this._filterLabel.TabIndex = 5;
            this._filterLabel.Text = "Filltra la ricerca";
            // 
            // _resetButton
            // 
            this._resetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this._resetButton.Location = new System.Drawing.Point(282, 290);
            this._resetButton.Name = "_resetButton";
            this._resetButton.Size = new System.Drawing.Size(75, 23);
            this._resetButton.TabIndex = 6;
            this._resetButton.Text = "RESET";
            this._resetButton.UseVisualStyleBackColor = false;
            // 
            // ItemPickerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._resetButton);
            this.Controls.Add(this._filterLabel);
            this.Controls.Add(this._associateItemButton);
            this.Controls.Add(this._generatedItem);
            this.Controls.Add(this._baseItemButton);
            this.Controls.Add(this._itemsListView);
            this.Controls.Add(this._searchBox);
            this.Name = "ItemPickerControl";
            this.Size = new System.Drawing.Size(363, 319);
            this.Load += new System.EventHandler(this.ItemPickerControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _searchBox;
        private System.Windows.Forms.ListView _itemsListView;
        private System.Windows.Forms.Button _baseItemButton;
        private System.Windows.Forms.Label _generatedItem;
        private System.Windows.Forms.Button _associateItemButton;
        private System.Windows.Forms.Label _filterLabel;
        private System.Windows.Forms.Button _resetButton;
    }
}
