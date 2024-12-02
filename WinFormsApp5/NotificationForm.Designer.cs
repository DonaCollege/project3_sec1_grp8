namespace WinFormsApp5
{
    partial class NotificationForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox NOTIFICATIONS;
        private System.Windows.Forms.Button btnClearAll;

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
            NOTIFICATIONS = new ListBox();
            btnClearAll = new Button();
            ALERTS = new ListBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // NOTIFICATIONS
            // 
            NOTIFICATIONS.BackColor = SystemColors.Info;
            NOTIFICATIONS.FormattingEnabled = true;
            NOTIFICATIONS.Location = new Point(21, 32);
            NOTIFICATIONS.Name = "NOTIFICATIONS";
            NOTIFICATIONS.Size = new Size(749, 164);
            NOTIFICATIONS.TabIndex = 0;
            // 
            // btnClearAll
            // 
            btnClearAll.Location = new Point(20, 420);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(120, 30);
            btnClearAll.TabIndex = 5;
            btnClearAll.Text = "Clear All";
            btnClearAll.UseVisualStyleBackColor = true;
            btnClearAll.Click += btnClearAll_Click;
            // 
            // ALERTS
            // 
            ALERTS.BackColor = Color.LemonChiffon;
            ALERTS.FormattingEnabled = true;
            ALERTS.Location = new Point(21, 246);
            ALERTS.Name = "ALERTS";
            ALERTS.Size = new Size(749, 124);
            ALERTS.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(21, -1);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 6;
            textBox1.Text = "Notifications";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(21, 213);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 7;
            textBox2.Text = "Alerts";
            // 
            // NotificationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(ALERTS);
            Controls.Add(NOTIFICATIONS);
            Controls.Add(btnClearAll);
            Name = "NotificationForm";
            Text = "Notification System";
            Load += NotificationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private ListBox ALERTS;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}
