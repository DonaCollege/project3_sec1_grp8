namespace WinFormsApp5
{
    partial class TemperatureSensorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.TextBox textBoxMinThreshold;
        private System.Windows.Forms.TextBox textBoxMaxThreshold;
        private System.Windows.Forms.TextBox textBoxTargetTemperature;
        private System.Windows.Forms.Button buttonSetThresholds;
        private System.Windows.Forms.Button buttonSetTargetTemperature;

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
            labelTemperature = new Label();
            textBoxMinThreshold = new TextBox();
            textBoxMaxThreshold = new TextBox();
            textBoxTargetTemperature = new TextBox();
            buttonSetThresholds = new Button();
            buttonSetTargetTemperature = new Button();
            SuspendLayout();
            // 
            // labelTemperature
            // 
            labelTemperature.Font = new Font("Arial", 18F, FontStyle.Bold);
            labelTemperature.Location = new Point(80, 40);
            labelTemperature.Name = "labelTemperature";
            labelTemperature.Size = new Size(600, 40);
            labelTemperature.TabIndex = 0;
            labelTemperature.Text = "Current Temperature: --°C";
            // 
            // textBoxMinThreshold
            // 
            textBoxMinThreshold.Font = new Font("Arial", 12F);
            textBoxMinThreshold.Location = new Point(80, 100);
            textBoxMinThreshold.Name = "textBoxMinThreshold";
            textBoxMinThreshold.Size = new Size(200, 30);
            textBoxMinThreshold.TabIndex = 1;
            // 
            // textBoxMaxThreshold
            // 
            textBoxMaxThreshold.Font = new Font("Arial", 12F);
            textBoxMaxThreshold.Location = new Point(320, 100);
            textBoxMaxThreshold.Name = "textBoxMaxThreshold";
            textBoxMaxThreshold.Size = new Size(200, 30);
            textBoxMaxThreshold.TabIndex = 2;
            // 
            // textBoxTargetTemperature
            // 
            textBoxTargetTemperature.Font = new Font("Arial", 12F);
            textBoxTargetTemperature.Location = new Point(80, 160);
            textBoxTargetTemperature.Name = "textBoxTargetTemperature";
            textBoxTargetTemperature.Size = new Size(200, 30);
            textBoxTargetTemperature.TabIndex = 3;
            // 
            // buttonSetThresholds
            // 
            buttonSetThresholds.Font = new Font("Arial", 12F, FontStyle.Bold);
            buttonSetThresholds.Location = new Point(80, 220);
            buttonSetThresholds.Name = "buttonSetThresholds";
            buttonSetThresholds.Size = new Size(200, 50);
            buttonSetThresholds.TabIndex = 4;
            buttonSetThresholds.Text = "Set Thresholds";
            buttonSetThresholds.Click += buttonSetThresholds_Click;
            // 
            // buttonSetTargetTemperature
            // 
            buttonSetTargetTemperature.Font = new Font("Arial", 12F, FontStyle.Bold);
            buttonSetTargetTemperature.Location = new Point(320, 160);
            buttonSetTargetTemperature.Name = "buttonSetTargetTemperature";
            buttonSetTargetTemperature.Size = new Size(200, 50);
            buttonSetTargetTemperature.TabIndex = 5;
            buttonSetTargetTemperature.Text = "Set Target Temp";
            buttonSetTargetTemperature.Click += buttonSetTargetTemperature_Click;
            // 
            // TemperatureSensorForm
            // 
            BackColor = Color.LightGray;
            BackgroundImage = Properties.Resources.temp_module;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 400);
            Controls.Add(labelTemperature);
            Controls.Add(textBoxMinThreshold);
            Controls.Add(textBoxMaxThreshold);
            Controls.Add(textBoxTargetTemperature);
            Controls.Add(buttonSetThresholds);
            Controls.Add(buttonSetTargetTemperature);
            Name = "TemperatureSensorForm";
            Text = "Temperature Sensor";
            FormClosing += TemperatureSensorForm_FormClosing;
            Load += TemperatureSensorForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

