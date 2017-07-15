using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSB_Project.src.presentation
{
    public partial class LoginView : Form
    {
        public TextBox UsernameBox => _usernameBox;
        public TextBox PasswordBox => _passwordBox;
        public Button LoginButton => _loginButton;
        public Button CustomerButton => _customerButton;
        public Button StaffButton => _staffButton;
        public Button GuestButton => _guestButton;

        public LoginView()
        {
            InitializeComponent();
        }
    }
}
