using System;
using System.IO;

namespace WinFormsApp5
{
    public class LightControl
    {
        // Attributes
        private int brightnessLevel;
        private bool isOn;
        private bool energySavingMode;
        private string dataFilePath;

        // Properties for retrieving current states
        public int BrightnessLevel => brightnessLevel;
        public bool IsOn => isOn;
        public bool EnergySavingMode => energySavingMode;

        // Constructors
        public LightControl()
        {
            // Default initialization
            brightnessLevel = 100;
            isOn = false;
            energySavingMode = false;
        }

        public LightControl(string filename)
        {
            dataFilePath = filename;
            LoadSettingsFromFile();
        }

        // Method to turn the light on
        public void TurnOn()
        {
            isOn = true;
            UpdateHMI();
        }

        // Method to turn the light off
        public void TurnOff()
        {
            isOn = false;
            UpdateHMI();
        }

        // Method to set brightness with validation
        public void SetBrightness(int level)
        {
            if (energySavingMode && level > 50)
            {
                brightnessLevel = 50; // Cap brightness in energy-saving mode
            }
            else
            {
                brightnessLevel = Math.Clamp(level, 0, 100);
            }
            UpdateHMI();
        }

        // Method to enable energy-saving mode
        public void EnableEnergySavingMode()
        {
            energySavingMode = true;
            if (brightnessLevel > 50)
            {
                brightnessLevel = 50; // Cap brightness level when energy-saving is enabled
            }
            UpdateHMI();
        }

        // Method to disable energy-saving mode
        public void DisableEnergySavingMode()
        {
            energySavingMode = false;
            UpdateHMI();
        }

        // Method to update settings based on HMI inputs
        public void UpdateFromHMI(int brightness, bool status)
        {
            SetBrightness(brightness);
            isOn = status;
            UpdateHMI();
        }

        // Method to send current settings to the HMI
        private void UpdateHMI()
        {
            // Simulate real-time update to HMI
            Console.WriteLine("HMI Update -> Brightness: {0}, On: {1}, Energy Saving: {2}",
                brightnessLevel, isOn, energySavingMode);
        }

        // Load settings from a configuration file
        private void LoadSettingsFromFile()
        {
            if (File.Exists(dataFilePath))
            {
                try
                {
                    var lines = File.ReadAllLines(dataFilePath);
                    foreach (var line in lines)
                    {
                        var setting = line.Split('=');
                        if (setting.Length == 2)
                        {
                            var key = setting[0].Trim();
                            var value = setting[1].Trim();
                            if (key == "brightnessLevel" && int.TryParse(value, out int brightness))
                            {
                                brightnessLevel = Math.Clamp(brightness, 0, 100);
                            }
                            else if (key == "isOn" && bool.TryParse(value, out bool onState))
                            {
                                isOn = onState;
                            }
                            else if (key == "energySavingMode" && bool.TryParse(value, out bool energyMode))
                            {
                                energySavingMode = energyMode;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading settings: " + ex.Message);
                    SetDefaultSettings();
                }
            }
            else
            {
                Console.WriteLine("Configuration file not found. Using default settings.");
                SetDefaultSettings();
            }
        }

        // Set default values for settings
        private void SetDefaultSettings()
        {
            brightnessLevel = 100;
            isOn = false;
            energySavingMode = false;
        }
    }
}
