using System;

namespace Prototipo2.Logging
{
    public static class SimpleLogger
    {
        public static void Info(string message) { }
        public static void Error(string message) { }
        public static void Error(string message, Exception ex) { }
    }
}
                