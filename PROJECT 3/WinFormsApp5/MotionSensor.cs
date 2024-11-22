using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.IO;




//using System;
//using System.Timers; // Ensure System.Timers namespace is included

/*namespace WinFormsApp5
{
    public class MotionSensor
    {
        private double _currentFrequency;
        private double _sensitivityThreshold;
        private bool _isMotionDetectionEnabled;
        private readonly System.Timers.Timer _monitoringTimer; // Explicitly specify System.Timers.Timer
        private readonly Random _random;

        public event Action<double> OnFrequencyChange;
        public event Action<string> OnMotionDetected;
        public event Action<string> OnStatusUpdated;

        public MotionSensor(double initialSensitivity = 5.0)
        {
            if (initialSensitivity < 1 || initialSensitivity > 10)
                throw new ArgumentException("Sensitivity must be between 1 and 10.");

            _sensitivityThreshold = initialSensitivity;
            _isMotionDetectionEnabled = false;
            _currentFrequency = 1.0;

            // Explicitly use System.Timers.Timer
            _monitoringTimer = new System.Timers.Timer(500); // Update every 500ms
            _monitoringTimer.Elapsed += MonitorMotion;

            _random = new Random();
        }

        public void EnableMotionDetection()
        {
            _isMotionDetectionEnabled = true;
            _monitoringTimer.Start();
            UpdateStatus("Motion detection enabled.");
        }

        public void DisableMotionDetection()
        {
            _isMotionDetectionEnabled = false;
            _monitoringTimer.Stop();
            UpdateStatus("Motion detection disabled.");
        }

        public void SetSensitivity(double sensitivity)
        {
            if (sensitivity < 1 || sensitivity > 10)
                throw new ArgumentException("Sensitivity must be between 1 and 10.");
            _sensitivityThreshold = sensitivity;
            UpdateStatus($"Sensitivity updated to {sensitivity:F1}.");
        }

        private void MonitorMotion(object sender, ElapsedEventArgs e)
        {
            if (!_isMotionDetectionEnabled)
                return;

            // Simulate steady frequency changes
            _currentFrequency = 1 + (_random.NextDouble() * 2); // Random value between 1 and 3
            OnFrequencyChange?.Invoke(_currentFrequency);
        }

        public void TriggerFakeMotion()
        {
            if (!_isMotionDetectionEnabled)
            {
                OnStatusUpdated?.Invoke("Enable motion detection to simulate motion.");
                return;
            }

            // Simulate fake motion spike
            _currentFrequency = _sensitivityThreshold + 2.0; // Exceeds threshold
            OnFrequencyChange?.Invoke(_currentFrequency);

            string fakeMotionMessage = $"Fake Motion Triggered! Frequency: {_currentFrequency:F2}, Threshold: {_sensitivityThreshold:F2}";
            OnMotionDetected?.Invoke(fakeMotionMessage);

            // Gradually return to normal frequency
            _currentFrequency = 1.5;
        }

        private void UpdateStatus(string status)
        {
            OnStatusUpdated?.Invoke(status);
        }
    }
}
*/


using System;
using System.Timers; // Explicitly use System.Timers

namespace WinFormsApp5
{
    public class MotionSensor
    {
        private double _currentFrequency;
        private double _sensitivityThreshold;
        private bool _isMotionDetectionEnabled;
        private readonly System.Timers.Timer _monitoringTimer; // Explicitly use System.Timers.Timer
        private readonly Random _random;

        public event Action<double> OnFrequencyChange;
        public event Action<string> OnMotionDetected;
        public event Action<string> OnStatusUpdated;

        public MotionSensor(double initialSensitivity = 5.0)
        {
            if (initialSensitivity < 4 || initialSensitivity > 10)
                throw new ArgumentException("Sensitivity must be between 4 and 10.");

            _sensitivityThreshold = initialSensitivity;
            _isMotionDetectionEnabled = false;
            _currentFrequency = 1.0;

            _monitoringTimer = new System.Timers.Timer(500); // Update every 500ms
            _monitoringTimer.Elapsed += MonitorMotion;

            _random = new Random();
        }

        public void EnableMotionDetection()
        {
            _isMotionDetectionEnabled = true;
            _monitoringTimer.Start();
            UpdateStatus("Motion detection enabled.");
        }

        public void DisableMotionDetection()
        {
            _isMotionDetectionEnabled = false;
            _monitoringTimer.Stop();
            UpdateStatus("Motion detection disabled.");
        }

        public void SetSensitivity(double sensitivity)
        {
            if (sensitivity < 4 || sensitivity > 10)
                throw new ArgumentException("Sensitivity must be between 4 and 10.");
            _sensitivityThreshold = sensitivity;
            UpdateStatus($"Sensitivity updated to {sensitivity:F1}.");
        }

        private void MonitorMotion(object sender, ElapsedEventArgs e)
        {
            if (!_isMotionDetectionEnabled)
                return;

            // Simulate steady frequency changes
            _currentFrequency = 1 + (_random.NextDouble() * 2); // Random value between 1 and 3
            OnFrequencyChange?.Invoke(_currentFrequency);
        }

        public void TriggerFakeMotion()
        {
            if (!_isMotionDetectionEnabled)
            {
                OnStatusUpdated?.Invoke("Enable motion detection to simulate motion.");
                return;
            }

            // Simulate fake motion spike
            _currentFrequency = _sensitivityThreshold + 2.0; // Exceeds threshold
            OnFrequencyChange?.Invoke(_currentFrequency);

            string fakeMotionMessage = $"Fake Motion Triggered! Frequency: {_currentFrequency:F2}, Threshold: {_sensitivityThreshold:F2}";
            OnMotionDetected?.Invoke(fakeMotionMessage);

            // Gradually return to normal frequency
            _currentFrequency = 1.5;
        }

        private void UpdateStatus(string status)
        {
            OnStatusUpdated?.Invoke(status);
        }
    }
}

