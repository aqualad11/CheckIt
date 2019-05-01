using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Log
{
    class LogService
    {
        private Config config;
        private LogRepository logRepo;       

        public LogService()
        {
            config = new Config();
            logRepo = new LogRepository();
        }
        /// <summary>
        /// Method which calls the log repo to log telemetry data
        /// </summary>
        /// <param name="description">message to be logged</param>
        public void LogTelemetry(string description)
        {
            logRepo.LogTelemetry(description);
        }
        /// <summary>
        /// Method which calls the log repo to log error data
        /// </summary>
        /// <param name="description">error information to be logged</param>
        public void LogError(string description)
        {
            logRepo.LogError(description);
        }

        /// <summary>
        /// Method which calls the repository to retrieve logs given a file name
        /// </summary>
        /// <param name="file">format: mm-dd-yyyy_type.json //type is either "Error" or "Telemetry"</param>
        /// <returns></returns>
        public List<string> GetLog(string file)
        {
            return logRepo.GetLog(file);
        }
        
    }
}
