using CSB_Project.src.model.Utils;
using CSB_Project.src.presentation.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSB_Project.src.presentation
{
    public class LoginPresenter
    {
        private Form _postLoginForm;
        private Form _loginView;
        private Func<string, string, bool> _loginChecker;
        private TextBox _passwordBox, _usernameBox;

        public LoginPresenter(LoginView view, Form postLoginForm, Func<string, string, bool> loginChecker, Style style = null)
        {
            #region Precondizioni
            if (postLoginForm == null)
                throw new ArgumentNullException("postLoginForm null");
            if (view == null)
                throw new ArgumentNullException("view null");
            if (loginChecker == null)
                throw new ArgumentNullException("login checker null");
            #endregion
            _loginChecker = loginChecker;
            _loginView = view;
            _postLoginForm = postLoginForm;
            string usernameHint = "Inserisci l'username";
            string passwordHint = "Inserisci la password";

            view.ApplyStyle(style);
            
            // init textbox
            _usernameBox = view.UsernameBox;
            _passwordBox = view.PasswordBox;

            _usernameBox.ApplyStyle(style);
            _passwordBox.ApplyStyle(style);

            _usernameBox.Tag = (char)0;
            _passwordBox.Tag = '*';

            _usernameBox.GotFocus +=
                (obj, e) => RemoveHint(_usernameBox, usernameHint);
            _usernameBox.LostFocus += 
                (obj, e) => SetHint(_usernameBox, usernameHint);
            _passwordBox.GotFocus +=
                (obj, e) => RemoveHint(_passwordBox, passwordHint);
            _passwordBox.LostFocus +=
                (obj, e) => SetHint(_passwordBox, passwordHint);

            if (!_usernameBox.Focused)
                SetHint(_usernameBox, usernameHint);
            if (!_passwordBox.Focused)
                SetHint(_passwordBox, passwordHint);

            //init login button
            Button loginButton = view.LoginButton;
            loginButton.BackColor = Color.Blue;
            loginButton.ForeColor = Color.White;
            loginButton.Click += LoginHandler;

            Button guestButton = view.GuestButton;
            guestButton.BackColor = SystemColors.Control;
            guestButton.Click += (obj, a) => HackLogin(null, "");

            Button customerButton = view.CustomerButton;
            customerButton.BackColor = SystemColors.Control;
            customerButton.Click += (obj, a) => HackLogin("lorenzo.antonini", "admin");

            Button staffButton = view.StaffButton;
            staffButton.BackColor = SystemColors.Control;
            staffButton.Click += (obj, a) => HackLogin("giovanni.admin", "admin");
        }

        private void HackLogin(string username, string password)
        {
            
            //lancio la nuova view e attendo la chiusura
            _loginView.Hide();
            _postLoginForm.Show();
            _postLoginForm.AddLoginInformation(new LoginInformation(username, password.ToSHA512()));
            _postLoginForm.FormClosed +=
                (o, ev) => _loginView.Close();
        }

        private void LoginHandler(Object obj, EventArgs e)
        {
            // controlla login
            if(!_loginChecker(_usernameBox.Text, _passwordBox.Text.ToSHA512()))
            {
                MessageBox.Show("Dati di login non validi");
                return;
            }
            //lancio la nuova view e attendo la chiusura
            _loginView.Hide();
            _postLoginForm.Show();
            _postLoginForm.AddLoginInformation(new LoginInformation(_usernameBox.Text, _passwordBox.Text.ToSHA512()));
            _postLoginForm.FormClosed +=
                (o, ev) => _loginView.Close();
        }

        private void SetHint(TextBox tb, string msg)
        {
            if (String.IsNullOrWhiteSpace(tb.Text))
            {
                tb.PasswordChar = (char)0;
                tb.SetHint(msg, Color.Gray);
            }
        }

        private void RemoveHint(TextBox tb, string msg)
        {
            if(tb.Text == msg)
            {
                tb.PasswordChar = (char)tb.Tag;
                tb.RemoveHint(Color.Black);
            }
        }

        private struct LoginInformation : ILoginInformation
        {
            private string _username, _passwordHash;
            public String Username => _username;
            public String PasswordHash => _passwordHash;

            public LoginInformation(string username, string passwordHash)
            {
                _username = username;
                _passwordHash = passwordHash;
            }
        }

    }
}
