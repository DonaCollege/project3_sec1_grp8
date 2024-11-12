using System;
using System.Collections.Generic;
using System.IO;

namespace WinFormsApp5
{
    internal class SCADAinterface
    {
        private Dictionary<string, string> deviceStatus;
        private NotificationSystem notificationSystem;

        public SCADAinterface()
        {
            deviceStatus = new Dictionary<string, string>();
            notificationSystem = new NotificationSystem();
            LoadDeviceConfigurations();
        }

        // Authenticates the user
        public bool AuthenticateUser(string username, string password)
        {
            // Implement a more secure authentication mechanism as needed
            return username == "admin" && password == "password";
        }

        // Display device statuses
        public void DisplayDeviceStatus()
        {
            foreach (var device in deviceStatus)
            {
                Console.WriteLine($"{device.Key}: {device.Value}");
            }
        }

        // Execute command to control a device
        public string ExecuteUserCommand(string command)
        {
            if (command == "Turn on lights")
            {
                deviceStatus["Lights"] = "On";
                notificationSystem.GenerateAlert("Lights", 1.0); // Simulate an alert
                return "Lights turned on.";
            }
            else
            {
                return "Invalid command.";
            }
        }

        // Display alerts from NotificationSystem
        public void DisplayAlert(string alert)
        {
            Console.WriteLine("Displaying alert on HMI: " + alert);
        }

        // Logs activity
        public void LogActivity(string action)
        {
            Console.WriteLine($"{DateTime.Now}: {action}");
        }

        // Accepts user credentials for authentication
        public bool AcceptUserCredentials(string username, string password)
        {
            return AuthenticateUser(username, password);
        }

        // Accepts device status updates
        public void UpdateDeviceStatus(Dictionary<string, string> status)
        {
            foreach (var item in status)
            {
                deviceStatus[item.Key] = item.Value;
            }
            DisplayDeviceStatus();
        }

        // Receives alert data from NotificationSystem
        public void ReceiveAlertData(string alertData)
        {
            DisplayAlert(alertData);
        }

        // Returns authentication status
        public bool GetAuthenticationStatus(string username, string password)
        {
            return AuthenticateUser(username, password);
        }

        // Generates command feedback
        public string GenerateCommandFeedback(string command)
        {
            return ExecuteUserCommand(command);
        }

        // Load initial device configurations and simulated data
        private void LoadDeviceConfigurations()
        {
            // Simulated loading from a JSON file
            deviceStatus["Lights"] = "Off";
            deviceStatus["Temperature"] = new Random().Next(15, 30).ToString() + "°C";
            deviceStatus["Motion Sensor"] = "No motion detected";
            deviceStatus["Smart Lock"] = "Unlocked";
            deviceStatus["Camera"] = "Inactive";
        }

        // Destructor to save logs and clear sessions
        ~SCADAinterface()
        {
            SaveLogs();
            ClearUserSessions();
        }

        private void SaveLogs()
        {
            // Simulated log saving
            Console.WriteLine("Logs saved.");
        }

        private void ClearUserSessions()
        {
            // Simulated session clearing
            Console.WriteLine("User sessions cleared.");
        }

        // Method to get the current device status
        public Dictionary<string, string> GetDeviceStatus()
        {
            return deviceStatus;
        }
    }
}
