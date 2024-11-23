using System;
using System.Collections.Generic;
using System.IO;

namespace WinFormsApp5
{
    public class NotificationSystem
    {
        private Dictionary<string, double> alertThresholds;
        private List<string> alertHistory;
        private List<string> notifications;


        public NotificationSystem()
        {   

            alertThresholds = new Dictionary<string, double>();
            alertHistory = new List<string>();
            LoadAlertThresholds(); // Load thresholds from file or defaults

        }


       
        public void AddNotification(string message, bool isAlert = false)
        {
            string notification = isAlert ? $"[ALERT]: {message}" : message;
            notifications.Add(notification);

            // For now, we simulate displaying the notification in the console.
            Console.WriteLine(notification);
        }
        public void GenerateAlert(string sensorType, double sensorValue)
        {
            if (alertThresholds.ContainsKey(sensorType) && sensorValue >= alertThresholds[sensorType])
            {
                string alertMessage = $"{sensorType} alert! Value: {sensorValue} exceeded threshold.";
                SendAlertToHMI(alertMessage);
                LogAlert(alertMessage);
            }
        }

        private void SendAlertToHMI(string alertMessage)
        {
            Console.WriteLine("Alert sent to HMI: " + alertMessage);
        }

        private void LogAlert(string alertMessage)
        {
            alertHistory.Add($"{DateTime.Now}: {alertMessage}");
        }

        public List<string> GetAlertHistory()
        {
            return new List<string>(alertHistory);
        }

        public void ReceiveSensorData(Dictionary<string, double> sensorData)
        {
            foreach (var sensor in sensorData)
            {
                GenerateAlert(sensor.Key, sensor.Value);
            }
        }

        public void SetAlertThresholds(Dictionary<string, double> thresholds)
        {
            alertThresholds = thresholds;
        }

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

        private void LoadAlertThresholds()
        {
            alertThresholds["Temperature"] = 30.0;
            alertThresholds["Motion"] = 1.0;
        }

        ~NotificationSystem()
        {
            SaveAlertHistory();
        }

        public void SaveAlertHistory()
        {
            try
            {
                string filePath = "AlertHistory.txt";
                File.WriteAllLines(filePath, alertHistory);
                Console.WriteLine("Alert history saved to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving alert history: " + ex.Message);
            }
        }
    }

}
