using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class NotificationForm : Form
    {
        public NotificationForm()
        {
            InitializeComponent();

            // Subscribe to notifications and alerts
            NotificationManager.OnNotificationReceived += DisplayNotification;
            NotificationManager.OnAlertReceived += DisplayAlert;
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            // Load existing notifications
            foreach (var notification in NotificationManager.GetAllNotifications())
            {
                NOTIFICATIONS.Items.Add(notification);
            }

            // Load existing alerts
            foreach (var alert in NotificationManager.GetAllAlerts())
            {
                ALERTS.Items.Add(alert);
            }
        }

        private void DisplayNotification(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => NOTIFICATIONS.Items.Add(message)));
            }
            else
            {
                NOTIFICATIONS.Items.Add(message);
            }
        }

        private void DisplayAlert(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ALERTS.Items.Add(message)));
            }
            else
            {
                ALERTS.Items.Add(message);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "Notifications.txt";
                File.WriteAllLines(filePath, NotificationManager.GetAllNotifications());
                MessageBox.Show($"Notifications saved to {filePath}.", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving notifications: {ex.Message}", "Error");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void btnClearAll_Click(object sender, EventArgs e)
        {
            // Clear both ListBoxes
            NOTIFICATIONS.Items.Clear();
            ALERTS.Items.Clear();

            // Clear notifications and alerts in NotificationManager
            NotificationManager.ClearNotifications();
            NotificationManager.ClearAlerts();

            // Show a confirmation message (optional)
            MessageBox.Show("All notifications and alerts have been cleared.", "Clear All", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Alert_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


    public static class NotificationManager
    {
        private static readonly List<string> _notifications = new List<string>();
        private static readonly List<string> _alerts = new List<string>();

        public static event Action<string> OnNotificationReceived;
        public static event Action<string> OnAlertReceived;

        public static void AddNotification(string message)
        {
            _notifications.Add(message);
            OnNotificationReceived?.Invoke(message);
        }

        public static void AddAlert(string message)
        {
            _alerts.Add(message);
            OnAlertReceived?.Invoke(message);
        }

        public static List<string> GetAllNotifications()
        {
            return new List<string>(_notifications);
        }

        public static List<string> GetAllAlerts()
        {
            return new List<string>(_alerts);
        }

        // Add this method to clear notifications
        public static void ClearNotifications()
        {
            _notifications.Clear();
        }

        // Add this method to clear alerts
        public static void ClearAlerts()
        {
            _alerts.Clear();
        }
    }



}
