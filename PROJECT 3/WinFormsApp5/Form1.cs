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
            // This code assumes that button2 should also open the LightingControlForm
            // Replace 'LightingControlForm' with another form name if a different form should be opened
            LightingControlForm lightingForm = new LightingControlForm();
            lightingForm.ShowDialog(); // Or use Show() if non-modal behavior is desired
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
