public class Camera
{
    private Dictionary<string, object> cameraSettings;
    private int motionSensitivity;
    private string cameraStatus;
    private bool motionDetectionEnabled;
    private string logFilePath = "motionLog.txt";

    public int MotionSensitivity // Property to expose current sensitivity
    {
        get => motionSensitivity;
        set
        {
            motionSensitivity = value;
            Console.WriteLine($"Motion sensitivity updated to {motionSensitivity}.");
        }
    }

    public Camera(Dictionary<string, object> cameraSettings)
    {
        InitializeCamera(cameraSettings);
        cameraStatus = "standby";
    }

    ~Camera()
    {
        SaveLogs();
        ReleaseResources();
    }

    public void InitializeCamera(Dictionary<string, object> settings)
    {
        cameraSettings = settings;
        MotionSensitivity = Convert.ToInt32(cameraSettings["motionSensitivity"]);
        cameraStatus = "standby";
        Console.WriteLine("Camera initialized with default settings.");
    }

    public void EnableMotionDetection(bool enable)
    {
        motionDetectionEnabled = enable;
        cameraStatus = enable ? "active" : "standby";
    }

    public void AdjustSensitivity(int level)
    {
        MotionSensitivity = level; // Adjust sensitivity dynamically
    }

    public string DetectMotion(int detectedMovement)
    {
        if (motionDetectionEnabled && detectedMovement >= MotionSensitivity)
        {
            GenerateAlert();
            LogMotionEvent("Motion Detected");
            return "Motion Detected";
        }
        else
        {
            LogMotionEvent("No Motion");
            return "No Motion";
        }
    }

    private void GenerateAlert()
    {
        Console.WriteLine("Alert: Motion Detected!");
    }

    public Dictionary<string, string> GetStatusReport()
    {
        return new Dictionary<string, string>
        {
            { "Status", cameraStatus },
            { "Sensitivity Level", MotionSensitivity.ToString() },
            { "Alerts", "No warnings at this stage" }
        };
    }

    private void LogMotionEvent(string eventData)
    {
        using (StreamWriter sw = new StreamWriter(logFilePath, true))
        {
            sw.WriteLine($"{DateTime.Now}: {eventData}");
        }
    }

    private void SaveLogs()
    {
        Console.WriteLine("Saving logs...");
    }

    private void ReleaseResources()
    {
        Console.WriteLine("Releasing resources...");
    }
}
