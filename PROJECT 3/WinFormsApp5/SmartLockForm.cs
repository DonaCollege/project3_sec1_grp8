using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Windows.Forms;


using System;
using System.Windows.Forms;
/*
namespace WinFormsApp5
{
    public partial class SmartLockForm : Form
    {
        private readonly SmartLock _smartLock;

        public SmartLockForm()
        {
            InitializeComponent();
            _smartLock = new SmartLock();
            _smartLock.OnStatusUpdate += UpdateLockStatus;
        }

        private void LockButton_Click(object sender, EventArgs e)
        {
            _smartLock.Lock();
            UpdateLogs("System locked.");
        }

        private void UnlockButton_Click(object sender, EventArgs e)
        {
            string userID = userIdTextBox.Text;
            string password = passwordTextBox.Text;

            if (_smartLock.Unlock(userID, password))
            {
                UpdateLogs($"Unlocked by User: {userID}");
            }
            else
            {
                UpdateLogs($"Failed unlock attempt by User: {userID}");
            }
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            string newUserID = newUserIdTextBox.Text;
            string newUserPassword = newUserPasswordTextBox.Text;

            if (string.IsNullOrWhiteSpace(newUserID) || string.IsNullOrWhiteSpace(newUserPassword))
            {
                UpdateLogs("Failed to add user. User ID or password cannot be empty.");
                return;
            }

            if (_smartLock.AddUser(newUserID, newUserPassword))
            {
                UpdateLogs($"New user added successfully. User ID: {newUserID}");
            }
            else
            {
                UpdateLogs($"Failed to add user. User ID: {newUserID}");
            }
        }

        private void UpdateLockStatus(string status)
        {
            lockStatusLabel.Text = status;
        }

        private void UpdateLogs(string log)
        {
            logListBox.Items.Add(log);
        }

        private void SmartLockForm_Load(object sender, EventArgs e)
        {

        }
    }
}
*/

using System;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class SmartLockForm : Form
    {
        private readonly SmartLock _smartLock;

        public SmartLockForm()
        {
            InitializeComponent();
            _smartLock = new SmartLock();
            _smartLock.OnStatusUpdate += UpdateLockStatus;
        }

        private void LockButton_Click(object sender, EventArgs e)
        {
            _smartLock.Lock();
            UpdateLogs("System locked.");
        }

        private void UnlockButton_Click(object sender, EventArgs e)
        {
            string userID = userIdTextBox.Text;
            string password = passwordTextBox.Text;

            if (_smartLock.Unlock(userID, password))
            {
                UpdateLogs($"Unlocked by User: {userID}");
            }
            else
            {
                UpdateLogs($"Failed unlock attempt by User: {userID}");
            }
        }

        private void UpdateLockStatus(string status)
        {
            lockStatusLabel.Text = status;
        }

        private void UpdateLogs(string log)
        {
            logListBox.Items.Add(log);
        }
    }
}
