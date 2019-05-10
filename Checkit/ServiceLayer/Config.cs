using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Log
{
    /// <summary>
    /// This class contains all configurations for logging feature.
    /// </summary>
    public class Config
    {
        private const string ERROR_LOG_EXT = "_Error.json"; 
        private const string TEL_LOG_EXT = "_Telemetry.json";
        private const string DATE_FORMAT = "yyyy-MM-dd";
        private const string DATE_TIME_FORMAT = "MM/dd/yyyy hh:mm:ss tt ";
        private const string LOG_DIRECTORY = @"C:\Users\Alex Philayvanh\source\repos\Log\Log\Logs\";
        //Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName+"\\Logs";

        public string GetErrorLogExtension()
        {
            return ERROR_LOG_EXT;
        }
        public string GetTelemetryLogExtension()
        {
            return TEL_LOG_EXT;
        }
        public string GetDateTimeFormat()
        {
            return DATE_TIME_FORMAT;
        }
        public string GetLogDirectory()
        {
            return LOG_DIRECTORY;
        }

        public string GetDateFormat()
        {
            return DATE_FORMAT;
        }

    }
}
