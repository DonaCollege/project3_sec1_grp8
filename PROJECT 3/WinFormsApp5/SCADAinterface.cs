using System;
using System.Collections.Generic;

namespace WinFormsApp5
{
    public class SCADAinterface
    {
        private Dictionary<string, string> deviceStatus;
        private NotificationSystem notificationSystem;

        public SCADAinterface()
        {
            deviceStatus = new Dictionary<string, string>();
            notificationSystem = new NotificationSystem();
            LoadDeviceConfigurations();
        }

        public bool AuthenticateUser(string username, string password)
        {
            return username == "admin" && password == "password";
        }

        public void DisplayDeviceStatus()
        {
            foreach (var device in deviceStatus)
            {
                Console.WriteLine($"{device.Key}: {device.Value}");
            }
        }

        public string ExecuteUserCommand(string command)
        {
            string result;
            switch (command)
            {
                case "Turn on lights":
                    deviceStatus["Lights"] = "On";
                    result = "Lights turned on.";
                    break;
                case "Turn off lights":
                    deviceStatus["Lights"] = "Off";
                    result = "Lights turned off.";
                    break;
                default:
                    result = "Invalid command.";
                    break;
            }
            notificationSystem.AddNotification(result);
            return result;
        }

        public void UpdateTemperature()
        {
            // Simulate a new random temperature value
            string newTemperature = new Random().Next(15, 30).ToString() + "°C";
            deviceStatus["Temperature"] = newTemperature;
            notificationSystem.AddNotification($"Temperature updated to {newTemperature}");
        }

        public void DisplayAlert(string alert)
        {
            notificationSystem.AddNotification("ALERT: " + alert, true); // Call works now
        }

        public void LogActivity(string action)
        {
            notificationSystem.AddNotification(action); // Call works now
        }


        

        public void UpdateDeviceStatus(Dictionary<string, string> status)
        {
            foreach (var item in status)
            {
                deviceStatus[item.Key] = item.Value;
            }
        }

        private void LoadDeviceConfigurations()
        {
            deviceStatus["Lights"] = "Off\n";
            deviceStatus["Temperature"] = new Random().Next(15, 30).ToString() + "°C";
            deviceStatus["Motion Sensor"] = "No motion detected";
            deviceStatus["Smart Lock"] = "Unlocked";
            deviceStatus["Camera"] = "Inactive";
        }

        public Dictionary<string, string> GetDeviceStatus()
        {
            return deviceStatus;
        }
        public bool AcceptUserCredentials(string username, string password)
        {
            return AuthenticateUser(username, password);
        }

        

        public void ReceiveAlertData(string alertData)
        {
            DisplayAlert(alertData);
        }

        public bool GetAuthenticationStatus(string username, string password)
        {
            return AuthenticateUser(username, password);
        }

       

        ~SCADAinterface()
        {
            SaveLogs();
            ClearUserSessions();
        }

        private void SaveLogs()
        {
            Console.WriteLine("Logs saved.");
        }

        private void ClearUserSessions()
        {
            Console.WriteLine("User sessions cleared.");
        }


    }
}
