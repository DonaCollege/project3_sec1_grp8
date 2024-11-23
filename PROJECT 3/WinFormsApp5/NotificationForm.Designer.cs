namespace WinFormsApp5
{
    partial class NotificationForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstNotifications;
        private System.Windows.Forms.Button btnClearHistory;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.ComboBox cmbModules;

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
            this.lstNotifications = new System.Windows.Forms.ListBox();
            this.btnClearHistory = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.cmbModules = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();

            // lstNotifications
            this.lstNotifications.FormattingEnabled = true;
            this.lstNotifications.ItemHeight = 20;
            this.lstNotifications.Location = new System.Drawing.Point(12, 50);
            this.lstNotifications.Name = "lstNotifications";
            this.lstNotifications.Size = new System.Drawing.Size(776, 344);
            this.lstNotifications.TabIndex = 0;

            // btnClearHistory
            this.btnClearHistory.Location = new System.Drawing.Point(12, 410);
            this.btnClearHistory.Name = "btnClearHistory";
            this.btnClearHistory.Size = new System.Drawing.Size(120, 30);
            this.btnClearHistory.TabIndex = 1;
            this.btnClearHistory.Text = "Clear History";
            this.btnClearHistory.UseVisualStyleBackColor = true;
           // this.btnClearHistory.Click += new System.EventHandler(this.btnClearHistory_Click);

            // btnClearAll
            this.btnClearAll.Location = new System.Drawing.Point(150, 410);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(120, 30);
            this.btnClearAll.TabIndex = 2;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
           // this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);

            // cmbModules
            this.cmbModules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModules.FormattingEnabled = true;
            this.cmbModules.Location = new System.Drawing.Point(12, 12);
            this.cmbModules.Name = "cmbModules";
            this.cmbModules.Size = new System.Drawing.Size(300, 28);
            this.cmbModules.TabIndex = 3;
           // this.cmbModules.SelectedIndexChanged += new System.EventHandler(this.cmbModules_SelectedIndexChanged);

            // NotificationForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbModules);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnClearHistory);
            this.Controls.Add(this.lstNotifications);
            this.Name = "NotificationForm";
            this.Text = "Notification System";
           // this.Load += new System.EventHandler(this.NotificationForm_Load);
            this.ResumeLayout(false);
        }
    }
}
