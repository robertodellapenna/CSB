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
        private TextBox passwordBox, usernameBox;

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
            usernameBox = view.UsernameBox;
            passwordBox = view.PasswordBox;

            usernameBox.ApplyStyle(style);
            passwordBox.ApplyStyle(style);

            usernameBox.Tag = (char)0;
            passwordBox.Tag = '*';

            usernameBox.GotFocus +=
                (obj, e) => RemoveHint(usernameBox, usernameHint);
            usernameBox.LostFocus += 
                (obj, e) => SetHint(usernameBox, usernameHint);
            passwordBox.GotFocus +=
                (obj, e) => RemoveHint(passwordBox, passwordHint);
            passwordBox.LostFocus +=
                (obj, e) => SetHint(passwordBox, passwordHint);

            if (!usernameBox.Focused)
                SetHint(usernameBox, usernameHint);
            if (!passwordBox.Focused)
                SetHint(passwordBox, passwordHint);

            //init login button
            Button loginButton = view.LoginButton;
            loginButton.BackColor = Color.Blue;
            loginButton.ForeColor = Color.White;
            loginButton.Click += LoginHandler;
        }

        private void LoginHandler(Object obj, EventArgs e)
        {
            // controlla login
            if(!_loginChecker(usernameBox.Text, passwordBox.Text))
            {
                MessageBox.Show("Dati di login non validi");
                return;
            }
            //lancio la nuova view e attendo la chiusura
            _loginView.Hide();
            _postLoginForm.Show();
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
    }
}
