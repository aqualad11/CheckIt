using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CheckIt.ServiceLayer
{
    /// <summary>
    /// This class will be doing the file checking and configurations
    /// Vongs tips: check if file has enough space-set max capacity, if max make new file. 5MB, make new file
    /// </summary>
    public class LogService
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
        public bool LogTelemetry(string description)
        {
            return logRepo.LogTelemetry(description);
        }

        /// <summary>
        /// Method which calls the log repo to log error data
        /// </summary>
        /// <param name="description">error information to be logged</param>
        public bool LogError(string description)
        {
            return logRepo.LogError(description);
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
        /// <summary>
        /// Method which calls the repository to delete a specified file
        /// </summary>
        /// <param name="file">name of file</param>
        public bool DeleteLog(string file)
        {
            return logRepo.DeleteLog(file);
        }
        
    }
}
