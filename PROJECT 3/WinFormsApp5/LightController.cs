using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Drawing;

namespace WinFormsApp5
{
    public class LightController
    {
        public bool IsOn { get; private set; }
        public int Brightness { get; private set; } // Brightness level (0 to 100)
        public Color LightColor { get; private set; } // Original color of the light
        public bool IsEnergySavingMode { get; private set; }

        public event Action<string> OnStatusChange;
        public event Action<Color> OnColorChange;
        public event Action<int> OnBrightnessChange;

        public LightController()
        {
            IsOn = false;
            Brightness = 100; // Default brightness is 100%
            LightColor = Color.White; // Default color is white
            IsEnergySavingMode = false;
        }

        public void TurnOn()
        {
            IsOn = true;
            OnStatusChange?.Invoke("Light is ON");
            EmitAdjustedColor();
        }

        public void TurnOff()
        {
            IsOn = false;
            OnStatusChange?.Invoke("Light is OFF");
            EmitAdjustedColor(); // Reset the preview color to black/off
        }

        public void SetBrightness(int level)
        {
            if (level < 0 || level > 100)
                throw new ArgumentException("Brightness must be between 0 and 100.");

            Brightness = level;
            IsEnergySavingMode = false; // Disable energy-saving mode if brightness changes
            OnBrightnessChange?.Invoke(Brightness);
            EmitAdjustedColor();
        }

        public void SetColor(Color color)
        {
            LightColor = color;
            EmitAdjustedColor();
        }

        public void EnableEnergySavingMode()
        {
            IsEnergySavingMode = true;
            SetBrightness(50); // Set brightness to 50%
            OnStatusChange?.Invoke("Energy-saving mode enabled.");
        }

        private void EmitAdjustedColor()
        {
            if (!IsOn)
            {
                // If the light is off, set the preview to black
                OnColorChange?.Invoke(Color.Black);
                return;
            }

            // Adjust the color intensity based on the brightness level
            int adjustedRed = (int)(LightColor.R * (Brightness / 100.0));
            int adjustedGreen = (int)(LightColor.G * (Brightness / 100.0));
            int adjustedBlue = (int)(LightColor.B * (Brightness / 100.0));

            Color adjustedColor = Color.FromArgb(adjustedRed, adjustedGreen, adjustedBlue);
            OnColorChange?.Invoke(adjustedColor);
        }
    }
}
