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
            _motionSensor.OnFrequencyChange += UpdateFrequencyDisplay;
            _motionSensor.OnMotionDetected += ShowAlert;
            _motionSensor.OnStatusUpdated += UpdateStatusLabel;
        }

        private void MotionSensorForm_Load(object sender, EventArgs e)
        {
            _motionSensor.EnableMotionDetection();
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
        }

        private void buttonDisable_Click(object sender, EventArgs e)
        {
            _motionSensor.DisableMotionDetection();
        }

        private void buttonFakeMotion_Click(object sender, EventArgs e)
        {
            _motionSensor.TriggerFakeMotion();
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
        }

        private void ShowAlert(string alertMessage)
        {
            MessageBox.Show(alertMessage, "Motion Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }
    }
}
