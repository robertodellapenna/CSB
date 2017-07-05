namespace CSB_Project.src
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
            this.itemPickerControl1 = new CSB_Project.src.presentation.ItemPickerControl();
            this.basicItemCreator1 = new CSB_Project.src.presentation.ItemCreatorPresenter.BasicItemCreator();
            this.SuspendLayout();
            // 
            // itemPickerControl1
            // 
            this.itemPickerControl1.Location = new System.Drawing.Point(241, 186);
            this.itemPickerControl1.Name = "itemPickerControl1";
            this.itemPickerControl1.Size = new System.Drawing.Size(363, 319);
            this.itemPickerControl1.TabIndex = 0;
            // 
            // basicItemCreator1
            // 
            this.basicItemCreator1.Location = new System.Drawing.Point(0, -3);
            this.basicItemCreator1.Name = "basicItemCreator1";
            this.basicItemCreator1.Size = new System.Drawing.Size(314, 158);
            this.basicItemCreator1.TabIndex = 1;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 505);
            this.Controls.Add(this.basicItemCreator1);
            this.Controls.Add(this.itemPickerControl1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private presentation.ItemPickerControl itemPickerControl1;
        private presentation.ItemCreatorPresenter.BasicItemCreator basicItemCreator1;
    }
}