namespace WinFormsApp5
{
    partial class NotificationForm
    {
        private System.ComponentModel.IContainer components = null;

        // Form Clean-up code
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
            this.lstNotifications = new System.Windows.Forms.ListBox();
            this.btnSimulateAlert = new System.Windows.Forms.Button();
            this.btnClearHistory = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // lstNotifications
            // 
            this.lstNotifications.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);  // Dark background for the ListBox
            this.lstNotifications.ForeColor = System.Drawing.Color.White;  // White text
            this.lstNotifications.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstNotifications.FormattingEnabled = true;
            this.lstNotifications.ItemHeight = 20;
            this.lstNotifications.Location = new System.Drawing.Point(12, 12);
            this.lstNotifications.Name = "lstNotifications";
            this.lstNotifications.Size = new System.Drawing.Size(776, 364);
            this.lstNotifications.TabIndex = 0;
            this.lstNotifications.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstNotifications.SelectionMode = System.Windows.Forms.SelectionMode.None;  // Disable selection of items

            // 
            // btnSimulateAlert
            // 
            this.btnSimulateAlert.BackColor = System.Drawing.Color.CornflowerBlue;  // Blue button color
            this.btnSimulateAlert.FlatAppearance.BorderSize = 0;
            this.btnSimulateAlert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimulateAlert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSimulateAlert.ForeColor = System.Drawing.Color.White;  // White text on button
            this.btnSimulateAlert.Location = new System.Drawing.Point(12, 400);
            this.btnSimulateAlert.Name = "btnSimulateAlert";
            this.btnSimulateAlert.Size = new System.Drawing.Size(180, 40);
            this.btnSimulateAlert.TabIndex = 1;
            this.btnSimulateAlert.Text = "Simulate Alert";
            this.btnSimulateAlert.UseVisualStyleBackColor = false;
            this.btnSimulateAlert.Click += new System.EventHandler(this.btnSimulateAlert_Click);

            // 
            // btnClearHistory
            // 
            this.btnClearHistory.BackColor = System.Drawing.Color.IndianRed;  // Red color for the clear button
            this.btnClearHistory.FlatAppearance.BorderSize = 0;
            this.btnClearHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearHistory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClearHistory.ForeColor = System.Drawing.Color.White;  // White text
            this.btnClearHistory.Location = new System.Drawing.Point(198, 400);
            this.btnClearHistory.Name = "btnClearHistory";
            this.btnClearHistory.Size = new System.Drawing.Size(180, 40);
            this.btnClearHistory.TabIndex = 2;
            this.btnClearHistory.Text = "Clear History";
            this.btnClearHistory.UseVisualStyleBackColor = false;
            this.btnClearHistory.Click += new System.EventHandler(this.btnClearHistory_Click);

            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClearHistory);
            this.Controls.Add(this.btnSimulateAlert);
            this.Controls.Add(this.lstNotifications);
            this.Name = "NotificationForm";
            this.Text = "Smart Home Notifications";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox lstNotifications;
        private System.Windows.Forms.Button btnSimulateAlert;
        private System.Windows.Forms.Button btnClearHistory;
    }
}
