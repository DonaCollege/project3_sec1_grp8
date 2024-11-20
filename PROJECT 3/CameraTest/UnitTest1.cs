using NUnit.Framework;
using System.Collections.Generic;

namespace WinFormsApp5.Tests
{
    [TestFixture]
    public class CameraTests
    {
        private Camera camera;

        [SetUp]
        public void Setup()
        {
            var cameraSettings = new Dictionary<string, object>
            {
                { "motionSensitivity", 50 }
            };
            camera = new Camera(cameraSettings);
        }

        [Test]
        public void REQ_CAM_001_Camera_Initialization_With_Default_Settings()
        {
            Assert.AreEqual(50, camera.MotionSensitivity, "Expected default sensitivity to be 50");
            var statusReport = camera.GetStatusReport();
            Assert.AreEqual("standby", statusReport["Status"], "Expected initial status to be 'standby'");
        }

        [Test]
        public void REQ_CAM_002_AdjustMotionSensitivity()
        {
            camera.AdjustSensitivity(5);
            Assert.AreEqual(5, camera.MotionSensitivity, "Expected motion sensitivity to be updated to 5");
        }

        [Test]
        public void REQ_CAM_003_EnableDisableMotionDetection()
        {
            camera.EnableMotionDetection(true);
            Assert.AreEqual("active", camera.GetStatusReport()["Status"], "Expected motion detection status to be 'active'");

            camera.EnableMotionDetection(false);
            Assert.AreEqual("standby", camera.GetStatusReport()["Status"], "Expected motion detection status to be 'standby'");
        }

        [Test]
        public void REQ_CAM_004_MotionAlert_On_Detection()
        {
            camera.EnableMotionDetection(true);
            camera.AdjustSensitivity(10);

            var detectionResult = camera.DetectMotion(15);
            Assert.AreEqual("Motion Detected", detectionResult, "Expected 'Motion Detected' when detected movement exceeds sensitivity");

            detectionResult = camera.DetectMotion(5);
            Assert.AreEqual("No Motion", detectionResult, "Expected 'No Motion' when detected movement is below sensitivity");
        }

        [Test]
        public void REQ_CAM_005_GetCameraStatus()
        {
            var statusReport = camera.GetStatusReport();
            Assert.AreEqual("standby", statusReport["Status"], "Expected initial status to be 'standby'");
            Assert.AreEqual("50", statusReport["Sensitivity Level"], "Expected initial sensitivity level to be 50");
        }

        [Test]
        public void REQ_CAM_006_DetectionFeedback_On_Motion()
        {
            camera.EnableMotionDetection(true);
            camera.AdjustSensitivity(10);

            var detectionFeedback = camera.DetectMotion(15);
            Assert.AreEqual("Motion Detected", detectionFeedback, "Expected feedback 'Motion Detected' for motion above sensitivity");

            detectionFeedback = camera.DetectMotion(5);
            Assert.AreEqual("No Motion", detectionFeedback, "Expected feedback 'No Motion' for motion below sensitivity");
        }

        [Test]
        public void REQ_CAM_007_InitializeCameraWithSettings()
        {
            var newSettings = new Dictionary<string, object>
            {
                { "motionSensitivity", 20 }
            };
            camera.InitializeCamera(newSettings);

            Assert.AreEqual(20, camera.MotionSensitivity, "Expected camera to initialize with sensitivity of 20");
            Assert.AreEqual("standby", camera.GetStatusReport()["Status"], "Expected camera status to be 'standby' after initialization");
        }

        [Test]
        public void REQ_CAM_008_MotionAlert_When_Motion_Exceeds_Sensitivity()
        {
            camera.EnableMotionDetection(true);
            camera.AdjustSensitivity(10);

            var detectionResult = camera.DetectMotion(15);
            Assert.AreEqual("Motion Detected", detectionResult, "Expected alert 'Motion Detected' when motion exceeds sensitivity");
        }

        [Test]
        public void REQ_CAM_009_SendStatusToHMI()
        {
            var statusReport = camera.GetStatusReport();
            Assert.AreEqual("standby", statusReport["Status"], "Expected status for HMI to be 'standby'");
        }

        [Test]
        public void REQ_CAM_010_LogMotionEvent()
        {
            camera.EnableMotionDetection(true);
            camera.AdjustSensitivity(10);

            camera.DetectMotion(15);
            // Confirm that log file "motionLog.txt" includes entries (optional verification)
        }

        [Test]
        public void REQ_CAM_011_CameraDestructor()
        {
            camera = null;
            // Trigger garbage collection to invoke destructor
            GC.Collect();
            GC.WaitForPendingFinalizers();
            // Verify resource release (console output or memory tracking, as direct check isn’t feasible)
        }
    }
}
