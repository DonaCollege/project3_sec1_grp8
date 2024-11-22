using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*using System;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class TemperatureSensorForm : Form
    {
        private TemperatureSensor _sensor;

        public TemperatureSensorForm()
        {
            InitializeComponent();
            _sensor = new TemperatureSensor(18, 24); // Set realistic initial thresholds (e.g., 18°C to 24°C)
        }

        private void TemperatureSensorForm_Load(object sender, EventArgs e)
        {
            _sensor.OnTemperatureChange += UpdateTemperatureDisplay;
            _sensor.OnThresholdBreach += ShowThresholdAlert;
            _sensor.StartMonitoring();
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
            }
        }

        private void ShowThresholdAlert(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ShowThresholdAlert(message)));
            }
            else
            {
                MessageBox.Show(message, "Temperature Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonSetThresholds_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxMinThreshold.Text, out double min) &&
                double.TryParse(textBoxMaxThreshold.Text, out double max))
            {
                _sensor.SetThresholds(min, max);
                MessageBox.Show("Thresholds updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values for thresholds.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSetTargetTemperature_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxTargetTemperature.Text, out double target))
            {
                _sensor.SetTargetTemperature(target);
                MessageBox.Show("Target temperature set successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter a valid temperature.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TemperatureSensorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sensor.StopMonitoring();
        }

        private void labelTemperature_Click(object sender, EventArgs e)
        {

        }

        private void textBoxMaxThreshold_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTargetTemperature_TextChanged(object sender, EventArgs e)
        {

        }
    }
}





*/

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
                _sensor.OnThresholdBreach += ShowThresholdAlert;
                _sensor.StartMonitoring();
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
            }
        }

        private void ShowThresholdAlert(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ShowThresholdAlert(message)));
            }
            else
            {
                MessageBox.Show(message, "Temperature Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }
    }
}

