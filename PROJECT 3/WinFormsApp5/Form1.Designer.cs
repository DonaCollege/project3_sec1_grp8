namespace WinFormsApp5
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            txtStatus = new TextBox();
            radioButton1 = new RadioButton();
            Off = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            button8 = new Button();
            radioButton4 = new RadioButton();
            radioButton5 = new RadioButton();
            radioButton6 = new RadioButton();
            radioButton7 = new RadioButton();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button9 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.LIT;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1407, 505);
            button1.Name = "button1";
            button1.Size = new Size(217, 168);
            button1.TabIndex = 0;
            button1.Text = "LIGHTS";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaptionText;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ActiveCaptionText;
            button2.Location = new Point(88, 83);
            button2.Name = "button2";
            button2.Size = new Size(182, 148);
            button2.TabIndex = 1;
            button2.Text = "LIGHTS";
            button2.TextAlign = ContentAlignment.BottomCenter;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ActiveCaptionText;
            button3.Location = new Point(360, 83);
            button3.Name = "button3";
            button3.Size = new Size(182, 148);
            button3.TabIndex = 2;
            button3.Text = "SMARTLOCK";
            button3.TextAlign = ContentAlignment.BottomCenter;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = SystemColors.ActiveCaptionText;
            button4.Location = new Point(533, 291);
            button4.Name = "button4";
            button4.Size = new Size(182, 148);
            button4.TabIndex = 3;
            button4.Text = "NOTIFICATION ";
            button4.TextAlign = ContentAlignment.TopCenter;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = SystemColors.ButtonHighlight;
            button5.Location = new Point(624, 83);
            button5.Name = "button5";
            button5.Size = new Size(182, 148);
            button5.TabIndex = 3;
            button5.Text = "CAMERAS";
            button5.TextAlign = ContentAlignment.BottomCenter;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.BackgroundImageLayout = ImageLayout.Stretch;
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = SystemColors.ButtonHighlight;
            button6.Location = new Point(891, 83);
            button6.Name = "button6";
            button6.Size = new Size(182, 148);
            button6.TabIndex = 3;
            button6.Text = "MOTIONSENSOR";
            button6.TextAlign = ContentAlignment.BottomCenter;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackgroundImage = (Image)resources.GetObject("button7.BackgroundImage");
            button7.BackgroundImageLayout = ImageLayout.Stretch;
            button7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ForeColor = SystemColors.ActiveCaptionText;
            button7.Location = new Point(259, 291);
            button7.Name = "button7";
            button7.Size = new Size(182, 148);
            button7.TabIndex = 4;
            button7.Text = "TEMPERATORSENSOR";
            button7.TextAlign = ContentAlignment.TopCenter;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // txtStatus
            // 
            txtStatus.BackColor = SystemColors.Info;
            txtStatus.Location = new Point(101, 500);
            txtStatus.Multiline = true;
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(972, 150);
            txtStatus.TabIndex = 6;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = SystemColors.Info;
            radioButton1.Location = new Point(114, 248);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(49, 24);
            radioButton1.TabIndex = 7;
            radioButton1.TabStop = true;
            radioButton1.Text = "On";
            radioButton1.UseVisualStyleBackColor = false;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // Off
            // 
            Off.AutoSize = true;
            Off.BackColor = SystemColors.Info;
            Off.Location = new Point(196, 248);
            Off.Name = "Off";
            Off.Size = new Size(51, 24);
            Off.TabIndex = 8;
            Off.TabStop = true;
            Off.Text = "Off";
            Off.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.BackColor = SystemColors.Info;
            radioButton2.Location = new Point(376, 240);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(60, 24);
            radioButton2.TabIndex = 9;
            radioButton2.TabStop = true;
            radioButton2.Text = "Lock";
            radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.BackColor = SystemColors.Info;
            radioButton3.Location = new Point(455, 240);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(75, 24);
            radioButton3.TabIndex = 10;
            radioButton3.TabStop = true;
            radioButton3.Text = "Unlock";
            radioButton3.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            button8.BackColor = Color.IndianRed;
            button8.BackgroundImage = (Image)resources.GetObject("button8.BackgroundImage");
            button8.BackgroundImageLayout = ImageLayout.Stretch;
            button8.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.ImageAlign = ContentAlignment.BottomCenter;
            button8.Location = new Point(804, 291);
            button8.Name = "button8";
            button8.Size = new Size(156, 148);
            button8.TabIndex = 11;
            button8.Text = "EXIT";
            button8.TextAlign = ContentAlignment.TopCenter;
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click_1;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.BackColor = SystemColors.Info;
            radioButton4.Location = new Point(642, 240);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(47, 24);
            radioButton4.TabIndex = 12;
            radioButton4.TabStop = true;
            radioButton4.Text = "on";
            radioButton4.UseVisualStyleBackColor = false;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.BackColor = SystemColors.Info;
            radioButton5.Location = new Point(719, 240);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(51, 24);
            radioButton5.TabIndex = 13;
            radioButton5.TabStop = true;
            radioButton5.Text = "Off";
            radioButton5.UseVisualStyleBackColor = false;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.BackColor = SystemColors.Info;
            radioButton6.Location = new Point(922, 237);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(47, 24);
            radioButton6.TabIndex = 14;
            radioButton6.TabStop = true;
            radioButton6.Text = "on";
            radioButton6.UseVisualStyleBackColor = false;
            // 
            // radioButton7
            // 
            radioButton7.AutoSize = true;
            radioButton7.BackColor = SystemColors.Info;
            radioButton7.Location = new Point(994, 237);
            radioButton7.Name = "radioButton7";
            radioButton7.Size = new Size(51, 24);
            radioButton7.TabIndex = 15;
            radioButton7.TabStop = true;
            radioButton7.Text = "Off";
            radioButton7.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Info;
            textBox1.Location = new Point(286, 445);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 16;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Gold;
            textBox2.Font = new Font("Berlin Sans FB", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(430, 12);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(346, 32);
            textBox2.TabIndex = 17;
            textBox2.Text = "SMART HOME MONITIRING SYSTEM";
            // 
            // button9
            // 
            button9.Location = new Point(570, 443);
            button9.Name = "button9";
            button9.Size = new Size(94, 29);
            button9.TabIndex = 18;
            button9.Text = "button9";
            button9.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.main_BG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1252, 637);
            Controls.Add(button9);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(radioButton7);
            Controls.Add(radioButton6);
            Controls.Add(radioButton5);
            Controls.Add(radioButton4);
            Controls.Add(button8);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(Off);
            Controls.Add(radioButton1);
            Controls.Add(txtStatus);
            Controls.Add(button7);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private TextBox txtStatus;
        private RadioButton radioButton1;
        private RadioButton Off;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private Button button8;
        private RadioButton radioButton4;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
        private RadioButton radioButton7;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button9;
    }
}
