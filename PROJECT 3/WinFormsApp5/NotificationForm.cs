using System;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class NotificationForm : Form
    {
        private NotificationSystem notificationSystem;

        public NotificationForm(NotificationSystem notificationSystem)
        {
            InitializeComponent();
            this.notificationSystem = notificationSystem;
            DisplayAlertHistory();
        }

        // Method to display alert history
        private void DisplayAlertHistory()
        {
            var alertHistory = notificationSystem.GetAlertHistory();
            lstNotifications.Items.Clear();
            foreach (var alert in alertHistory)
            {
                lstNotifications.Items.Add(alert);
            }
        }
    }
}
