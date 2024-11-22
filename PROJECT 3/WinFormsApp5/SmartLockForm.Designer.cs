/*namespace WinFormsApp5
{
    partial class SmartLockForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lockStatusLabel;
        private System.Windows.Forms.TextBox userIdTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button lockButton;
        private System.Windows.Forms.Button unlockButton;
        private System.Windows.Forms.ListBox logListBox;
        private System.Windows.Forms.TextBox newUserIdTextBox;
        private System.Windows.Forms.TextBox newUserPasswordTextBox;
        private System.Windows.Forms.Button addUserButton;

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
            lockStatusLabel = new Label();
            userIdTextBox = new TextBox();
            passwordTextBox = new TextBox();
            lockButton = new Button();
            unlockButton = new Button();
            logListBox = new ListBox();
            newUserIdTextBox = new TextBox();
            newUserPasswordTextBox = new TextBox();
            addUserButton = new Button();
            SuspendLayout();
            // 
            // lockStatusLabel
            // 
            lockStatusLabel.Location = new Point(20, 20);
            lockStatusLabel.Name = "lockStatusLabel";
            lockStatusLabel.Size = new Size(300, 30);
            lockStatusLabel.TabIndex = 0;
            lockStatusLabel.Text = "Status: LOCKED";
            // 
            // userIdTextBox
            // 
            userIdTextBox.Location = new Point(20, 60);
            userIdTextBox.Name = "userIdTextBox";
            userIdTextBox.PlaceholderText = "User ID";
            userIdTextBox.Size = new Size(100, 27);
            userIdTextBox.TabIndex = 1;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(20, 100);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PlaceholderText = "Password";
            passwordTextBox.Size = new Size(100, 27);
            passwordTextBox.TabIndex = 2;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // lockButton
            // 
            lockButton.Location = new Point(20, 140);
            lockButton.Name = "lockButton";
            lockButton.Size = new Size(100, 30);
            lockButton.TabIndex = 3;
            lockButton.Text = "Lock";
            lockButton.Click += LockButton_Click;
            // 
            // unlockButton
            // 
            unlockButton.Location = new Point(140, 140);
            unlockButton.Name = "unlockButton";
            unlockButton.Size = new Size(100, 30);
            unlockButton.TabIndex = 4;
            unlockButton.Text = "Unlock";
            unlockButton.Click += UnlockButton_Click;
            // 
            // logListBox
            // 
            logListBox.Location = new Point(20, 200);
            logListBox.Name = "logListBox";
            logListBox.Size = new Size(400, 144);
            logListBox.TabIndex = 5;
            // 
            // newUserIdTextBox
            // 
            newUserIdTextBox.Location = new Point(20, 370);
            newUserIdTextBox.Name = "newUserIdTextBox";
            newUserIdTextBox.PlaceholderText = "New User ID";
            newUserIdTextBox.Size = new Size(100, 27);
            newUserIdTextBox.TabIndex = 6;
            // 
            // newUserPasswordTextBox
            // 
            newUserPasswordTextBox.Location = new Point(20, 410);
            newUserPasswordTextBox.Name = "newUserPasswordTextBox";
            newUserPasswordTextBox.PlaceholderText = "New User Password";
            newUserPasswordTextBox.Size = new Size(100, 27);
            newUserPasswordTextBox.TabIndex = 7;
            newUserPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // addUserButton
            // 
            addUserButton.Location = new Point(140, 410);
            addUserButton.Name = "addUserButton";
            addUserButton.Size = new Size(100, 30);
            addUserButton.TabIndex = 8;
            addUserButton.Text = "Add User";
            // 
            // SmartLockForm
            // 
            ClientSize = new Size(500, 500);
            Controls.Add(lockStatusLabel);
            Controls.Add(userIdTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(lockButton);
            Controls.Add(unlockButton);
            Controls.Add(logListBox);
            Controls.Add(newUserIdTextBox);
            Controls.Add(newUserPasswordTextBox);
            Controls.Add(addUserButton);
            Name = "SmartLockForm";
            Text = "Smart Lock";
           // Load += SmartLockForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
*/

namespace WinFormsApp5
{
    partial class SmartLockForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lockStatusLabel;
        private System.Windows.Forms.TextBox userIdTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button lockButton;
        private System.Windows.Forms.Button unlockButton;
        private System.Windows.Forms.ListBox logListBox;

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
            lockStatusLabel = new Label();
            userIdTextBox = new TextBox();
            passwordTextBox = new TextBox();
            lockButton = new Button();
            unlockButton = new Button();
            logListBox = new ListBox();
            SuspendLayout();
            // 
            // lockStatusLabel
            // 
            lockStatusLabel.Location = new Point(20, 20);
            lockStatusLabel.Name = "lockStatusLabel";
            lockStatusLabel.Size = new Size(300, 30);
            lockStatusLabel.TabIndex = 0;
            lockStatusLabel.Text = "Status: LOCKED";
            // 
            // userIdTextBox
            // 
            userIdTextBox.Location = new Point(20, 60);
            userIdTextBox.Name = "userIdTextBox";
            userIdTextBox.PlaceholderText = "User ID";
            userIdTextBox.Size = new Size(100, 27);
            userIdTextBox.TabIndex = 1;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(20, 100);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PlaceholderText = "Password";
            passwordTextBox.Size = new Size(100, 27);
            passwordTextBox.TabIndex = 2;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // lockButton
            // 
            lockButton.Location = new Point(20, 140);
            lockButton.Name = "lockButton";
            lockButton.Size = new Size(100, 30);
            lockButton.TabIndex = 3;
            lockButton.Text = "Lock";
            lockButton.Click += LockButton_Click;
            // 
            // unlockButton
            // 
            unlockButton.Location = new Point(140, 140);
            unlockButton.Name = "unlockButton";
            unlockButton.Size = new Size(100, 30);
            unlockButton.TabIndex = 4;
            unlockButton.Text = "Unlock";
            unlockButton.Click += UnlockButton_Click;
            // 
            // logListBox
            // 
            logListBox.Location = new Point(20, 200);
            logListBox.Name = "logListBox";
            logListBox.Size = new Size(400, 144);
            logListBox.TabIndex = 5;
            // 
            // SmartLockForm
            // 
            ClientSize = new Size(500, 400);
            Controls.Add(lockStatusLabel);
            Controls.Add(userIdTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(lockButton);
            Controls.Add(unlockButton);
            Controls.Add(logListBox);
            Name = "SmartLockForm";
            Text = "Smart Lock";
            //Load += SmartLockForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

