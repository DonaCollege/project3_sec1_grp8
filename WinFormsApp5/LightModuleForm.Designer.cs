namespace WinFormsApp5
{
    partial class LightModuleForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TrackBar brightnessSlider;
        private System.Windows.Forms.Label brightnessLabel;
        private System.Windows.Forms.Button onButton;
        private System.Windows.Forms.Button offButton;
        private System.Windows.Forms.Button colorPickerButton;
        private System.Windows.Forms.Button energySavingButton;
        private System.Windows.Forms.Panel lightPreviewPanel;
        private System.Windows.Forms.GroupBox controlGroupBox;
        private System.Windows.Forms.GroupBox previewGroupBox;

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
            statusLabel = new Label();
            brightnessSlider = new TrackBar();
            brightnessLabel = new Label();
            onButton = new Button();
            offButton = new Button();
            colorPickerButton = new Button();
            energySavingButton = new Button();
            lightPreviewPanel = new Panel();
            controlGroupBox = new GroupBox();
            previewGroupBox = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)brightnessSlider).BeginInit();
            controlGroupBox.SuspendLayout();
            previewGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // statusLabel
            // 
            statusLabel.Location = new Point(0, 0);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(100, 23);
            statusLabel.TabIndex = 0;
            // 
            // brightnessSlider
            // 
            brightnessSlider.Location = new Point(30, 100);
            brightnessSlider.Maximum = 100;
            brightnessSlider.Name = "brightnessSlider";
            brightnessSlider.Size = new Size(700, 56);
            brightnessSlider.TabIndex = 4;
            brightnessSlider.TickFrequency = 10;
            brightnessSlider.Value = 100;
            brightnessSlider.Scroll += brightnessSlider_Scroll;
            // 
            // brightnessLabel
            // 
            brightnessLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            brightnessLabel.Location = new Point(30, 160);
            brightnessLabel.Name = "brightnessLabel";
            brightnessLabel.Size = new Size(700, 30);
            brightnessLabel.TabIndex = 5;
            brightnessLabel.Text = "Brightness: 100%";
            // 
            // onButton
            // 
            onButton.BackColor = Color.LightGreen;
            onButton.Font = new Font("Arial", 10F, FontStyle.Bold);
            onButton.Location = new Point(30, 40);
            onButton.Name = "onButton";
            onButton.Size = new Size(100, 40);
            onButton.TabIndex = 0;
            onButton.Text = "Turn ON";
            onButton.UseVisualStyleBackColor = false;
            onButton.Click += onButton_Click;
            // 
            // offButton
            // 
            offButton.BackColor = Color.Salmon;
            offButton.Font = new Font("Arial", 10F, FontStyle.Bold);
            offButton.Location = new Point(150, 40);
            offButton.Name = "offButton";
            offButton.Size = new Size(100, 40);
            offButton.TabIndex = 1;
            offButton.Text = "Turn OFF";
            offButton.UseVisualStyleBackColor = false;
            offButton.Click += offButton_Click;
            // 
            // colorPickerButton
            // 
            colorPickerButton.BackColor = Color.LightSkyBlue;
            colorPickerButton.Font = new Font("Arial", 10F, FontStyle.Bold);
            colorPickerButton.Location = new Point(280, 40);
            colorPickerButton.Name = "colorPickerButton";
            colorPickerButton.Size = new Size(150, 40);
            colorPickerButton.TabIndex = 2;
            colorPickerButton.Text = "Change Color";
            colorPickerButton.UseVisualStyleBackColor = false;
            colorPickerButton.Click += colorPickerButton_Click;
            // 
            // energySavingButton
            // 
            energySavingButton.BackColor = Color.Goldenrod;
            energySavingButton.Font = new Font("Arial", 10F, FontStyle.Bold);
            energySavingButton.Location = new Point(450, 40);
            energySavingButton.Name = "energySavingButton";
            energySavingButton.Size = new Size(200, 40);
            energySavingButton.TabIndex = 3;
            energySavingButton.Text = "Energy Saving Mode";
            energySavingButton.UseVisualStyleBackColor = false;
            energySavingButton.Click += energySavingButton_Click;
            // 
            // lightPreviewPanel
            // 
            lightPreviewPanel.BackColor = Color.White;
            lightPreviewPanel.BorderStyle = BorderStyle.FixedSingle;
            lightPreviewPanel.Location = new Point(20, 30);
            lightPreviewPanel.Name = "lightPreviewPanel";
            lightPreviewPanel.Size = new Size(720, 140);
            lightPreviewPanel.TabIndex = 0;
            // 
            // controlGroupBox
            // 
            controlGroupBox.Controls.Add(onButton);
            controlGroupBox.Controls.Add(offButton);
            controlGroupBox.Controls.Add(colorPickerButton);
            controlGroupBox.Controls.Add(energySavingButton);
            controlGroupBox.Controls.Add(brightnessSlider);
            controlGroupBox.Controls.Add(brightnessLabel);
            controlGroupBox.Font = new Font("Arial", 12F, FontStyle.Bold);
            controlGroupBox.ForeColor = Color.Black;
            controlGroupBox.Location = new Point(20, 20);
            controlGroupBox.Name = "controlGroupBox";
            controlGroupBox.Size = new Size(760, 200);
            controlGroupBox.TabIndex = 0;
            controlGroupBox.TabStop = false;
            controlGroupBox.Text = "Controls";
            // 
            // previewGroupBox
            // 
            previewGroupBox.Controls.Add(lightPreviewPanel);
            previewGroupBox.Font = new Font("Arial", 12F, FontStyle.Bold);
            previewGroupBox.ForeColor = Color.Black;
            previewGroupBox.Location = new Point(20, 260);
            previewGroupBox.Name = "previewGroupBox";
            previewGroupBox.Size = new Size(760, 197);
            previewGroupBox.TabIndex = 1;
            previewGroupBox.TabStop = false;
            previewGroupBox.Text = "Light Preview";
            // 
            // LightModuleForm
            // 
            BackColor = Color.LightGray;
            BackgroundImage = Properties.Resources.LIT;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 500);
            Controls.Add(controlGroupBox);
            Controls.Add(previewGroupBox);
            Name = "LightModuleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Light Module";
            Load += LightModuleForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)brightnessSlider).EndInit();
            controlGroupBox.ResumeLayout(false);
            controlGroupBox.PerformLayout();
            previewGroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
