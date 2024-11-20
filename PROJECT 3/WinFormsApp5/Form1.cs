using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        private SCADAinterface scadaInterface;       // Instance of SCADAInterface
        private NotificationSystem notificationSystem; // Instance of NotificationSystem

        public Form1()
        {
            InitializeComponent();
            scadaInterface = new SCADAinterface();       // Initialize SCADAInterface
            notificationSystem = new NotificationSystem(); // Initialize NotificationSystem
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize the interface (if needed)
            DisplayDeviceStatus();
        }

        // Method to display the status of each device on the form
        private void DisplayDeviceStatus()
        {
            var status = scadaInterface.GetDeviceStatus();
            string statusText = string.Join(Environment.NewLine, status);
            txtStatus.Text = "Device Status:\n" + statusText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Simulate a user command to control a device, such as turning on lights
            string result = scadaInterface.ExecuteUserCommand("Turn on lights");
            MessageBox.Show(result);  // Display result in a message box
            DisplayDeviceStatus();    // Update the status display
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Simulate a user command to control a device, such as turning on lights
            string result = scadaInterface.ExecuteUserCommand("Turn on lights");
            MessageBox.Show(result);  // Display result in a message box
            DisplayDeviceStatus();    // Update the status display
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Simulate a smart lock status change
            scadaInterface.UpdateDeviceStatus(new Dictionary<string, string> { { "Smart Lock", "Locked" } });
            DisplayDeviceStatus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Open the NotificationForm to display alert history
            NotificationForm notificationForm = new NotificationForm();
            notificationForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Simulate a camera status change
            scadaInterface.UpdateDeviceStatus(new Dictionary<string, string> { { "Camera", "Active" } });
            DisplayDeviceStatus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Simulate a motion sensor status change
            scadaInterface.UpdateDeviceStatus(new Dictionary<string, string> { { "Motion Sensor", "No motion detected" } });
            DisplayDeviceStatus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Simulate a temperature change
            scadaInterface.UpdateDeviceStatus(new Dictionary<string, string> { { "Temperature", new Random().Next(15, 30).ToString() + "°C" } });
            DisplayDeviceStatus();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Simulate a user command to control a device, such as turning on lights
            string result = scadaInterface.ExecuteUserCommand("Turn on lights");
            MessageBox.Show(result);  // Display result in a message box
            DisplayDeviceStatus();    // Update the status display
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {

        }
    }
}
