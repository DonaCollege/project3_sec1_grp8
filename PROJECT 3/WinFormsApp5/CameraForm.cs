using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class CameraForm : Form
    {
        private Camera camera; // Declare camera as a class-level variable

        public CameraForm()
        {
            InitializeComponent();

            // Initialize the camera with default settings, including sensitivity
            camera = new Camera(new Dictionary<string, object>
        {
            { "motionSensitivity", 50 } // Set a default sensitivity value
        }
            );
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(CameraForm));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            ((ISupportInitialize)pictureBox1).BeginInit();
            ((ISupportInitialize)pictureBox2).BeginInit();
            ((ISupportInitialize)pictureBox3).BeginInit();
            ((ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(192, 255, 255);
            button1.Location = new Point(67, 160);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Change Senstivity";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(192, 255, 255);
            button2.Location = new Point(273, 160);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "Check";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(192, 255, 255);
            button3.Cursor = Cursors.IBeam;
            button3.Location = new Point(67, 330);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 2;
            button3.Text = "Check";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(192, 255, 255);
            button4.Cursor = Cursors.IBeam;
            button4.Location = new Point(273, 330);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 3;
            button4.Text = "Check";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(54, 41);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 113);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(262, 41);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(125, 113);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(54, 211);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(125, 113);
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(262, 211);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(125, 113);
            pictureBox4.TabIndex = 7;
            pictureBox4.TabStop = false;
            // 
            // CameraForm
            // 
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(563, 394);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "CameraForm";
            Load += CameraForm_Load;
            ((ISupportInitialize)pictureBox1).EndInit();
            ((ISupportInitialize)pictureBox2).EndInit();
            ((ISupportInitialize)pictureBox3).EndInit();
            ((ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
        }

        private void CameraForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Show a message with Yes and No buttons
            DialogResult result = MessageBox.Show("Congrats!! Successfully connected to the notification system. \nDo you want to close the window?",
                                                  "Notification Connected",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Information);

            // Check if the user clicked "Yes"
            if (result == DialogResult.Yes)
            {
                this.Close(); // Close the form if "Yes" is clicked
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Prompt user for new sensitivity value
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter new sensitivity:",
                                                                      "Set Sensitivity",
                                                                      camera.MotionSensitivity.ToString());

            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int newSensitivity))
            {
                // Update sensitivity in Camera instance
                camera.AdjustSensitivity(newSensitivity);

                // Confirm new sensitivity setting
                MessageBox.Show($"New sensitivity has been set to {newSensitivity}. Thanks!",
                                "Sensitivity Updated",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a numeric sensitivity value.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private Button button1;
        private Button button3;
        private Button button4;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Button button2;

        private void button3_Click(object sender, EventArgs e)
        {
            {
                // Show a message with Yes and No buttons
                DialogResult result = MessageBox.Show("Congrats!! Successfully connected to the Motion sensor.\n Do you want to close the window?",
                                                      "Notification Connected",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Information);

                // Check if the user clicked "Yes"
                if (result == DialogResult.Yes)
                {
                    this.Close(); // Close the form if "Yes" is clicked
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Fetch the camera status
            var statusReport = camera.GetStatusReport();

            // Display the camera status in a message box
            string message = $"1. Status: {statusReport["Status"]}\n" +
                             $"2. Current Sensitivity Level: {statusReport["Sensitivity Level"]}\n" +
                             $"3. Alerts: {statusReport["Alerts"]}";

            MessageBox.Show(message, "Camera Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
