/*namespace WinFormsApp5
{
    partial class MotionSensorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelFrequency;
        private System.Windows.Forms.TextBox textBoxSensitivity;
        private System.Windows.Forms.Button buttonSetSensitivity;
        private System.Windows.Forms.Button buttonEnable;
        private System.Windows.Forms.Button buttonDisable;
        private System.Windows.Forms.Button buttonFakeMotion;
        private System.Windows.Forms.GroupBox groupBoxControls;
        private System.Windows.Forms.GroupBox groupBoxStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelStatus = new Label();
            labelFrequency = new Label();
            textBoxSensitivity = new TextBox();
            buttonSetSensitivity = new Button();
            buttonEnable = new Button();
            buttonDisable = new Button();
            buttonFakeMotion = new Button();
            groupBoxControls = new GroupBox();
            groupBoxStatus = new GroupBox();
            groupBoxControls.SuspendLayout();
            groupBoxStatus.SuspendLayout();
            SuspendLayout();
            // 
            // labelStatus
            // 
            labelStatus.Font = new Font("Arial", 14F, FontStyle.Bold);
            labelStatus.ForeColor = Color.Lime;
            labelStatus.Location = new Point(30, 30);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(700, 30);
            labelStatus.TabIndex = 0;
            labelStatus.Text = "Status: Ready";
            // 
            // labelFrequency
            // 
            labelFrequency.Font = new Font("Arial", 14F, FontStyle.Bold);
            labelFrequency.ForeColor = Color.White;
            labelFrequency.Location = new Point(30, 70);
            labelFrequency.Name = "labelFrequency";
            labelFrequency.Size = new Size(700, 30);
            labelFrequency.TabIndex = 1;
            labelFrequency.Text = "Current Frequency: 0.00";
           // labelFrequency.Click += labelFrequency_Click;
            // 
            // textBoxSensitivity
            // 
            textBoxSensitivity.BackColor = Color.Black;
            textBoxSensitivity.Font = new Font("Arial", 12F);
            textBoxSensitivity.ForeColor = Color.Lime;
            textBoxSensitivity.Location = new Point(30, 40);
            textBoxSensitivity.Name = "textBoxSensitivity";
            textBoxSensitivity.Size = new Size(150, 30);
            textBoxSensitivity.TabIndex = 0;
            // 
            // buttonSetSensitivity
            // 
            buttonSetSensitivity.BackColor = Color.Lime;
            buttonSetSensitivity.Font = new Font("Arial", 12F, FontStyle.Bold);
            buttonSetSensitivity.ForeColor = Color.Black;
            buttonSetSensitivity.Location = new Point(200, 40);
            buttonSetSensitivity.Name = "buttonSetSensitivity";
            buttonSetSensitivity.Size = new Size(150, 40);
            buttonSetSensitivity.TabIndex = 1;
            buttonSetSensitivity.Text = "Set Sensitivity";
            buttonSetSensitivity.UseVisualStyleBackColor = false;
            buttonSetSensitivity.Click += buttonSetSensitivity_Click;
            // 
            // buttonEnable
            // 
            buttonEnable.BackColor = Color.Lime;
            buttonEnable.Font = new Font("Arial", 12F, FontStyle.Bold);
            buttonEnable.ForeColor = Color.Black;
            buttonEnable.Location = new Point(30, 100);
            buttonEnable.Name = "buttonEnable";
            buttonEnable.Size = new Size(150, 40);
            buttonEnable.TabIndex = 2;
            buttonEnable.Text = "Enable";
            buttonEnable.UseVisualStyleBackColor = false;
            buttonEnable.Click += buttonEnable_Click;
            // 
            // buttonDisable
            // 
            buttonDisable.BackColor = Color.OrangeRed;
            buttonDisable.Font = new Font("Arial", 12F, FontStyle.Bold);
            buttonDisable.ForeColor = Color.Black;
            buttonDisable.Location = new Point(200, 100);
            buttonDisable.Name = "buttonDisable";
            buttonDisable.Size = new Size(150, 40);
            buttonDisable.TabIndex = 3;
            buttonDisable.Text = "Disable";
            buttonDisable.UseVisualStyleBackColor = false;
            buttonDisable.Click += buttonDisable_Click;
            // 
            // buttonFakeMotion
            // 
            buttonFakeMotion.BackColor = Color.Red;
            buttonFakeMotion.Font = new Font("Arial", 12F, FontStyle.Bold);
            buttonFakeMotion.ForeColor = Color.Black;
            buttonFakeMotion.Location = new Point(380, 70);
            buttonFakeMotion.Name = "buttonFakeMotion";
            buttonFakeMotion.Size = new Size(200, 50);
            buttonFakeMotion.TabIndex = 4;
            buttonFakeMotion.Text = "Fake Motion";
            buttonFakeMotion.UseVisualStyleBackColor = false;
            buttonFakeMotion.Click += buttonFakeMotion_Click;
            // 
            // groupBoxControls
            // 
            groupBoxControls.BackColor = Color.Transparent;
            groupBoxControls.Controls.Add(textBoxSensitivity);
            groupBoxControls.Controls.Add(buttonSetSensitivity);
            groupBoxControls.Controls.Add(buttonEnable);
            groupBoxControls.Controls.Add(buttonDisable);
            groupBoxControls.Controls.Add(buttonFakeMotion);
            groupBoxControls.Font = new Font("Arial", 12F, FontStyle.Bold);
            groupBoxControls.ForeColor = Color.White;
            groupBoxControls.Location = new Point(20, 140);
            groupBoxControls.Name = "groupBoxControls";
            groupBoxControls.Size = new Size(750, 200);
            groupBoxControls.TabIndex = 1;
            groupBoxControls.TabStop = false;
            groupBoxControls.Text = "Controls";
            // 
            // groupBoxStatus
            // 
            groupBoxStatus.BackColor = Color.Transparent;
            groupBoxStatus.Controls.Add(labelStatus);
            groupBoxStatus.Controls.Add(labelFrequency);
            groupBoxStatus.Font = new Font("Arial", 12F, FontStyle.Bold);
            groupBoxStatus.ForeColor = Color.White;
            groupBoxStatus.Location = new Point(20, 20);
            groupBoxStatus.Name = "groupBoxStatus";
            groupBoxStatus.Size = new Size(750, 100);
            groupBoxStatus.TabIndex = 0;
            groupBoxStatus.TabStop = false;
            groupBoxStatus.Text = "Sensor Status";
            // 
            // MotionSensorForm
            // 
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.motion_sensor;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 400);
            Controls.Add(groupBoxStatus);
            Controls.Add(groupBoxControls);
            Name = "MotionSensorForm";
            Text = "Motion Sensor";
            Load += MotionSensorForm_Load;
            groupBoxControls.ResumeLayout(false);
            groupBoxControls.PerformLayout();
            groupBoxStatus.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
*/

#nullable enable
namespace WinFormsApp5
{
    partial class MotionSensorForm
    {
        private System.ComponentModel.IContainer? components = null;
        private System.Windows.Forms.Label? labelStatus;
        private System.Windows.Forms.Label? labelFrequency;
        private System.Windows.Forms.TextBox? textBoxSensitivity;
        private System.Windows.Forms.Button? buttonSetSensitivity;
        private System.Windows.Forms.Button? buttonEnable;
        private System.Windows.Forms.Button? buttonDisable;
        private System.Windows.Forms.Button? buttonFakeMotion;
        private System.Windows.Forms.GroupBox? groupBoxControls;
        private System.Windows.Forms.GroupBox? groupBoxStatus;

        /// <summary>
        /// Exposes controls for testing.
        /// </summary>
        public Label LabelStatus => labelStatus!;
        public Label LabelFrequency => labelFrequency!;
        public TextBox TextBoxSensitivity => textBoxSensitivity!;
        public Button ButtonSetSensitivity => buttonSetSensitivity!;
        public Button ButtonEnable => buttonEnable!;
        public Button ButtonDisable => buttonDisable!;
        public Button ButtonFakeMotion => buttonFakeMotion!;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelStatus = new Label();
            labelFrequency = new Label();
            textBoxSensitivity = new TextBox();
            buttonSetSensitivity = new Button();
            buttonEnable = new Button();
            buttonDisable = new Button();
            buttonFakeMotion = new Button();
            groupBoxControls = new GroupBox();
            groupBoxStatus = new GroupBox();
            groupBoxControls.SuspendLayout();
            groupBoxStatus.SuspendLayout();
            SuspendLayout();

            // 
            // labelStatus
            // 
            labelStatus.Font = new Font("Arial", 14F, FontStyle.Bold);
            labelStatus.ForeColor = Color.Lime;
            labelStatus.Location = new Point(30, 30);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(700, 30);
            labelStatus.TabIndex = 0;
            labelStatus.Text = "Status: Ready";

            // 
            // labelFrequency
            // 
            labelFrequency.Font = new Font("Arial", 14F, FontStyle.Bold);
            labelFrequency.ForeColor = Color.White;
            labelFrequency.Location = new Point(30, 70);
            labelFrequency.Name = "labelFrequency";
            labelFrequency.Size = new Size(700, 30);
            labelFrequency.TabIndex = 1;
            labelFrequency.Text = "Current Frequency: 0.00";

            // 
            // textBoxSensitivity
            // 
            textBoxSensitivity.BackColor = Color.Black;
            textBoxSensitivity.Font = new Font("Arial", 12F);
            textBoxSensitivity.ForeColor = Color.Lime;
            textBoxSensitivity.Location = new Point(30, 40);
            textBoxSensitivity.Name = "textBoxSensitivity";
            textBoxSensitivity.Size = new Size(150, 30);
            textBoxSensitivity.TabIndex = 0;

            // 
            // buttonSetSensitivity
            // 
            buttonSetSensitivity.BackColor = Color.Lime;
            buttonSetSensitivity.Font = new Font("Arial", 12F, FontStyle.Bold);
            buttonSetSensitivity.ForeColor = Color.Black;
            buttonSetSensitivity.Location = new Point(200, 40);
            buttonSetSensitivity.Name = "buttonSetSensitivity";
            buttonSetSensitivity.Size = new Size(150, 40);
            buttonSetSensitivity.TabIndex = 1;
            buttonSetSensitivity.Text = "Set Sensitivity";
            buttonSetSensitivity.UseVisualStyleBackColor = false;
            buttonSetSensitivity.Click += buttonSetSensitivity_Click;

            // 
            // buttonEnable
            // 
            buttonEnable.BackColor = Color.Lime;
            buttonEnable.Font = new Font("Arial", 12F, FontStyle.Bold);
            buttonEnable.ForeColor = Color.Black;
            buttonEnable.Location = new Point(30, 100);
            buttonEnable.Name = "buttonEnable";
            buttonEnable.Size = new Size(150, 40);
            buttonEnable.TabIndex = 2;
            buttonEnable.Text = "Enable";
            buttonEnable.UseVisualStyleBackColor = false;
            buttonEnable.Click += buttonEnable_Click;

            // 
            // buttonDisable
            // 
            buttonDisable.BackColor = Color.OrangeRed;
            buttonDisable.Font = new Font("Arial", 12F, FontStyle.Bold);
            buttonDisable.ForeColor = Color.Black;
            buttonDisable.Location = new Point(200, 100);
            buttonDisable.Name = "buttonDisable";
            buttonDisable.Size = new Size(150, 40);
            buttonDisable.TabIndex = 3;
            buttonDisable.Text = "Disable";
            buttonDisable.UseVisualStyleBackColor = false;
            buttonDisable.Click += buttonDisable_Click;

            // 
            // buttonFakeMotion
            // 
            buttonFakeMotion.BackColor = Color.Red;
            buttonFakeMotion.Font = new Font("Arial", 12F, FontStyle.Bold);
            buttonFakeMotion.ForeColor = Color.Black;
            buttonFakeMotion.Location = new Point(380, 70);
            buttonFakeMotion.Name = "buttonFakeMotion";
            buttonFakeMotion.Size = new Size(200, 50);
            buttonFakeMotion.TabIndex = 4;
            buttonFakeMotion.Text = "Fake Motion";
            buttonFakeMotion.UseVisualStyleBackColor = false;
            buttonFakeMotion.Click += buttonFakeMotion_Click;

            // 
            // groupBoxControls
            // 
            groupBoxControls.BackColor = Color.Transparent;
            groupBoxControls.Controls.Add(textBoxSensitivity);
            groupBoxControls.Controls.Add(buttonSetSensitivity);
            groupBoxControls.Controls.Add(buttonEnable);
            groupBoxControls.Controls.Add(buttonDisable);
            groupBoxControls.Controls.Add(buttonFakeMotion);
            groupBoxControls.Font = new Font("Arial", 12F, FontStyle.Bold);
            groupBoxControls.ForeColor = Color.White;
            groupBoxControls.Location = new Point(20, 140);
            groupBoxControls.Name = "groupBoxControls";
            groupBoxControls.Size = new Size(750, 200);
            groupBoxControls.TabIndex = 1;
            groupBoxControls.TabStop = false;
            groupBoxControls.Text = "Controls";

            // 
            // groupBoxStatus
            // 
            groupBoxStatus.BackColor = Color.Transparent;
            groupBoxStatus.Controls.Add(labelStatus);
            groupBoxStatus.Controls.Add(labelFrequency);
            groupBoxStatus.Font = new Font("Arial", 12F, FontStyle.Bold);
            groupBoxStatus.ForeColor = Color.White;
            groupBoxStatus.Location = new Point(20, 20);
            groupBoxStatus.Name = "groupBoxStatus";
            groupBoxStatus.Size = new Size(750, 100);
            groupBoxStatus.TabIndex = 0;
            groupBoxStatus.TabStop = false;
            groupBoxStatus.Text = "Sensor Status";

            // 
            // MotionSensorForm
            // 
            BackColor = Color.Black;
            BackgroundImage = Properties.Resources.motion_sensor;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 400);
            Controls.Add(groupBoxStatus);
            Controls.Add(groupBoxControls);
            Name = "MotionSensorForm";
            Text = "Motion Sensor";
            Load += MotionSensorForm_Load;
            groupBoxControls.ResumeLayout(false);
            groupBoxControls.PerformLayout();
            groupBoxStatus.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
#nullable disable
