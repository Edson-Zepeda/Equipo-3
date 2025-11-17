using System;
using System.IO;

namespace Prototipo2.Logging
{
    public static class SimpleLogger
    {
        private static readonly object _lock = new object();
        private static readonly string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "app.log");

        public static void Info(string message)
        {
            Write("INFO", message);
        }

        public static void Error(string message)
        {
            Write("ERROR", message);
        }

        public static void Error(string message, Exception ex)
        {
            Write("ERROR", message + " - " + ex.ToString());
        }

        private static void Write(string level, string message)
        {
            try
            {
                lock (_lock)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(_path));
                    File.AppendAllText(_path, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}|{level}|{message}\r\n");
                }
            }
            catch
            {
                // ignore logging errors
            }
        }
    }
}
