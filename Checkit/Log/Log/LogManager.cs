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
        private Config config = new Config();


        public LogManager() { }

        /// <summary>
        /// This constructor creates a new logservice which creates a file name.
        /// </summary>
        /// <param name="fileName"></param>
        public LogManager(string fileName)
        {
            logService = new LogService(fileName);
        }

        /// <summary>
        /// This method creates an error object from an exception, converts it to json, and prepares for it to be logged.
        /// </summary>
        /// <param name="ex">Exception that is used to create an error object</param>
        public bool LogError(string id, Exception exception)
        {

                var error = new Error
                {
                    userID = id,
                    timeOfError = string.Format(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt ")),
                    errorMsg = string.Format(exception.Message),
                    stackTrace = string.Format(exception.StackTrace),
                    targetSite = exception.TargetSite.ToString()
  
                };
            
                //convert error object into json format
                string errorlog = JsonConvert.SerializeObject(error, Formatting.Indented);

            
                logService.Log(errorlog);
                return true;
 

        }
        /// <summary>
        /// This method creates a telemetry object, converts it to json, and prepares for it to be logged.
        /// </summary>
        /// <param name="obj">Telemetry object that is used to fill Telemetry properties to be logged.</param>
        public bool LogTelemetry(Telemetry obj)
        {
            //if(validateTelemetry(User user) == true)

     
            /*
                var info = new Telemetry
                {
                    userID = id,
                    dateTime = dateTime,
                    description = description

                };
                */
                //convert telemetry object into json format
                string telemetry = JsonConvert.SerializeObject(obj, Formatting.Indented);

                logService.Log(telemetry);
                return true;


        }

        public bool CheckIfTelemetryLogExists()
        {
            string directory = config.GetLogDirectory();
            string fileName = DateTime.Now.ToString(config.GetDateTimeFormat()) + config.GetTelemetryLogExtention();
            string path = Path.Combine(directory, fileName);

            if (File.Exists(path))
            {
                return true;
            }
            
            return false;
        }


        public void CreateTelemetryFile()
        {
            if (CheckIfTelemetryLogExists() == false)
            {
                logService.CreateTelemetryLog();

            }

        }
        /*
         
        public bool CheckIfErrorLogExists()
        {
            string directory = config.GetLogDirectory();
            string fileName = date + config.GetErrorLogExtension();
            string path = Path.Combine(directory, fileName);

            if (File.Exists(path))
            {
                return true;
            }

            return false;
        }
      public void CreateErrorFile()
      {
          if (CheckIfErrorLogExists() == false)
          {
              logService.CreateErrorLog();
          }
      }

 
      public string GetTelemetryLogs(string fileName)
      {

          string info = logService.ReadTelemetryLog(fileName);

          return info;
      }

      /*

      /// <summary>
      /// This method checks to see if user has opted in or out of telemetry collection.
      /// </summary>
      /// <param name="user">user object which contains boolean that represents choice of telemetry collection.</param>
      /// <returns></returns>
      public bool ValidateTelemetry(User user)
      {

          if (user.OptedIn == true)
          {
              return true;
          }
          else
          {
              return false;
          }
      }
      /// <summary>
      /// This method checks the count of how many logs have been recorded.
      /// </summary>
      /// <param name="count">static variable that keeps track of how many logs have been logged.</param>
      /// <returns></returns>
      public bool checkCount(int count)
      {
          if(count == 100)
          {
              return false;
          }else
          {
              Console.WriteLine("100 Logs have been recorded. Contact System Administrator.");
          }


      }


       */

    }

}
