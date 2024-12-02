using System;
using System.Timers;

namespace WinFormsApp5
{
    public class TemperatureSensor
    {
        private readonly System.Timers.Timer _monitoringTimer;
        private double _currentTemperature;
        private double _minThreshold;
        private double _maxThreshold;
        private double _targetTemperature;

        public event Action<double> OnTemperatureChange;
        public event Action<string> OnThresholdBreach;

        private const int MinAllowedTemperature = 15;
        private const int MaxAllowedTemperature = 35;

        public TemperatureSensor(double minThreshold, double maxThreshold)
        {
            if (minThreshold < MinAllowedTemperature || maxThreshold > MaxAllowedTemperature || minThreshold >= maxThreshold)
            {
                throw new ArgumentException("Thresholds must be between 15 and 35, and min must be less than max.");
            }

            _minThreshold = minThreshold;
            _maxThreshold = maxThreshold;
            _targetTemperature = (_minThreshold + _maxThreshold) / 2; // Set initial target temperature to midpoint
            _currentTemperature = _targetTemperature;

            _monitoringTimer = new System.Timers.Timer(1000); // Check every 1 second
            _monitoringTimer.Elapsed += MonitorTemperature;
        }

        public void StartMonitoring()
        {
            _monitoringTimer.Start();
        }

        public void StopMonitoring()
        {
            _monitoringTimer.Stop();
        }

        public void SetThresholds(double min, double max)
        {
            if (min < MinAllowedTemperature || max > MaxAllowedTemperature || min >= max)
            {
                throw new ArgumentException("Thresholds must be between 15 and 35, and min must be less than max.");
            }

            _minThreshold = min;
            _maxThreshold = max;
        }

        public void SetTargetTemperature(double target)
        {
            if (target < _minThreshold || target > _maxThreshold)
            {
                throw new ArgumentException($"Target temperature must be between {_minThreshold}°C and {_maxThreshold}°C.");
            }

            _targetTemperature = target;
        }

        private void MonitorTemperature(object sender, ElapsedEventArgs e)
        {
            if (_currentTemperature < _targetTemperature)
                _currentTemperature += 0.2; // Gradually increase
            else if (_currentTemperature > _targetTemperature)
                _currentTemperature -= 0.2; // Gradually decrease

            OnTemperatureChange?.Invoke(_currentTemperature);

            // Check if current temperature is out of bounds
            if (_currentTemperature < _minThreshold || _currentTemperature > _maxThreshold)
            {
                string message = $"Temperature out of range! Current: {_currentTemperature:F2}°C (Min: {_minThreshold}°C, Max: {_maxThreshold}°C)";
                OnThresholdBreach?.Invoke(message);
            }
        }
    }
}
