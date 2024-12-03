using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp5;


namespace WinFormsApp5
{
    public partial class LightModuleForm : Form
    {
        private readonly LightController _lightController;

        public LightModuleForm()
        {
            InitializeComponent();

            // Initialize the LightController
            _lightController = new LightController();

            // Subscribe to controller events
            _lightController.OnStatusChange += UpdateStatusLabel;
            _lightController.OnBrightnessChange += UpdateBrightnessDisplay;
            _lightController.OnColorChange += UpdateLightPreview;
        }

        private void LightModuleForm_Load(object sender, EventArgs e)
        {
            /*// Initialize the UI state
            UpdateStatusLabel("Light is OFF | Power Saving: OFF");
            brightnessSlider.Value = 100; // Default brightness
            brightnessLabel.Text = "Brightness: 100%";
            EnableControls(false); // Initially disable controls*/
        }

        /*private void onButton_Click(object sender, EventArgs e)
        {
            _lightController.TurnOn();
            EnableControls(true);
            UpdateStatusLabel("Light is ON | Power Saving: OFF");
        }

        private void offButton_Click(object sender, EventArgs e)
        {
            _lightController.TurnOff();
            EnableControls(false);
            UpdateStatusLabel("Light is OFF | Power Saving: OFF");
        }*/

        private void brightnessSlider_Scroll(object sender, EventArgs e)
        {
            _lightController.SetBrightness(brightnessSlider.Value);

            NotificationManager.AddNotification($"Brightness set to {brightnessSlider.Value}%.");

        }

        private void colorPickerButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    _lightController.SetColor(colorDialog.Color);

                    NotificationManager.AddNotification($"Light color changed to {colorDialog.Color.Name}.");

                }
            }
        }

        private void energySavingButton_Click(object sender, EventArgs e)
        {
            _lightController.EnableEnergySavingMode();

            // Update the brightness slider to reflect 50%
            brightnessSlider.Value = 50;

            // Add alert for energy saving mode
            NotificationManager.AddNotification("Energy Saving mode enabled."); // This goes to notifications
            NotificationManager.AddAlert("ALERT: Energy Saving mode is now ON."); // This goes to the alert box
        }

        private void EnableControls(bool enabled)
        {
            brightnessSlider.Enabled = enabled;
            colorPickerButton.Enabled = enabled;
            energySavingButton.Enabled = enabled;
        }

        private void UpdateStatusLabel(string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => statusLabel.Text = status));
            }
            else
            {
                statusLabel.Text = status;
            }
        }

        private void UpdateBrightnessDisplay(int brightness)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => brightnessLabel.Text = $"Brightness: {brightness}%"));
            }
            else
            {
                brightnessLabel.Text = $"Brightness: {brightness}%";
            }
        }

        private void UpdateLightPreview(Color color)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => lightPreviewPanel.BackColor = color));
            }
            else
            {
                lightPreviewPanel.BackColor = color;
            }
        }

        private void LightModuleForm_Load_1(object sender, EventArgs e)
        {

        }

        private void onButton_Click(object sender, EventArgs e)
        {
            _lightController.TurnOn();
            EnableControls(true);
            UpdateStatusLabel("Light is ON | Power Saving: OFF");

            NotificationManager.AddNotification("Light turned ON.");
        }
        /* private void onButton_Click(object sender, EventArgs e)
         {
             _lightController.TurnOn();
             EnableControls(true);
             UpdateStatusLabel("Light is ON | Power Saving: OFF");

             NotificationManager.AddNotification("Light turned ON.");

             // Update the SCADA interface
             mainForm.UpdateDeviceStatus();
         }*/

        private void offButton_Click(object sender, EventArgs e)
        {
           _lightController.TurnOff();
            EnableControls(false);
            UpdateStatusLabel("Light is OFF | Power Saving: OFF");

            NotificationManager.AddNotification("Light turned OFF.");
        }


    }
}
