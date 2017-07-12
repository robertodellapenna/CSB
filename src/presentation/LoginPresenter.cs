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
            if (_postLoginForm.Tag == null)
                _postLoginForm.Tag = new Dictionary<string, Object>();
            else
            {
                if (!(_postLoginForm.Tag is Dictionary<string, Object>))
                {
                    Dictionary<string, Object> dict = new Dictionary<string, object>();
                    dict.Add("previousTagValue", _postLoginForm.Tag);
                    _postLoginForm.Tag = dict;
                }
            }
            (_postLoginForm.Tag as Dictionary<string, Object>)["loginInformation"] 
                = new LoginInformation(_usernameBox.Text, _passwordBox.Text.ToSHA512());
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


        public interface ILoginInformation
        {
            String Username { get; }
            String PasswordHash { get; }
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
