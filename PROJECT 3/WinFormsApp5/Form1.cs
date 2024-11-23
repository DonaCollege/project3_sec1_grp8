using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        private SCADAinterface scadaInterface;
        private string notificationsLog = "";
        private Dictionary<string, string> users;

        // Update Form1 constructor to accept dependencies
        public Form1(SCADAinterface scadaInterface, Dictionary<string, string> users)
        {
            InitializeComponent();
            this.scadaInterface = scadaInterface;
            this.users = users; // Pass users dictionary
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayDeviceStatus();
            MessageBox.Show("Welcome to the SCADA/HMI Interface!");
        }

        private void DisplayDeviceStatus()
        {
            var status = scadaInterface.GetDeviceStatus();

            // Update all device statuses in txtStatus
            string statusText = string.Join(Environment.NewLine, status);
            txtStatus.Text = "Device Status:\n" + statusText;

           
        }

        private void UpdateNotification(string message, bool isAlert = false)
        {
            string logEntry = (isAlert ? "[ALERT] " : "") + message;
            notificationsLog += logEntry + Environment.NewLine;
            txtStatus.Text = notificationsLog;
        }




        private Dictionary<string, string> LoadUsers()
        {
            var userDictionary = new Dictionary<string, string>();
            string filePath = "users.txt";

            if (File.Exists(filePath))
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        userDictionary[parts[0]] = parts[1];
                    }
                }
            }
            return userDictionary;
        }

        private void SaveUsers()
        {
            string filePath = "users.txt";
            var lines = new List<string>();
            foreach (var user in users)
            {
                lines.Add($"{user.Key},{user.Value}");
            }
            File.WriteAllLines(filePath, lines);
        }

        private void AddUser(string username, string password)
        {
            if (!users.ContainsKey(username))
            {
                users[username] = password;
                SaveUsers();
                MessageBox.Show("User added successfully!", "Success");
            }
            else
            {
                MessageBox.Show("User already exists!", "Error");
            }
        }

        private void DeleteUser(string username)
        {
            if (users.ContainsKey(username))
            {
                users.Remove(username);
                SaveUsers();
                MessageBox.Show("User deleted successfully!", "Success");
            }
            else
            {
                MessageBox.Show("User does not exist!", "Error");
            }
        }

        /*private void buttonAddUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                AddUser(username, password);
            }
            else
            {
                MessageBox.Show("Username and password cannot be empty!", "Error");
            }
        }*/

        /*  private void buttonDeleteUser_Click(object sender, EventArgs e)
          {
              string username = txtUsername.Text.Trim();
              if (!string.IsNullOrEmpty(username))
              {
                  DeleteUser(username);
              }
              else
              {
                  MessageBox.Show("Username cannot be empty!", "Error");
              }
          }*/

        
        private void button7_Click(object sender, EventArgs e)
        {
            // Logic for button7 click
            scadaInterface.UpdateTemperature();
            DisplayDeviceStatus();
            UpdateNotification("Temperature sensor updated.");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Exit the application
            UpdateNotification("Exiting application.");
            Application.Exit();
        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
