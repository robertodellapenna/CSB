﻿namespace CSB_Project.src
{
    partial class TestForm
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
            this.itemPickerControl1 = new CSB_Project.src.presentation.ItemPickerView();
            this.SuspendLayout();
            // 
            // itemPickerControl1
            // 
            this.itemPickerControl1.Location = new System.Drawing.Point(580, 12);
            this.itemPickerControl1.Name = "itemPickerControl1";
            this.itemPickerControl1.Size = new System.Drawing.Size(367, 319);
            this.itemPickerControl1.TabIndex = 0;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 505);
            this.Controls.Add(this.itemPickerControl1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private presentation.ItemPickerView itemPickerControl1;
    }
}