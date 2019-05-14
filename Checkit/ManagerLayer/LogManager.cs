using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.ServiceLayer;
using CheckIt.DataAccessLayer;

using System.IO;

namespace CheckIt.ManagerLayer
{   
/// <summary>
/// This class is responsible to handle the business rules of logging feature.
/// </summary>
    public class LogManager
    {
        private static int _errorCount = 0; 
        private static int _telemetryCount = 0; //store these static values in db or file, Rigiht now, may not be thread safe, will clash with instances
        private LogService logService;
        private ServiceLayer.Config config;
        //private EmailService eService;

        public LogManager() {
            //eService = new EmailService();
            config = new ServiceLayer.Config();
            logService = new LogService();
 
        }

        /// <summary>
        /// This method creates an error object from an exception, converts it to json, and prepares for it to be logged.
        /// </summary>
        /// <param name="ex">Exception that is used to create an error object</param>
        public bool LogError(string id, Exception exception) //id should be userid
        {
            if (isValidCount(_errorCount)) 
            {
                //init error object
                var error = new Error
                {
                    userID = id,
                    timeOfError = string.Format(DateTime.UtcNow.ToString(config.DATE_TIME_FORMAT)),
                    errorMsg = string.Format(exception.Message),
                    stackTrace = string.Format(exception.StackTrace),
                    targetSite = exception.TargetSite.ToString()

                };
                //indented-->costly in cpu cycle, better to minimize the format in production
                //convert error object into json format
                string errorlog = JsonConvert.SerializeObject(error, Formatting.Indented);

                _errorCount++;
                return logService.LogError(errorlog);
            }
                //After 100 failed error logs the system administrator should be notified
#if DEBUG
                Console.WriteLine("100 failed error logs have been recorded. Please Contact System Administrator");
#else
                eService.SendMail("spyderzdevs@gmail.com", "100 failed error logs");
#endif
                return false;
        }

        /// <summary>
        /// This method creates a telemetry object, converts it to json, and prepares for it to be logged.
        /// </summary>
        /// <param name="obj">Telemetry object that is used to fill Telemetry properties to be logged.</param>
        public bool LogTelemetry(Telemetry obj)
        {
            if (isOptIn() == true)
            {
                if (isValidCount(_telemetryCount))
                {
                    //convert telemetry object into json format
                    string telemetry = JsonConvert.SerializeObject(obj, Formatting.Indented);

                    _telemetryCount++;

                    return logService.LogTelemetry(telemetry);
                }
                //TODO: Finish requirement. After 100 failed telemetry logs the system administrator should be notified
#if DEBUG
                Console.WriteLine("100 failed telemetry logs have been recorded. Please Contact System Administrator");
#else
                    eService.SendMail("spyderzdevs@gmail.com", "100 failed error logs");
#endif
            }
           
            return false;
        }

        /// <summary>
        /// This method checks the count of how many logs have been recorded.
        /// </summary>
        /// <param name="count">paramter that represents the count of how many logs have been logged.</param>
        public bool isValidCount(int count)
        {
            return (count <= 100);
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
        /// Method which deletes a file
        /// </summary>
        /// <param name="file">name of file</param>
        /// <returns></returns>
        public bool DeleteLog(string file)
        {  
            return logService.DeleteLog(file);
        }

        /// <summary>
        /// This method checks to see if user has opted in or out of telemetry collection.
        /// </summary>
        /// <param name="user">user object which contains boolean that represents choice of telemetry collection.</param>
        /// <returns></returns>
        public bool isOptIn()
        {
            //TODO: FINISH GRABBING FROM USER OBJ PROPERTERY  
            //NOTE: TODO ITEMS ARE VIEWABLE IN VIEW-TASKLIST
            bool userChoice = true;

            if (userChoice == true)
            {
                return true;
            }

            Console.WriteLine("User has opted out of telemetry collection.");

            return false;
        }
    }
    
}
