using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Log
{
    public class LogManager
    {
        private static int errorCount = 0;
        private static int telemetryCount = 0;
        private LogService logService;
        private Config config;

        public LogManager() {

            config = new Config();
            logService = new LogService();
 
        }

        /// <summary>
        /// This method creates an error object from an exception, converts it to json, and prepares for it to be logged.
        /// </summary>
        /// <param name="ex">Exception that is used to create an error object</param>
        public bool LogError(string id, Exception exception)
        {
            if (CheckCount(errorCount) == false)
            {
                //init error object
                var error = new Error
                {
                    userID = id,
                    timeOfError = string.Format(DateTime.UtcNow.ToString(config.GetDateTimeFormat())),
                    errorMsg = string.Format(exception.Message),
                    stackTrace = string.Format(exception.StackTrace),
                    targetSite = exception.TargetSite.ToString()

                };

                //convert error object into json format
                string errorlog = JsonConvert.SerializeObject(error, Formatting.Indented);

                logService.LogError(errorlog);
                errorCount++;

                return true;
            }
            else {

                Console.WriteLine("100 error logs have been recorded. Please Contact System Administrator");
                return false;
            }
        }

        /// <summary>
        /// This method creates a telemetry object, converts it to json, and prepares for it to be logged.
        /// </summary>
        /// <param name="obj">Telemetry object that is used to fill Telemetry properties to be logged.</param>
        public bool LogTelemetry(Telemetry obj)
        {
            if (isOpted() == true)
            {
                if (CheckCount(telemetryCount) == false)
                {
                    //convert telemetry object into json format
                    string telemetry = JsonConvert.SerializeObject(obj, Formatting.Indented);

                    logService.LogTelemetry(telemetry);
                    telemetryCount++;

                    return true;
                }
                else
                {
                    Console.WriteLine("100 telemetry logs have been recorded. Please Contact System Administrator");
                    return false;
                }

            }else

            Console.WriteLine("User " + obj.userID + " has opted out of telemetry collection.");
            return false;
        }

        /// <summary>
        /// This method checks the count of how many logs have been recorded.
        /// </summary>
        /// <param name="count">paramter that represents the count of how many logs have been logged.</param>
        public bool CheckCount(int count)
        {
            if (count <= 100)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file">Should be in MM-dd-yyy_type.json //type is either "Error" or "Telemetry"</param>
        /// <returns></returns>
        public List<string> GetLog(string file)
        {
            return logService.GetLog(file);
        }
        /// <summary>
        /// This method checks to see if user has opted in or out of telemetry collection.
        /// </summary>
        /// <param name="user">user object which contains boolean that represents choice of telemetry collection.</param>
        /// <returns></returns>
        public bool isOpted()
        {
            return true;

            /*
            if (user.OptedIn == true)
            {
                return true;
            }
            else
            {
                return false;
            }
            */
        }
    }
}
