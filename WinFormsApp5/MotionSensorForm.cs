using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class MotionSensorForm : Form
    {
        private readonly MotionSensor _motionSensor;

        public MotionSensorForm()
        {
            InitializeComponent();
            _motionSensor = new MotionSensor();

            // Subscribe to MotionSensor events
            _motionSensor.OnFrequencyChange += UpdateFrequencyDisplay;
            _motionSensor.OnMotionDetected += HandleMotionDetected;
            _motionSensor.OnStatusUpdated += UpdateStatusLabel;
        }

        private void MotionSensorForm_Load(object sender, EventArgs e)
        {
            _motionSensor.EnableMotionDetection();
            NotificationManager.AddNotification("Motion detection enabled.");
        }

        private void buttonSetSensitivity_Click(object sender, EventArgs e)
        {
            try
            {
                double sensitivity = double.Parse(textBoxSensitivity.Text);

                // Validate range in UI as well
                if (sensitivity < 4 || sensitivity > 10)
                {
                    MessageBox.Show("Sensitivity must be between 4 and 10.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _motionSensor.SetSensitivity(sensitivity);
                NotificationManager.AddNotification($"Motion sensitivity set to {sensitivity}.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid numeric value for sensitivity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEnable_Click(object sender, EventArgs e)
        {
            _motionSensor.EnableMotionDetection();
            NotificationManager.AddNotification("Motion detection enabled.");
        }

        private void buttonDisable_Click(object sender, EventArgs e)
        {
            _motionSensor.DisableMotionDetection();
            NotificationManager.AddNotification("Motion detection disabled.");
        }

        private void buttonFakeMotion_Click(object sender, EventArgs e)
        {
            _motionSensor.TriggerFakeMotion();
            NotificationManager.AddNotification("Fake motion event triggered.");
        }

        private void UpdateFrequencyDisplay(double frequency)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => labelFrequency.Text = $"Current Frequency: {frequency:F2}"));
            }
            else
            {
                labelFrequency.Text = $"Current Frequency: {frequency:F2}";
            }

            // Log frequency update
            NotificationManager.AddNotification($"Motion frequency updated to {frequency:F2}.");
        }

        private void HandleMotionDetected(string alertMessage)
        {
            // Log motion detection
            NotificationManager.AddNotification("Motion detected!");

            // If motion is above the threshold, send an alert
            NotificationManager.AddAlert(alertMessage);
            //ShowAlert(alertMessage);
        }

        private void UpdateStatusLabel(string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => labelStatus.Text = status));
            }
            else
            {
                labelStatus.Text = status;
            }

            // Log status update
            NotificationManager.AddNotification($"Motion sensor status updated: {status}.");
        }

        public class MotionSensor
        {
            private double sensitivity = 5.0;
            private const double MotionThreshold = 8.0;

            public event Action<double> OnFrequencyChange;
            public event Action<string> OnMotionDetected;
            public event Action<string> OnStatusUpdated;

            public void SetSensitivity(double newSensitivity)
            {
                if (newSensitivity < 4 || newSensitivity > 10)
                {
                    throw new ArgumentException("Sensitivity must be between 4 and 10.");
                }

                sensitivity = newSensitivity;
                OnStatusUpdated?.Invoke($"Sensitivity set to {newSensitivity}.");
            }

            public void EnableMotionDetection()
            {
                OnStatusUpdated?.Invoke("Motion detection enabled.");
            }

            public void DisableMotionDetection()
            {
                OnStatusUpdated?.Invoke("Motion detection disabled.");
            }

            public void TriggerFakeMotion()
            {
                double detectedMotion = new Random().NextDouble() * 10; // Simulate motion strength
                if (detectedMotion > MotionThreshold)
                {
                    OnMotionDetected?.Invoke($"ALERT: Motion detected above threshold! Detected motion: {detectedMotion:F2}");
                }
                else
                {
                    OnMotionDetected?.Invoke($"Motion detected: {detectedMotion:F2}");
                }

                OnFrequencyChange?.Invoke(detectedMotion);
            }
        }

    }

}
