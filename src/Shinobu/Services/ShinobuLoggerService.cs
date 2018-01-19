using System;
using System.IO;

namespace Shinobu.Services
{
    public class ShinobuLoggerService
    {
        public static void Log(string message)
        {
            string logMessage = DateTime.Now + ": " + message + "\n";
            File.AppendAllText("log.txt", logMessage);
            Console.Write(logMessage);
        }
    }
}