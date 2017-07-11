namespace CSB_Project.src.presentation.Utils
{
    partial class ServiceDialog
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
            this.components = new System.ComponentModel.Container();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._question = new System.Windows.Forms.Label();
            this._start = new System.Windows.Forms.DateTimePicker();
            this._price = new System.Windows.Forms.TextBox();
            this._description = new System.Windows.Forms.TextBox();
            this._name = new System.Windows.Forms.TextBox();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._end = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            this._okButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(255)))), ((int)(((byte)(221)))));
            this._okButton.Location = new System.Drawing.Point(13, 268);
            this._okButton.Margin = new System.Windows.Forms.Padding(4);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(76, 26);
            this._okButton.TabIndex = 0;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = false;
            this._okButton.Click += new System.EventHandler(this.OkButtonHandler);
            // 
            // _cancelButton
            // 
            this._cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(146, 268);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(76, 26);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Annulla";
            this._cancelButton.UseVisualStyleBackColor = false;
            this._cancelButton.Click += new System.EventHandler(this.CancelButtonHandler);
            // 
            // _question
            // 
            this._question.AutoSize = true;
            this._question.Location = new System.Drawing.Point(13, 9);
            this._question.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._question.Name = "_question";
            this._question.Size = new System.Drawing.Size(112, 17);
            this._question.TabIndex = 2;
            this._question.Text = "Inserisci Parametri";
            // 
            // _start
            // 
            this._start.Location = new System.Drawing.Point(246, 181);
            this._start.Margin = new System.Windows.Forms.Padding(4);
            this._start.Name = "_start";
            this._start.Size = new System.Drawing.Size(165, 24);
            this._start.TabIndex = 3;
            this._start.TextChanged += new System.EventHandler(this.start_TextChanged);
            this._start.ValueChanged += new System.EventHandler(this._start_ValueChanged);
            // 
            // _price
            // 
            this._price.Location = new System.Drawing.Point(246, 135);
            this._price.Name = "_price";
            this._price.Size = new System.Drawing.Size(165, 24);
            this._price.TabIndex = 4;
            // 
            // _description
            // 
            this._description.Location = new System.Drawing.Point(246, 91);
            this._description.Name = "_description";
            this._description.Size = new System.Drawing.Size(165, 24);
            this._description.TabIndex = 5;
            this._description.TextChanged += new System.EventHandler(this._description_TextChanged);
            // 
            // _name
            // 
            this._name.Location = new System.Drawing.Point(246, 47);
            this._name.Name = "_name";
            this._name.Size = new System.Drawing.Size(165, 24);
            this._name.TabIndex = 6;
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Start";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "End";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // _end
            // 
            this._end.Location = new System.Drawing.Point(246, 223);
            this._end.Margin = new System.Windows.Forms.Padding(4);
            this._end.Name = "_end";
            this._end.Size = new System.Drawing.Size(165, 24);
            this._end.TabIndex = 12;
            // 
            // ServiceDialog
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(475, 307);
            this.Controls.Add(this._end);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._start);
            this.Controls.Add(this._price);
            this.Controls.Add(this._description);
            this.Controls.Add(this._name);
            this.Controls.Add(this._question);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServiceDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ServiceDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _question;
        private System.Windows.Forms.DateTimePicker _start;
        private System.Windows.Forms.TextBox _price;
        private System.Windows.Forms.TextBox _description;
        private System.Windows.Forms.TextBox _name;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker _end;
    }
}
