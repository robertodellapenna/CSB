using System;

namespace CSB_Project.src.presentation
{
    partial class StructureManagerView
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
            this._treePanel = new System.Windows.Forms.Panel();
            this._treeView = new System.Windows.Forms.TreeView();
            this._actionPanel = new System.Windows.Forms.Panel();
            this._modifyButton = new System.Windows.Forms.Button();
            this._deleteButton = new System.Windows.Forms.Button();
            this._addButton = new System.Windows.Forms.Button();
            this._treePanel.SuspendLayout();
            this._actionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _treePanel
            // 
            this._treePanel.AutoScroll = true;
            this._treePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._treePanel.Controls.Add(this._treeView);
            this._treePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._treePanel.Location = new System.Drawing.Point(0, 0);
            this._treePanel.Margin = new System.Windows.Forms.Padding(0);
            this._treePanel.Name = "_treePanel";
            this._treePanel.Size = new System.Drawing.Size(284, 362);
            this._treePanel.TabIndex = 0;
            // 
            // _treeView
            // 
            this._treeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(255)))), ((int)(((byte)(249)))));
            this._treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeView.Location = new System.Drawing.Point(0, 0);
            this._treeView.Name = "_treeView";
            this._treeView.Size = new System.Drawing.Size(284, 362);
            this._treeView.TabIndex = 0;
            // 
            // _actionPanel
            // 
            this._actionPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this._actionPanel.Controls.Add(this._modifyButton);
            this._actionPanel.Controls.Add(this._deleteButton);
            this._actionPanel.Controls.Add(this._addButton);
            this._actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._actionPanel.Location = new System.Drawing.Point(0, 196);
            this._actionPanel.Margin = new System.Windows.Forms.Padding(0);
            this._actionPanel.Name = "_actionPanel";
            this._actionPanel.Size = new System.Drawing.Size(284, 65);
            this._actionPanel.TabIndex = 1;
            // 
            // _modifyButton
            // 
            this._modifyButton.Location = new System.Drawing.Point(93, 21);
            this._modifyButton.Name = "_modifyButton";
            this._modifyButton.Size = new System.Drawing.Size(75, 23);
            this._modifyButton.TabIndex = 3;
            this._modifyButton.Text = "MODIFY";
            this._modifyButton.UseVisualStyleBackColor = true;
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
            // CategoryManagerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this._actionPanel);
            this.Controls.Add(this._treePanel);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "StructureManagerView";
            this.Text = "StructureManagerView";
            this.Load += new System.EventHandler(this.StructureManagerView_Load);
            this._treePanel.ResumeLayout(false);
            this._actionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _treePanel;
        private System.Windows.Forms.Panel _actionPanel;
        private System.Windows.Forms.TreeView _treeView;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _modifyButton;
        private System.Windows.Forms.Button _deleteButton;
    }
}