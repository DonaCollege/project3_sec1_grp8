using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp5
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Define users and passwords
            Dictionary<string, string> users = new Dictionary<string, string>
            {
                { "admin", "password123" },
                { "user1", "welcome1" },
                { "user2", "securepass" }
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show Login Form
            LoginForm loginForm = new LoginForm(users);
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Create SCADA interface instance
                SCADAinterface scadaInterface = new SCADAinterface();

                // Redirect to SCADA/HMI form (Form1) and pass SCADAinterface and users
                Application.Run(new Form1(scadaInterface, users)); // Pass both dependencies
            }
            else
            {
                // Exit application if login fails
                MessageBox.Show("Exiting application. Login required.", "Login Failed");
                Application.Exit();
            }
        }
    }
}
