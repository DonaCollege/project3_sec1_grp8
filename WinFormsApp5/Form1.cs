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

        /*  private void Form1_Load(object sender, EventArgs e)
          {
              //DisplayDeviceStatus();
              MessageBox.Show("Welcome to the SCADA/HMI Interface!");
          }
  */
        /* private void DisplayDeviceStatus()
         {
             var status = scadaInterface.GetDeviceStatus();

             // Update all device statuses in txtStatus
             string statusText = string.Join(Environment.NewLine, status);
             //txtStatus.Text = "Device Status:\n" + statusText;


         }
 */
        private void UpdateNotification(string message, bool isAlert = false)
        {
            string logEntry = (isAlert ? "[ALERT] " : "") + message;
            notificationsLog += logEntry + Environment.NewLine;
            // txtStatus.Text = notificationsLog;
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
        private void button5_Click(object sender, EventArgs e)
        {
            // Instantiate and show the CameraForm
            CameraForm cameraForm = new CameraForm();
            cameraForm.Show();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            // Create an instance of the TemperatureSensorForm
            TemperatureSensorForm temperatureSensorForm = new TemperatureSensorForm();

            // Show the form
            temperatureSensorForm.Show();
        }

        private void SaveData()
        {
            try
            {
                // Example: Save notifications or logs to a file
                string filePath = "application_data.txt";
                List<string> dataToSave = NotificationManager.GetAllNotifications(); // Replace with your data source
                File.WriteAllLines(filePath, dataToSave);

                MessageBox.Show($"Data saved successfully to {filePath}.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save your changes before exiting?",
                                                  "Save Changes",
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                SaveData(); // Call a method to save data
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {
                Application.Exit();
            }
            // If Cancel is selected, do nothing
        }



        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            LightModuleForm lightModuleForm = new LightModuleForm(); // Pass Form1 instance
            lightModuleForm.Show();
        }




        private void button3_Click(object sender, EventArgs e)
        {
            // Instantiate the SmartLockForm
            SmartLockForm smartLockForm = new SmartLockForm();

            // Display the SmartLockForm
            smartLockForm.Show(); // Use ShowDialog() for a modal dialog if needed
        }





        private void button6_Click(object sender, EventArgs e)
        {
            // Create an instance of the MotionSensorForm
            MotionSensorForm motionSensorForm = new MotionSensorForm();

            // Show the Motion Sensor Form
            motionSensorForm.ShowDialog(); // Use ShowDialog for a modal form or Show for a non-modal form
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Create and show the NotificationForm
            NotificationForm notificationForm = new NotificationForm();
            notificationForm.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        /* public void UpdateDeviceStatus()
         {
             // Fetch the current status of devices from SCADAinterface
             var status = scadaInterface.GetDeviceStatus();

             // Format the status into a readable string
             string statusText = string.Join(Environment.NewLine, status.Select(kv => $"{kv.Key}: {kv.Value}"));

             // Display the status in the SCADA interface box (txtStatus)
             txtStatus.Text = statusText;
         }*/


    }
}