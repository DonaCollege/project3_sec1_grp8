using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.IO;

/*using System;
using System.Collections.Generic;
using System.IO;

namespace WinFormsApp5
{
    public class SmartLock
    {
        private bool isLocked;
        private readonly Dictionary<string, string> authorizedUsers;
        private readonly string logFilePath;

        public event Action<string> OnStatusUpdate;

        public SmartLock(string logFilePath = "SmartLockLogs.txt")
        {
            isLocked = true; // Default state is locked
            this.logFilePath = logFilePath;

            // Predefined authorized users (up to 3 users)
            authorizedUsers = new Dictionary<string, string>
            {
                { "user1", "password1" },
                { "user2", "password2" },
                { "user3", "password3" }
            };

            LogEvent("SmartLock initialized. Default state: LOCKED.");
        }

        public bool IsLocked => isLocked;

        public void Lock()
        {
            isLocked = true;
            LogEvent("Lock engaged.");
            NotifyStatusUpdate();
        }

        public bool Unlock(string userID, string password)
        {
            if (AuthenticateUser(userID, password))
            {
                isLocked = false;
                LogEvent($"Unlock successful. User: {userID}.");
                NotifyStatusUpdate();
                return true;
            }
            else
            {
                LogEvent($"Failed unlock attempt by User: {userID}.");
                NotifyStatusUpdate();
                return false;
            }
        }

        public bool AuthenticateUser(string userID, string password)
        {
            return authorizedUsers.ContainsKey(userID) && authorizedUsers[userID] == password;
        }

        public bool AddUser(string userID, string password)
        {
            if (authorizedUsers.Count >= 3)
            {
                LogEvent("Failed to add user. Maximum user limit reached.");
                return false; // Maximum limit reached
            }

            if (authorizedUsers.ContainsKey(userID))
            {
                LogEvent($"Failed to add user. User ID '{userID}' already exists.");
                return false; // Duplicate User ID
            }

            authorizedUsers.Add(userID, password);
            LogEvent($"User added successfully. User ID: {userID}.");
            return true;
        }

        private void LogEvent(string eventDescription)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"{timestamp} - {eventDescription}";

            // Append log to the file
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }

        private void NotifyStatusUpdate()
        {
            string status = isLocked ? "LOCKED" : "UNLOCKED";
            OnStatusUpdate?.Invoke($"Status: {status}");
        }
    }
}
*/

using System;
using System.Collections.Generic;
using System.IO;

namespace WinFormsApp5
{
    public class SmartLock
    {
        private bool isLocked;
        private readonly Dictionary<string, string> authorizedUsers;
        private readonly string logFilePath;

        public event Action<string> OnStatusUpdate;

        public SmartLock(string logFilePath = "SmartLockLogs.txt")
        {
            isLocked = true; // Default state is locked
            this.logFilePath = logFilePath;

            // Predefined authorized users
            authorizedUsers = new Dictionary<string, string>
            {
                { "user1", "password1" },
                { "user2", "password2" },
                { "user3", "password3" }
            };

            LogEvent("SmartLock initialized. Default state: LOCKED.");
        }

        public bool IsLocked => isLocked;

        public void Lock()
        {
            isLocked = true;
            LogEvent("Lock engaged.");
            NotifyStatusUpdate();
        }

        public bool Unlock(string userID, string password)
        {
            if (AuthenticateUser(userID, password))
            {
                isLocked = false;
                LogEvent($"Unlock successful. User: {userID}.");
                NotifyStatusUpdate();
                return true;
            }
            else
            {
                LogEvent($"Failed unlock attempt by User: {userID}.");
                NotifyStatusUpdate();
                return false;
            }
        }

        private bool AuthenticateUser(string userID, string password)
        {
            return authorizedUsers.ContainsKey(userID) && authorizedUsers[userID] == password;
        }

        private void LogEvent(string eventDescription)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"{timestamp} - {eventDescription}";

            // Append log to the file
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }

        private void NotifyStatusUpdate()
        {
            string status = isLocked ? "LOCKED" : "UNLOCKED";
            OnStatusUpdate?.Invoke($"Status: {status}");
        }
    }
}

