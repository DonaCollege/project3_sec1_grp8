namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create an instance of the LightModuleForm
            LightModuleForm lightModuleForm = new LightModuleForm();

            // Show the Light Module form as a modal dialog
            lightModuleForm.ShowDialog();

            // If you want the form to be non-modal (independent), use lightModuleForm.Show() instead
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // Create an instance of the SmartLockForm
            SmartLockForm smartLockForm = new SmartLockForm();

            // Show the SmartLockForm as a modal dialog
            smartLockForm.ShowDialog(); // Use Show() if you prefer a non-modal window
        }


        private void button7_Click(object sender, EventArgs e)
        {
            // Create an instance of the TemperatureSensorForm
            TemperatureSensorForm tempSensorForm = new TemperatureSensorForm();

            // Show the Temperature Sensor Form as a modal dialog
            tempSensorForm.ShowDialog();  // Or use Show() if non-modal behavior is desired
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Create an instance of the MotionSensorForm
            MotionSensorForm motionSensorForm = new MotionSensorForm();

            // Show the Motion Sensor Form
            motionSensorForm.ShowDialog(); // Use ShowDialog for a modal form or Show for a non-modal form
        }
    }
}
