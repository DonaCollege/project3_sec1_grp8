using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(CameraForm));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            imageList1 = new ImageList(components);
            imageList2 = new ImageList(components);
            pictureBox1 = new PictureBox();
            this.pictureBox2 = new PictureBox();
            this.pictureBox3 = new PictureBox();
            this.pictureBox4 = new PictureBox();
            ((ISupportInitialize)pictureBox1).BeginInit();
            ((ISupportInitialize)this.pictureBox2).BeginInit();
            ((ISupportInitialize)this.pictureBox3).BeginInit();
            ((ISupportInitialize)this.pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(192, 255, 255);
            button1.Location = new Point(105, 160);
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
            button2.Location = new Point(353, 160);
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
            button3.Location = new Point(105, 339);
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
            button4.Location = new Point(353, 339);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 3;
            button4.Text = "Check";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // imageList2
            // 
            imageList2.ColorDepth = ColorDepth.Depth32Bit;
            imageList2.ImageSize = new Size(16, 16);
            imageList2.TransparentColor = Color.Transparent;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(80, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(140, 117);
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            this.pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox2.Location = new Point(339, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(138, 114);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            this.pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox3.Location = new Point(80, 210);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new Size(140, 114);
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            this.pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox4.Location = new Point(339, 210);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new Size(138, 114);
            this.pictureBox4.TabIndex = 17;
            this.pictureBox4.TabStop = false;
            // 
            // CameraForm
            // 
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(563, 394);
            Controls.Add(this.pictureBox4);
            Controls.Add(this.pictureBox3);
            Controls.Add(this.pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "CameraForm";
            Load += CameraForm_Load;
            ((ISupportInitialize)pictureBox1).EndInit();
            ((ISupportInitialize)this.pictureBox2).EndInit();
            ((ISupportInitialize)this.pictureBox3).EndInit();
            ((ISupportInitialize)this.pictureBox4).EndInit();
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
            // Prompt the user for new sensitivity
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter new sensitivity:",
                "Set Sensitivity",
                camera.MotionSensitivity.ToString());

            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int newSensitivity))
            {
                camera.AdjustSensitivity(newSensitivity);

                // Log the change in the notification box
                NotificationManager.AddNotification($"Camera sensitivity changed to {newSensitivity}.");

                // Check if the new sensitivity exceeds the threshold
                const int sensitivityThreshold = 80;
                if (newSensitivity > sensitivityThreshold)
                {
                    NotificationManager.AddAlert($"ALERT: Camera sensitivity exceeded threshold! Current: {newSensitivity}.");
                }

                // Confirm the change to the user
                MessageBox.Show($"New sensitivity has been set to {newSensitivity}.",
                    "Sensitivity Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Handle invalid input
                MessageBox.Show("Invalid input. Please enter a numeric sensitivity value.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private Button button1;
        private Button button3;
        private Button button4;
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
            string message = "sensitivity control";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void SensitivityControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
