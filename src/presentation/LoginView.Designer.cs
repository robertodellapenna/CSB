namespace CSB_Project.src.presentation
{
    partial class LoginView
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
            this._usernameBox = new System.Windows.Forms.TextBox();
            this._passwordBox = new System.Windows.Forms.TextBox();
            this._loginButton = new System.Windows.Forms.Button();
            this._guestButton = new System.Windows.Forms.Button();
            this._customerButton = new System.Windows.Forms.Button();
            this._staffButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _usernameBox
            // 
            this._usernameBox.Location = new System.Drawing.Point(196, 106);
            this._usernameBox.Name = "_usernameBox";
            this._usernameBox.Size = new System.Drawing.Size(180, 20);
            this._usernameBox.TabIndex = 0;
            this._usernameBox.Text = "giovanni.admin";
            // 
            // _passwordBox
            // 
            this._passwordBox.Location = new System.Drawing.Point(196, 162);
            this._passwordBox.Name = "_passwordBox";
            this._passwordBox.PasswordChar = '*';
            this._passwordBox.Size = new System.Drawing.Size(180, 20);
            this._passwordBox.TabIndex = 1;
            this._passwordBox.Text = "admin";
            // 
            // _loginButton
            // 
            this._loginButton.Location = new System.Drawing.Point(196, 226);
            this._loginButton.Name = "_loginButton";
            this._loginButton.Size = new System.Drawing.Size(75, 23);
            this._loginButton.TabIndex = 2;
            this._loginButton.Text = "Login";
            this._loginButton.UseVisualStyleBackColor = true;
            // 
            // _guestButton
            // 
            this._guestButton.Location = new System.Drawing.Point(301, 226);
            this._guestButton.Name = "_guestButton";
            this._guestButton.Size = new System.Drawing.Size(75, 23);
            this._guestButton.TabIndex = 3;
            this._guestButton.Text = "Entra come ospite";
            this._guestButton.UseVisualStyleBackColor = true;
            // 
            // _customerButton
            // 
            this._customerButton.Location = new System.Drawing.Point(196, 297);
            this._customerButton.Name = "_customerButton";
            this._customerButton.Size = new System.Drawing.Size(75, 41);
            this._customerButton.TabIndex = 4;
            this._customerButton.Text = "Entra come cliente";
            this._customerButton.UseVisualStyleBackColor = true;
            // 
            // _staffButton
            // 
            this._staffButton.Location = new System.Drawing.Point(301, 297);
            this._staffButton.Name = "_staffButton";
            this._staffButton.Size = new System.Drawing.Size(75, 41);
            this._staffButton.TabIndex = 5;
            this._staffButton.Text = "Entra come staff";
            this._staffButton.UseVisualStyleBackColor = true;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this._staffButton);
            this.Controls.Add(this._customerButton);
            this.Controls.Add(this._guestButton);
            this.Controls.Add(this._loginButton);
            this.Controls.Add(this._passwordBox);
            this.Controls.Add(this._usernameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _usernameBox;
        private System.Windows.Forms.TextBox _passwordBox;
        private System.Windows.Forms.Button _loginButton;
        private System.Windows.Forms.Button _guestButton;
        private System.Windows.Forms.Button _customerButton;
        private System.Windows.Forms.Button _staffButton;
    }
}