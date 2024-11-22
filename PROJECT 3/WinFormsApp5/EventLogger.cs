using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.IO;

namespace WinFormsApp5
{
    public static class EventLogger
    {
        public static void Log(string filePath, string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"{timestamp} - {message}";
            File.AppendAllText(filePath, logEntry + Environment.NewLine);
        }
    }
}
