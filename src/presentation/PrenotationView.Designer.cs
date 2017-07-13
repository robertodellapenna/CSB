namespace CSB_Project.src.presentation
{
    partial class PrenotationView
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
            this._mainPanel = new System.Windows.Forms.Panel();
            this._tabControl = new System.Windows.Forms.TabControl();
            this._backPanel = new System.Windows.Forms.Panel();
            this._searchPanel = new System.Windows.Forms.Panel();
            this._usernameLabel = new System.Windows.Forms.Label();
            this._searchBox = new System.Windows.Forms.TextBox();
            this._customerBox = new System.Windows.Forms.ComboBox();
            this._mainPanel.SuspendLayout();
            this._backPanel.SuspendLayout();
            this._searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainPanel
            // 
            this._mainPanel.Controls.Add(this._tabControl);
            this._mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainPanel.Location = new System.Drawing.Point(0, 69);
            this._mainPanel.Margin = new System.Windows.Forms.Padding(0);
            this._mainPanel.Name = "_mainPanel";
            this._mainPanel.Size = new System.Drawing.Size(698, 459);
            this._mainPanel.TabIndex = 1;
            // 
            // _tabControl
            // 
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.Location = new System.Drawing.Point(0, 0);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(698, 459);
            this._tabControl.TabIndex = 0;
            // 
            // _backPanel
            // 
            this._backPanel.BackColor = System.Drawing.Color.White;
            this._backPanel.Controls.Add(this._mainPanel);
            this._backPanel.Controls.Add(this._searchPanel);
            this._backPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._backPanel.Location = new System.Drawing.Point(0, 0);
            this._backPanel.Name = "_backPanel";
            this._backPanel.Size = new System.Drawing.Size(698, 528);
            this._backPanel.TabIndex = 3;
            // 
            // _searchPanel
            // 
            this._searchPanel.BackColor = System.Drawing.Color.White;
            this._searchPanel.Controls.Add(this._customerBox);
            this._searchPanel.Controls.Add(this._usernameLabel);
            this._searchPanel.Controls.Add(this._searchBox);
            this._searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._searchPanel.Location = new System.Drawing.Point(0, 0);
            this._searchPanel.Name = "_searchPanel";
            this._searchPanel.Size = new System.Drawing.Size(698, 69);
            this._searchPanel.TabIndex = 2;
            // 
            // _usernameLabel
            // 
            this._usernameLabel.AutoSize = true;
            this._usernameLabel.Location = new System.Drawing.Point(13, 13);
            this._usernameLabel.Name = "_usernameLabel";
            this._usernameLabel.Size = new System.Drawing.Size(184, 13);
            this._usernameLabel.TabIndex = 1;
            this._usernameLabel.Text = "Inserisci username o cognome cliente";
            // 
            // _searchBox
            // 
            this._searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._searchBox.Location = new System.Drawing.Point(454, 12);
            this._searchBox.Name = "_searchBox";
            this._searchBox.Size = new System.Drawing.Size(232, 20);
            this._searchBox.TabIndex = 0;
            // 
            // _customerBox
            // 
            this._customerBox.FormattingEnabled = true;
            this._customerBox.Location = new System.Drawing.Point(16, 42);
            this._customerBox.Name = "_customerBox";
            this._customerBox.Size = new System.Drawing.Size(670, 21);
            this._customerBox.TabIndex = 2;
            // 
            // PrenotationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 528);
            this.Controls.Add(this._backPanel);
            this.MinimumSize = new System.Drawing.Size(500, 250);
            this.Name = "PrenotationView";
            this.Text = "PrenotationView";
            this._mainPanel.ResumeLayout(false);
            this._backPanel.ResumeLayout(false);
            this._searchPanel.ResumeLayout(false);
            this._searchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel _mainPanel;
        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.Panel _backPanel;
        private System.Windows.Forms.Panel _searchPanel;
        private System.Windows.Forms.Label _usernameLabel;
        private System.Windows.Forms.TextBox _searchBox;
        private System.Windows.Forms.ComboBox _customerBox;
    }
}