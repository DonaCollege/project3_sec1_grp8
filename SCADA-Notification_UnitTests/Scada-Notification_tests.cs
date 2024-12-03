using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsApp5;  // Namespace of the SCADAinterface class
using System.Collections.Generic;

namespace SCADANotificationTests
{
    [TestClass]
    public class SCADAInterfaceTests
    {
        private SCADAinterface scadaInterface;

        [TestInitialize]
        public void TestInitialize()
        {
            // Initialize the SCADAinterface object.
            scadaInterface = new SCADAinterface();
        }

        [TestMethod]
        public void SCADA_TC1_AuthenticateUser_ValidCredentials_ReturnsTrue()
        {
            // Valid credentials should return true
            var result = scadaInterface.AuthenticateUser("admin", "password123");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SCADA_TC1_AuthenticateUser_InvalidCredentials_ReturnsFalse()
        {
            // Invalid credentials should return false
            var result = scadaInterface.AuthenticateUser("wrongUser", "wrongPass");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SCADA_TC2_UpdateDeviceStatus_ValidStatus_UpdatesCorrectly()
        {
            // Test if device status updates correctly.
            var deviceStatus = new Dictionary<string, string>
            {
                { "Lights", "On" },
                { "Temperature", "22°C" }
            };

            scadaInterface.UpdateDeviceStatus(deviceStatus);

            var status = scadaInterface.GetDeviceStatus();

            // Validate the updated device status
            Assert.AreEqual("On", status["Lights"]);
            Assert.AreEqual("22°C", status["Temperature"]);
        }

        [TestMethod]
        public void SCADA_TC3_GenerateCommandFeedback_ValidCommand_ReturnsExpectedFeedback()
        {
            // Test if valid command returns correct feedback.
            var feedback = scadaInterface.GenerateCommandFeedback("Turn on lights");
            Assert.AreEqual("Lights turned on.", feedback);
        }

        [TestMethod]
        public void SCADA_TC3_GenerateCommandFeedback_InvalidCommand_ReturnsErrorFeedback()
        {
            // Test if invalid command returns error feedback.
            var feedback = scadaInterface.GenerateCommandFeedback("Invalid Command");
            Assert.AreEqual("Invalid command.", feedback);
        }

        [TestMethod]
        public void SCADA_TC4_AcceptUserCredentials_ValidCredentials_ReturnsTrue()
        {
            // Test if user credentials are accepted properly
            var result = scadaInterface.AcceptUserCredentials("admin", "password");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SCADA_TC4_AcceptUserCredentials_InvalidCredentials_ReturnsFalse()
        {
            // Test if invalid credentials return false
            var result = scadaInterface.AcceptUserCredentials("wrongUser", "wrongPass");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SCADA_TC5_ReceiveAlertData_DisplaysAlertCorrectly()
        {
            // Test if the alert data is displayed correctly
            string alertMessage = "Fire detected in Room 101";
            scadaInterface.ReceiveAlertData(alertMessage);
            // We can't directly assert Console output here, but you could mock DisplayAlert for testing
            // Or check that the alert is being passed along properly within the class
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Clean up resources or reset state if needed after each test
        }
    }

    [TestClass]
    public class NotificationSystemTests
    {
        private NotificationSystem notificationSystem;

        [TestInitialize]
        public void TestInitialize()
        {
            // Initialize the NotificationSystem object before each test.
            notificationSystem = new NotificationSystem();
        }

        [TestMethod]
        public void NS_TC1_GenerateAlert_ExceedsThreshold_AlertGenerated()
        {
            // Test if alert is generated when the sensor value exceeds the threshold.
            double sensorValue = 35.0; // Greater than the "Temperature" threshold (30.0)
            string sensorType = "Temperature";

            // This should generate an alert.
            notificationSystem.GenerateAlert(sensorType, sensorValue);

            // Retrieve the alert history to check if it was logged.
            var alertHistory = notificationSystem.GetAlertHistory();
            Assert.AreEqual(1, alertHistory.Count);
            Assert.IsTrue(alertHistory[0].Contains("Temperature alert!"));
            Assert.IsTrue(alertHistory[0].Contains("exceeded threshold"));
        }

        [TestMethod]
        public void NS_TC1_GenerateAlert_BelowThreshold_NoAlertGenerated()
        {
            // Test if no alert is generated when the sensor value is below the threshold.
            double sensorValue = 25.0; // Less than the "Temperature" threshold (30.0)
            string sensorType = "Temperature";

            // This should not generate an alert.
            notificationSystem.GenerateAlert(sensorType, sensorValue);

            // Retrieve the alert history to check if no alert was logged.
            var alertHistory = notificationSystem.GetAlertHistory();
            Assert.AreEqual(0, alertHistory.Count);
        }

        [TestMethod]
        public void NS_TC2_ReceiveSensorData_AlertsGeneratedForMultipleSensors()
        {
            // Test if multiple sensors trigger alerts based on the sensor data provided.
            var sensorData = new Dictionary<string, double>
            {
                { "Temperature", 32.0 },  // Exceeds the threshold for Temperature
                { "Motion", 2.0 }         // Exceeds the threshold for Motion
            };

            notificationSystem.ReceiveSensorData(sensorData);

            var alertHistory = notificationSystem.GetAlertHistory();
            Assert.AreEqual(2, alertHistory.Count);
            Assert.IsTrue(alertHistory[0].Contains("Temperature alert!"));
            Assert.IsTrue(alertHistory[1].Contains("Motion alert!"));
        }

        [TestMethod]
        public void NS_TC3_SetAlertThresholds_CustomThresholds_AreApplied()
        {
            // Test if custom alert thresholds are set and applied correctly.
            var customThresholds = new Dictionary<string, double>
            {
                { "Temperature", 40.0 },
                { "Motion", 5.0 }
            };

            notificationSystem.SetAlertThresholds(customThresholds);

            // Check if the thresholds have been updated.
            var sensorData = new Dictionary<string, double>
            {
                { "Temperature", 45.0 },
                { "Motion", 3.0 }
            };

            notificationSystem.ReceiveSensorData(sensorData);

            var alertHistory = notificationSystem.GetAlertHistory();
            Assert.AreEqual(1, alertHistory.Count); // Only one alert should be logged (Temperature)
            Assert.IsTrue(alertHistory[0].Contains("Temperature alert!"));
        }

        [TestMethod]
        public void NS_TC4_GenerateAlertNotification_ExceedsThreshold_ReturnsAlertMessage()
        {
            // Test if GenerateAlertNotification returns the correct alert message.
            double sensorValue = 45.0; // Greater than the "Temperature" threshold (30.0)
            string sensorType = "Temperature";

            string alertMessage = notificationSystem.GenerateAlertNotification(sensorType, sensorValue);

            Assert.IsNotNull(alertMessage);
            Assert.IsTrue(alertMessage.Contains("Temperature alert!"));
            Assert.IsTrue(alertMessage.Contains("exceeded threshold"));
        }

        [TestMethod]
        public void NS_TC4_GenerateAlertNotification_BelowThreshold_ReturnsNull()
        {
            // Test if GenerateAlertNotification returns null when the sensor value is below the threshold.
            double sensorValue = 25.0; // Less than the "Temperature" threshold (30.0)
            string sensorType = "Temperature";

            string alertMessage = notificationSystem.GenerateAlertNotification(sensorType, sensorValue);

            Assert.IsNull(alertMessage);
        }

        [TestMethod]
        public void NS_TC5_SaveAlertHistory_AlertHistorySavedToFile()
        {
            // Test if the alert history is saved to a file when the object is disposed (or the alert history is saved).
            // We'll simulate this by directly calling SaveAlertHistory from the class.

            // Generate some alerts to save.
            notificationSystem.GenerateAlert("Temperature", 32.0);
            notificationSystem.GenerateAlert("Motion", 2.0);

            // Save alert history
            notificationSystem.SaveAlertHistory();  // Assuming SaveAlertHistory is public or made accessible for test

            // Verify that the file exists and contains the expected data.
            string filePath = "AlertHistory.txt";
            Assert.IsTrue(File.Exists(filePath));

            var lines = File.ReadAllLines(filePath);
            Assert.IsTrue(lines.Length > 0);
            Assert.IsTrue(lines[0].Contains("Temperature alert!"));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Clean up any test files after each test (for example, remove "AlertHistory.txt").
            string filePath = "AlertHistory.txt";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
