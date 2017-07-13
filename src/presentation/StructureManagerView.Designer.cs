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
            this.panel1 = new System.Windows.Forms.Panel();
            this._dateTimePickerDa = new System.Windows.Forms.DateTimePicker();
            this._labelA = new System.Windows.Forms.Label();
            this._dateTimePickerA = new System.Windows.Forms.DateTimePicker();
            this._labelDa = new System.Windows.Forms.Label();
            this._treeView = new System.Windows.Forms.TreeView();
            this._actionPanel = new System.Windows.Forms.Panel();
            this._modifyButton = new System.Windows.Forms.Button();
            this._deleteButton = new System.Windows.Forms.Button();
            this._addButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this._actionPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this._dateTimePickerDa);
            this.panel1.Controls.Add(this._labelA);
            this.panel1.Controls.Add(this._dateTimePickerA);
            this.panel1.Controls.Add(this._labelDa);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 51);
            this.panel1.TabIndex = 5;
            // 
            // _dateTimePickerDa
            // 
            this._dateTimePickerDa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dateTimePickerDa.Location = new System.Drawing.Point(80, 3);
            this._dateTimePickerDa.Name = "_dateTimePickerDa";
            this._dateTimePickerDa.Size = new System.Drawing.Size(626, 20);
            this._dateTimePickerDa.TabIndex = 1;
            this._dateTimePickerDa.Value = new System.DateTime(2017, 7, 11, 14, 38, 4, 0);
            // 
            // _labelA
            // 
            this._labelA.AutoSize = true;
            this._labelA.BackColor = System.Drawing.Color.White;
            this._labelA.Location = new System.Drawing.Point(29, 33);
            this._labelA.Name = "_labelA";
            this._labelA.Size = new System.Drawing.Size(14, 13);
            this._labelA.TabIndex = 4;
            this._labelA.Text = "A";
            // 
            // _dateTimePickerA
            // 
            this._dateTimePickerA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dateTimePickerA.Location = new System.Drawing.Point(80, 27);
            this._dateTimePickerA.Name = "_dateTimePickerA";
            this._dateTimePickerA.Size = new System.Drawing.Size(626, 20);
            this._dateTimePickerA.TabIndex = 2;
            this._dateTimePickerA.Value = new System.DateTime(2017, 9, 30, 0, 0, 0, 0);
            // 
            // _labelDa
            // 
            this._labelDa.AutoSize = true;
            this._labelDa.BackColor = System.Drawing.Color.White;
            this._labelDa.Location = new System.Drawing.Point(22, 9);
            this._labelDa.Name = "_labelDa";
            this._labelDa.Size = new System.Drawing.Size(21, 13);
            this._labelDa.TabIndex = 3;
            this._labelDa.Text = "Da";
            // 
            // _treeView
            // 
            this._treeView.BackColor = System.Drawing.Color.White;
            this._treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeView.Location = new System.Drawing.Point(0, 0);
            this._treeView.Name = "_treeView";
            this._treeView.Size = new System.Drawing.Size(710, 463);
            this._treeView.TabIndex = 0;
            // 
            // _actionPanel
            // 
            this._actionPanel.BackColor = System.Drawing.Color.White;
            this._actionPanel.Controls.Add(this._modifyButton);
            this._actionPanel.Controls.Add(this._deleteButton);
            this._actionPanel.Controls.Add(this._addButton);
            this._actionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._actionPanel.Location = new System.Drawing.Point(0, 514);
            this._actionPanel.Margin = new System.Windows.Forms.Padding(0);
            this._actionPanel.Name = "_actionPanel";
            this._actionPanel.Size = new System.Drawing.Size(710, 65);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.Controls.Add(this._treeView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(710, 463);
            this.panel2.TabIndex = 6;
            // 
            // StructureManagerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 579);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._actionPanel);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "StructureManagerView";
            this.Text = "StructureManagerView";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._actionPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel _actionPanel;
        private System.Windows.Forms.TreeView _treeView;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _modifyButton;
        private System.Windows.Forms.Button _deleteButton;
        private System.Windows.Forms.Label _labelDa;
        private System.Windows.Forms.DateTimePicker _dateTimePickerA;
        private System.Windows.Forms.DateTimePicker _dateTimePickerDa;
        private System.Windows.Forms.Label _labelA;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}