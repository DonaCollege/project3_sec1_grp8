using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WinFormsApp5.Tests
{
    [TestClass]
    public class MotionSensorTests
    {
        [TestMethod]
        public void MotionSensor_Constructor_ValidSensitivity()
        {
            var sensor = new MotionSensor(6.0);
            Assert.IsNotNull(sensor); // Ensures the object is created
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MotionSensor_Constructor_InvalidSensitivity_ThrowsException()
        {
            new MotionSensor(3.0); // Below valid range
        }

        [TestMethod]
        public void MotionSensor_EnableMotionDetection_UpdatesState()
        {
            var sensor = new MotionSensor();
            bool eventTriggered = false;

            sensor.OnStatusUpdated += (status) =>
            {
                if (status == "Motion detection enabled.") eventTriggered = true;
            };

            sensor.EnableMotionDetection();
            Assert.IsTrue(eventTriggered); // Verify that the correct event was triggered
        }

        [TestMethod]
        public void MotionSensor_DisableMotionDetection_UpdatesState()
        {
            var sensor = new MotionSensor();
            bool eventTriggered = false;

            sensor.OnStatusUpdated += (status) =>
            {
                if (status == "Motion detection disabled.") eventTriggered = true;
            };

            sensor.EnableMotionDetection(); // Enable first to test disable
            sensor.DisableMotionDetection();
            Assert.IsTrue(eventTriggered); // Verify that the correct event was triggered
        }

        [TestMethod]
        public void MotionSensor_SetSensitivity_ValidValue()
        {
            var sensor = new MotionSensor();
            bool eventTriggered = false;

            sensor.OnStatusUpdated += (status) =>
            {
                if (status == "Sensitivity updated to 8.0.") eventTriggered = true;
            };

            sensor.SetSensitivity(8.0);
            Assert.IsTrue(eventTriggered); // Verify that the correct event was triggered
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MotionSensor_SetSensitivity_InvalidValue_ThrowsException()
        {
            var sensor = new MotionSensor();
            sensor.SetSensitivity(11.0); // Above valid range
        }

        [TestMethod]
        public void MotionSensor_TriggerFakeMotion_WhenEnabled_TriggersEvent()
        {
            var sensor = new MotionSensor();
            sensor.EnableMotionDetection(); // Enable motion detection
            bool motionDetected = false;

            sensor.OnMotionDetected += (message) =>
            {
                if (message.Contains("Fake Motion Triggered")) motionDetected = true;
            };

            sensor.TriggerFakeMotion();
            Assert.IsTrue(motionDetected); // Verify that the fake motion event was triggered
        }

        [TestMethod]
        public void MotionSensor_TriggerFakeMotion_WhenDisabled_NoEffect()
        {
            var sensor = new MotionSensor();
            string statusMessage = string.Empty;

            sensor.OnStatusUpdated += (message) =>
            {
                statusMessage = message;
            };

            sensor.TriggerFakeMotion();
            Assert.AreEqual("Enable motion detection to simulate motion.", statusMessage);
        }

        [TestMethod]
        public void MotionSensor_MonitorMotion_FrequencyWithinRange()
        {
            var sensor = new MotionSensor();
            double frequency = 0;

            sensor.OnFrequencyChange += (currentFrequency) =>
            {
                frequency = currentFrequency;
            };

            sensor.EnableMotionDetection();

            // Simulate a timer tick
            var monitorMotionMethod = sensor.GetType().GetMethod("MonitorMotion", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            monitorMotionMethod?.Invoke(sensor, new object[] { null, null });

            Assert.IsTrue(frequency >= 1.0 && frequency <= 3.0);
        }

        [TestMethod]
        public void MotionSensor_InitialSensitivity_DefaultValue()
        {
            // Arrange & Act
            var sensor = new MotionSensor();

            // Assert
            var sensitivity = sensor.GetType().GetField("_sensitivityThreshold", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(sensor);
            Assert.AreEqual(5.0, sensitivity); // Default sensitivity is 5.0
        }

        [TestMethod]
        public void MotionSensor_DisableWhileTimerRunning_StopsTimer()
        {
            // Arrange
            var sensor = new MotionSensor();
            var timerField = sensor.GetType().GetField("_monitoringTimer", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var timer = (System.Timers.Timer)timerField?.GetValue(sensor);

            // Act
            sensor.EnableMotionDetection();
            sensor.DisableMotionDetection();

            // Assert
            Assert.IsFalse(timer?.Enabled); // Ensure timer is stopped
        }

        [TestMethod]
        public void MotionSensor_EnableWhileAlreadyEnabled_NoDuplicateTimerStart()
        {
            // Arrange
            var sensor = new MotionSensor();
            var timerField = sensor.GetType().GetField("_monitoringTimer", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var timer = (System.Timers.Timer)timerField?.GetValue(sensor);

            // Act
            sensor.EnableMotionDetection();
            var initialState = timer?.Enabled;
            sensor.EnableMotionDetection();
            var newState = timer?.Enabled;

            // Assert
            Assert.IsTrue(initialState); // Timer should already be running
            Assert.IsTrue(newState);    // Timer should remain running without errors
        }

        [TestMethod]
        public void MotionSensor_MultipleSubscribers_EventHandling()
        {
            // Arrange
            var sensor = new MotionSensor();
            int statusUpdates = 0;

            sensor.OnStatusUpdated += (status) => statusUpdates++;
            sensor.OnStatusUpdated += (status) => statusUpdates++;

            // Act
            sensor.EnableMotionDetection();

            // Assert
            Assert.AreEqual(2, statusUpdates); // Both subscribers should be called
        }

        [TestMethod]
        public void MotionSensor_FrequencyChangeEvent_TriggersMultipleTimes()
        {
            // Arrange
            var sensor = new MotionSensor();
            int frequencyChanges = 0;

            sensor.OnFrequencyChange += (frequency) => frequencyChanges++;
            sensor.EnableMotionDetection();

            // Act
            var monitorMotionMethod = sensor.GetType().GetMethod("MonitorMotion", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            monitorMotionMethod?.Invoke(sensor, new object[] { null, null }); // Simulate one tick
            monitorMotionMethod?.Invoke(sensor, new object[] { null, null }); // Simulate another tick

            // Assert
            Assert.AreEqual(2, frequencyChanges); // Ensure the frequency event triggers twice
        }

        [TestMethod]
        public void MotionSensor_TriggerFakeMotion_MotionDetectedEventRaised()
        {
            // Arrange
            var sensor = new MotionSensor(6.0);
            sensor.EnableMotionDetection();
            string detectedMotionMessage = "";

            sensor.OnMotionDetected += (message) => detectedMotionMessage = message;

            // Act
            sensor.TriggerFakeMotion();

            // Assert
            Assert.IsTrue(detectedMotionMessage.Contains("Fake Motion Triggered!"));
            Assert.IsTrue(detectedMotionMessage.Contains("Frequency: 8.00")); // Threshold 6 + 2.0 fake spike
        }

        [TestMethod]
        public void MotionSensor_DisableMidFakeMotion_StopDetection()
        {
            // Arrange
            var sensor = new MotionSensor();
            bool motionDetected = false;

            sensor.OnMotionDetected += (message) => motionDetected = true;

            // Act
            sensor.EnableMotionDetection();
            sensor.DisableMotionDetection();
            sensor.TriggerFakeMotion();

            // Assert
            Assert.IsFalse(motionDetected); // Motion should not be detected after disabling
        }

        [TestMethod]
        public void MotionSensor_InvalidFrequencyRange_DoesNotTriggerEvent()
        {
            // Arrange
            var sensor = new MotionSensor();
            bool frequencyTriggered = false;

            sensor.OnFrequencyChange += (frequency) =>
            {
                if (frequency < 1.0 || frequency > 3.0)
                {
                    frequencyTriggered = true;
                }
            };

            // Act
            var monitorMotionMethod = sensor.GetType().GetMethod("MonitorMotion", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            monitorMotionMethod?.Invoke(sensor, new object[] { null, null }); // Simulate one tick

            // Assert
            Assert.IsFalse(frequencyTriggered); // Frequency should always be in the valid range
        }
    }
}

namespace WinFormsApp5.Tests
{
    [TestClass]
    public class TemperatureSensorTests
    {
        [TestMethod]
        public void TemperatureSensor_Constructor_ValidThresholds()
        {
            var sensor = new TemperatureSensor(18, 24);
            Assert.IsNotNull(sensor); // Ensures the object is created
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TemperatureSensor_Constructor_InvalidThresholds_ThrowsException()
        {
            new TemperatureSensor(14, 36); // Outside valid range
        }

        [TestMethod]
        public void TemperatureSensor_SetThresholds_ValidValue()
        {
            var sensor = new TemperatureSensor(18, 24);
            sensor.SetThresholds(20, 30); // Update thresholds

            var minThresholdField = sensor.GetType().GetField("_minThreshold", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var maxThresholdField = sensor.GetType().GetField("_maxThreshold", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var minThreshold = (double)minThresholdField.GetValue(sensor);
            var maxThreshold = (double)maxThresholdField.GetValue(sensor);

            Assert.AreEqual(20, minThreshold, "Min threshold was not set correctly.");
            Assert.AreEqual(30, maxThreshold, "Max threshold was not set correctly.");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TemperatureSensor_SetThresholds_InvalidThresholds_ThrowsException()
        {
            var sensor = new TemperatureSensor(18, 24);
            sensor.SetThresholds(10, 40); // Invalid thresholds
        }

        [TestMethod]
        public void TemperatureSensor_SetTargetTemperature_ValidValue()
        {
            var sensor = new TemperatureSensor(18, 24);
            sensor.SetTargetTemperature(22);

            var targetTemperature = sensor.GetType().GetField("_targetTemperature", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(sensor);
            Assert.AreEqual(22.0, targetTemperature);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TemperatureSensor_SetTargetTemperature_InvalidValue_ThrowsException()
        {
            var sensor = new TemperatureSensor(18, 24);
            sensor.SetTargetTemperature(30); // Outside thresholds
        }

        [TestMethod]
        public void TemperatureSensor_StartMonitoring_TriggersTemperatureChangeEvent()
        {
            var sensor = new TemperatureSensor(18, 24);
            bool temperatureChangeEventTriggered = false;

            sensor.OnTemperatureChange += (temp) => temperatureChangeEventTriggered = true;
            sensor.StartMonitoring();

            System.Threading.Thread.Sleep(1500); // Allow the timer to run
            sensor.StopMonitoring();

            Assert.IsTrue(temperatureChangeEventTriggered, "OnTemperatureChange event was not triggered.");
        }
      


        [TestMethod]
        public void TemperatureSensor_AdjustsTemperatureGraduallyToTarget()
        {
            var sensor = new TemperatureSensor(18, 24);
            double initialTemperature = 18;
            double targetTemperature = 22;

            sensor.SetTargetTemperature(targetTemperature);

            sensor.StartMonitoring();
            System.Threading.Thread.Sleep(3000); // Allow the temperature to adjust
            sensor.StopMonitoring();

            var currentTemperature = (double)sensor.GetType().GetField("_currentTemperature", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(sensor);

            Assert.IsTrue(currentTemperature > initialTemperature, "Temperature did not increase towards the target.");
            Assert.IsTrue(currentTemperature <= targetTemperature, "Temperature exceeded the target.");
        }

        [TestMethod]
        public void TemperatureSensor_TemperatureStaysWithinThresholds()
        {
            var sensor = new TemperatureSensor(18, 24);
            bool temperatureChangeEventTriggered = false;

            sensor.OnTemperatureChange += (temp) =>
            {
                Assert.IsTrue(temp >= 18, "Temperature is below the minimum threshold.");
                Assert.IsTrue(temp <= 24, "Temperature is above the maximum threshold.");
                temperatureChangeEventTriggered = true;
            };

            sensor.StartMonitoring();
            System.Threading.Thread.Sleep(2000); // Allow monitoring to run
            sensor.StopMonitoring();

            Assert.IsTrue(temperatureChangeEventTriggered, "OnTemperatureChange event was not triggered.");
        }

        [TestMethod]
        public void TemperatureSensor_StopMonitoring_DisablesTemperatureChange()
        {
            var sensor = new TemperatureSensor(18, 24);
            bool temperatureChangeEventTriggered = false;

            sensor.OnTemperatureChange += (temp) => temperatureChangeEventTriggered = true;

            sensor.StartMonitoring();
            System.Threading.Thread.Sleep(1500); // Allow the timer to trigger once
            sensor.StopMonitoring();

            temperatureChangeEventTriggered = false; // Reset flag
            System.Threading.Thread.Sleep(1500); // Allow time to check no further triggers

            Assert.IsFalse(temperatureChangeEventTriggered, "OnTemperatureChange event was triggered after stopping monitoring.");
        }


        [TestMethod]
        public void TemperatureSensor_NoBreachEvent_WhenTemperatureWithinRange()
        {
            var sensor = new TemperatureSensor(18, 24);
            bool breachEventTriggered = false;

            sensor.OnThresholdBreach += (message) =>
            {
                breachEventTriggered = true;
            };

            sensor.SetTargetTemperature(20); // Within range
            sensor.StartMonitoring();

            System.Threading.Thread.Sleep(2000); // Allow time for monitoring
            sensor.StopMonitoring();

            Assert.IsFalse(breachEventTriggered, "Threshold breach event triggered incorrectly.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TemperatureSensor_InvalidThresholds_ThrowsException()
        {
            new TemperatureSensor(10, 40); // Outside valid range (15-35)
        }


    }
}


