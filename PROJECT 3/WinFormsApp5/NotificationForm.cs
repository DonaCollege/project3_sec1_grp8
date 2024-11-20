namespace WinFormsApp5
{
    public partial class NotificationForm : Form
    {
        private NotificationSystem notificationSystem;

        public NotificationForm()
        {
            InitializeComponent();
            notificationSystem = new NotificationSystem();
            UpdateAlertHistory();
        }

        // Updates the ListBox with the latest alert history
        private void UpdateAlertHistory()
        {
            lstNotifications.Items.Clear();
            var alertHistory = notificationSystem.GetAlertHistory();
            foreach (var alert in alertHistory)
            {
                lstNotifications.Items.Add(alert);
            }
        }

        // Simulates a new random alert and adds it to the alert history
        private void SimulateSensorData()
        {
            // Create a random alert message
            string randomAlert = GenerateRandomAlert(out double sensorValue);

            // Pass the random alert and sensor value to the NotificationSystem
            notificationSystem.GenerateAlertNotification(randomAlert, sensorValue);

            // Update the alert history with the new alert
            lstNotifications.Items.Add($"{randomAlert} (Sensor Value: {sensorValue})");
        }

        // Generates a random alert message and returns the alert along with a random sensor value
        private string GenerateRandomAlert(out double sensorValue)
        {
            string[] alerts = new string[]
            {
                "Temperature alert: exceeds threshold!",
                "Motion detected in the living room.",
                "Humidity alert: in the basement.",
                "Smoke detected in the kitchen.",
                "Front door opened."
            };

            Random rand = new Random();
            sensorValue = rand.Next(1, 100); // Random sensor value between 1 and 100

            return alerts[rand.Next(alerts.Length)];
        }

        // Button click event to simulate sensor data and generate alerts
        private void btnSimulateAlert_Click(object sender, EventArgs e)
        {
            SimulateSensorData();
        }

        // Button click event to clear the alert history
        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            lstNotifications.Items.Clear();
        }
    }
}
