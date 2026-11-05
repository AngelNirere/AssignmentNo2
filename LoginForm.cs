using System;
using System.Windows.Forms;

namespace Lab2
{
    public class LoginForm : BaseForm
    {
        TextBox txtUser, txtPass;
        Button btnLogin;

        public LoginForm()
        {
            Text = "Login";
            ClientSize = new System.Drawing.Size(320, 190);

            var lblUser = new Label { Text = "Username:", Left = 20, Top = 25, AutoSize = true };
            txtUser = new TextBox { Left = 110, Top = 22, Width = 180 };
            var lblPass = new Label { Text = "Password:", Left = 20, Top = 70, AutoSize = true };
            txtPass = new TextBox { Left = 110, Top = 67, Width = 180, UseSystemPasswordChar = true };
            btnLogin = new Button { Text = "Login", Left = 110, Top = 115, Width = 100, Height = 32 };
            btnLogin.Click += BtnLogin_Click;

            Controls.AddRange(new Control[] { lblUser, txtUser, lblPass, txtPass, btnLogin });
            AcceptButton = btnLogin;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Username and Password cannot be empty.", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            GoTo(new ChooseForm());
        }
    }
}