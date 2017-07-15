using CSB_Project.src.presentation.Utils;

namespace CSB_Project.src.presentation
{
    partial class PacketManagerView
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
            this._listPanel = new System.Windows.Forms.Panel();
            this._listView = new System.Windows.Forms.ListView();
            this._actionPanel = new System.Windows.Forms.Panel();
            this._deleteButton = new System.Windows.Forms.Button();
            this._addButton = new System.Windows.Forms.Button();
            this._listPanel.SuspendLayout();
            this._actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _listPanel
            // 
            this._listPanel.AutoScroll = true;
            this._listPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._listPanel.Controls.Add(this._listView);
            this._listPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._listPanel.Location = new System.Drawing.Point(0, 0);
            this._listPanel.Margin = new System.Windows.Forms.Padding(0);
            this._listPanel.Name = "_listPanel";
            this._listPanel.Size = new System.Drawing.Size(424, 362);
            this._listPanel.TabIndex = 0;
            // 
            // _listView
            // 
            this._listView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(255)))), ((int)(((byte)(249)))));
            this._listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listView.FullRowSelect = true;
            this._listView.GridLines = true;
            this._listView.Location = new System.Drawing.Point(0, 0);
            this._listView.Name = "_listView";
            this._listView.Size = new System.Drawing.Size(424, 362);
            this._listView.TabIndex = 0;
            this._listView.Columns.Add("Nome");
            this._listView.Columns.Add("Descrizione");
            this._listView.Columns.Add("Prezzo");
            this._listView.Columns.Add("Acquistabile");
            this._listView.Columns.Add("Servizio");
            this._listView.Columns.Add("Ticket");
            this._listView.Columns.Add("Validita");
            ResizeListView.autoResizeColumns(_listView);
            this._listView.UseCompatibleStateImageBehavior = false;
            this._listView.View = System.Windows.Forms.View.Details;
            // 
            // _actionPanel
            // 
            this._actionPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this._actionPanel.Controls.Add(this._deleteButton);
            this._actionPanel.Controls.Add(this._addButton);
            this._actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._actionPanel.Location = new System.Drawing.Point(0, 196);
            this._actionPanel.Margin = new System.Windows.Forms.Padding(0);
            this._actionPanel.Name = "_actionPanel";
            this._actionPanel.Size = new System.Drawing.Size(424, 65);
            this._actionPanel.TabIndex = 1;
            // 
            // _deleteButton
            // 
            this._deleteButton.Location = new System.Drawing.Point(174, 21);
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Size = new System.Drawing.Size(75, 23);
            this._deleteButton.TabIndex = 2;
            this._deleteButton.Text = "DELETE";
            this._deleteButton.UseVisualStyleBackColor = true;
            // 
            // _addButton
            // 
            this._addButton.Location = new System.Drawing.Point(12, 21);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(75, 23);
            this._addButton.TabIndex = 1;
            this._addButton.Text = "ADD";
            this._addButton.UseVisualStyleBackColor = true;
            // 
            // PacketManagerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 261);
            this.Controls.Add(this._actionPanel);
            this.Controls.Add(this._listPanel);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "PacketManagerView";
            this.Text = "PacketManagerView";
            this._listPanel.ResumeLayout(false);
            this._actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _listPanel;
        private System.Windows.Forms.Panel _actionPanel;
        private System.Windows.Forms.ListView _listView;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _deleteButton;
    }
}