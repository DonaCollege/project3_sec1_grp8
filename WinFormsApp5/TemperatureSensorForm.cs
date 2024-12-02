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
    public partial class TemperatureSensorForm : Form
    {
        private TemperatureSensor _sensor;

        public TemperatureSensorForm()
        {
            InitializeComponent();
        }

        private void TemperatureSensorForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialize the sensor with default thresholds
                _sensor = new TemperatureSensor(18, 24);
                _sensor.OnTemperatureChange += UpdateTemperatureDisplay;
                _sensor.OnThresholdBreach += HandleThresholdBreach;
                _sensor.StartMonitoring();

                NotificationManager.AddNotification("Temperature sensor monitoring started.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTemperatureDisplay(double temperature)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateTemperatureDisplay(temperature)));
            }
            else
            {
                labelTemperature.Text = $"Current Temperature: {temperature:F2}°C";
                NotificationManager.AddNotification($"Temperature updated to {temperature:F2}°C.");
            }
        }

        private void HandleThresholdBreach(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => HandleThresholdBreach(message)));
            }
            else
            {
                MessageBox.Show(message, "Temperature Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NotificationManager.AddAlert(message);
            }
        }

        private void buttonSetThresholds_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.TryParse(textBoxMinThreshold.Text, out double min) &&
                    double.TryParse(textBoxMaxThreshold.Text, out double max))
                {
                    _sensor.SetThresholds(min, max);
                    MessageBox.Show("Thresholds updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationManager.AddNotification($"Temperature thresholds set to Min: {min}°C, Max: {max}°C.");
                }
                else
                {
                    throw new ArgumentException("Please enter valid numeric values for thresholds.");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSetTargetTemperature_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.TryParse(textBoxTargetTemperature.Text, out double target))
                {
                    _sensor.SetTargetTemperature(target);
                    MessageBox.Show("Target temperature set successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotificationManager.AddNotification($"Target temperature set to {target}°C.");
                }
                else
                {
                    throw new ArgumentException("Please enter a valid numeric value for the target temperature.");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TemperatureSensorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sensor.StopMonitoring();
            NotificationManager.AddNotification("Temperature sensor monitoring stopped.");
        }
    }
}

