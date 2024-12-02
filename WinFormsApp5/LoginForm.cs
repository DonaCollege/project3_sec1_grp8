using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class LoginForm : Form
    {
        private Dictionary<string, string> users;

        public LoginForm(Dictionary<string, string> users)
        {
            InitializeComponent();
            this.users = users;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (users.ContainsKey(username) && users[username] == password)
            {
                MessageBox.Show($"Welcome {username}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK; // Sets the result to OK for redirection
                this.Close(); // Closes the login form

            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter your username to retrieve the password.", "Forgot Password");
            }
            else if (users.ContainsKey(username))
            {
                MessageBox.Show($"The password for {username} is: {users[username]}", "Password Retrieved");
            }
            else
            {
                MessageBox.Show("Username not found. Please check and try again.", "Error");
            }
        }
    }
}
