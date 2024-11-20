using System;
using System.Collections.Generic;
using System.IO;

namespace WinFormsApp5
{
    public class NotificationSystem
    {
        private Dictionary<string, double> alertThresholds;
        private List<string> alertHistory;

        public NotificationSystem()
        {
            // Initialize thresholds and alert history
            alertThresholds = new Dictionary<string, double>
            {
                { "Temperature", 30.0 },
                { "Motion", 1.0 }
            };
            alertHistory = new List<string>();
            LoadAlertThresholds();
        }

        // Method to generate alerts based on sensor data
        public void GenerateAlert(string sensorType, double sensorValue)
        {
            if (alertThresholds.ContainsKey(sensorType) && sensorValue >= alertThresholds[sensorType])
            {
                string alertMessage = $"{sensorType} alert! Value: {sensorValue} exceeded threshold.";
                SendAlertToHMI(alertMessage);
                LogAlert(alertMessage);
            }
        }

        // Sends the alert to the SCADA/HMI Interface for display
        private void SendAlertToHMI(string alertMessage)
        {
            // Update the HMI with the alert (UI interaction will be handled in the form)
            Console.WriteLine("Alert sent to HMI: " + alertMessage);
            // You can further implement an event or method to trigger HMI updates here.
        }

        // Logs the alert history
        private void LogAlert(string alertMessage)
        {
            alertHistory.Add($"{DateTime.Now}: {alertMessage}");
        }

        // Retrieves the alert history for display
        public List<string> GetAlertHistory()
        {
            return alertHistory;
        }

        // Receives sensor data and generates alerts if thresholds are exceeded
        public void ReceiveSensorData(Dictionary<string, double> sensorData)
        {
            foreach (var sensor in sensorData)
            {
                GenerateAlert(sensor.Key, sensor.Value);
            }
        }

        // Stores alert thresholds
        public void SetAlertThresholds(Dictionary<string, double> thresholds)
        {
            alertThresholds = thresholds;
        }

        // Generates alert notifications
        public string GenerateAlertNotification(string sensorType, double sensorValue)
        {
            if (alertThresholds.ContainsKey(sensorType) && sensorValue >= alertThresholds[sensorType])
            {
                string alertMessage = $"{sensorType} alert! Value: {sensorValue} exceeded threshold.";
                LogAlert(alertMessage);
                return alertMessage;
            }
            return null;
        }

        // Load alert thresholds from a file
        private void LoadAlertThresholds()
        {
            // Simulate loading from a file
            alertThresholds["Temperature"] = 30.0;
            alertThresholds["Motion"] = 1.0;
        }

        // Destructor to save alert history
        ~NotificationSystem()
        {
            SaveAlertHistory();
        }

        private void SaveAlertHistory()
        {
            // Simulate saving to a file
            Console.WriteLine("Alert history saved.");

        }

       
    }
}
