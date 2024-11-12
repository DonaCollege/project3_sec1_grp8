using System;
using System.Collections.Generic;
using System.IO;

namespace WinFormsApp5
{
    //Controls access to a smart lock by authenticating users, monitoring lock status, and logging events.
    //Interacts with SCADA/HMI to provide real-time status and security alerts.
    
    public class SmartLock
    {
        // Private fields
        private bool isLocked; // Indicates if the lock is engaged
        private Dictionary<string, string> authorizedUsers; // Stores up to 3 user credentials
        private bool tamperDetected; // Indicates if tampering is detected
        private string logFilePath; // Path for event log file
        private DateTime lastFailedAttempt; // Timestamp of the last failed unlock attempt
        private int failedAttempts; // Counter for failed attempts to detect tampering

        
        //Default constructor, initializes SmartLock with default settings.
        //Lock status is set to locked, tamper detection is off, and authorized users list is predefined.
        
        public SmartLock()
        {
            isLocked = true; // Default to locked
            tamperDetected = false;
            lastFailedAttempt = DateTime.MinValue;
            failedAttempts = 0;

            // Initialize authorized users (up to 3 users)
            authorizedUsers = new Dictionary<string, string>
            {
                { "user1", "password1" },
                { "user2", "password2" },
                { "user3", "password3" }
            };
        }

       
        //Constructor that accepts a log file path for storing event logs.
        
        public SmartLock(string logPath) : this()
        {
            logFilePath = logPath;
        }

        //Gets the current lock status
        public bool LockStatus => isLocked;

        //Indicates the last authentication status.
        
        public bool AuthenticationStatus { get; private set; }

        //Locks the SmartLock, sets the lock status to locked, and logs the event.
     
        public void Lock()
        {
            isLocked = true;
            logEvent("Locked");
            updateHMI();
        }

        //Unlocks the SmartLock if the provided userID and password are correct.
        //Updates lock status, logs event, and notifies HMI.
        
        public bool Unlock(string userID, string password)
        {
            if (AuthenticateUser(userID, password))
            {
                isLocked = false;
                AuthenticationStatus = true;
                logEvent("Unlocked");
                updateHMI();
                return true;
            }
            else
            {
                failedAttempts++;
                detectTampering();
                AuthenticationStatus = false;
                logEvent("Failed unlock attempt");
                updateHMI();
                return false;
            }
        }

        // Authenticates a user by checking if the provided credentials match any of the predefined authorized users.
       
        private bool AuthenticateUser(string userID, string password)
        {
            return authorizedUsers.ContainsKey(userID) && authorizedUsers[userID] == password;
        }

        
        // Logs a specific event with a timestamp to the specified log file or to the console if log file is inaccessible.
       
        public void LogEvent(string eventDescription)
        {
            string logEntry = $"{DateTime.Now}: {eventDescription}";
            if (!string.IsNullOrEmpty(logFilePath))
            {
                try
                {
                    File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
                }
                catch (IOException)
                {
                    // Handle log file errors, possibly switch to in-memory logging
                    Console.WriteLine("Log file inaccessible, logging in-memory.");
                }
            }
            else
            {
                Console.WriteLine(logEntry); // Fallback to console logging
            }
        }

        private void detectTampering()
        {
            if ((DateTime.Now - lastFailedAttempt).TotalSeconds < 10 && failedAttempts > 3)
            {
                tamperDetected = true;
                logEvent("Tampering detected");
                updateHMI();
            }
            lastFailedAttempt = DateTime.Now;
        }

        public void UpdateFromHMI(bool lockCommand)
        {
            if (lockCommand)
            {
                Lock();
            }
            else
            {
                // HMI requests unlock, assume user is authenticated
                Unlock("defaultUser", "defaultPassword"); // Replace with actual HMI credentials if needed
            }
        }

        private void updateHMI()
        {
            // Code to send lockStatus, authenticationStatus, and tamperDetected to HMI
            Console.WriteLine("HMI Updated: LockStatus = " + isLocked + ", AuthenticationStatus = " + AuthenticationStatus + ", TamperDetected = " + tamperDetected);
        }
    }
}

