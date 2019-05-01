using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;

namespace Log
{
    public class LogRepository : ILogRepository
    {
        private Config config; 
        private readonly string directory;
        private readonly string telFileName;
        private readonly string errFileName;
        private readonly string telPath;
        private readonly string errPath;

        /// <summary>
        /// This constructor inits a the config class, sets the directory and filenames of both telemetry and error logs, 
        /// such that it creates the path for both types of logs
        /// </summary>
        public LogRepository()
        {
            config = new Config();
            directory = config.GetLogDirectory();
            telFileName = DateTime.UtcNow.ToString(config.GetDateFormat()) + config.GetTelemetryLogExtension();
            errFileName = DateTime.UtcNow.ToString(config.GetDateFormat()) + config.GetErrorLogExtension();
            telPath = Path.Combine(directory, telFileName);
            errPath = Path.Combine(directory, errFileName);
        }

        /// <summary>
        /// This method uses a StreamWriter object to write telemetry data to a file
        /// </summary>
        /// <param name="message">text to be written</param>
        public void LogTelemetry(string message)
        {

            if (!File.Exists(telPath))
            { 
                using (StreamWriter logWriter = File.CreateText(telPath))
                {
                    logWriter.WriteLine(message);
                    logWriter.Flush();
                }
            }
            else if (File.Exists(telPath))
            {
                using (StreamWriter logWriter = File.AppendText(telPath))
                {
                      logWriter.WriteLine(message);
                      logWriter.Flush();
                }
            }
        }
        /// <summary>
        /// This method uses a StreamWriter object to write error data to a file
        /// </summary>
        /// <param name="message">text to be written</param>
        public void LogError(string message)
        {

            if (!File.Exists(errPath))
            {
                using (StreamWriter logWriter = File.CreateText(errPath))
                {
                    logWriter.WriteLine(message);
                    logWriter.Flush();
                }
            }
            else if (File.Exists(errPath))
            {
                using (StreamWriter logWriter = File.AppendText(errPath))
                {
                    logWriter.WriteLine(message);
                    logWriter.Flush();
                }
            }
        }
        /// <summary>
        /// Method which checks for file, then reads the contents of the file into a list.
        /// </summary>
        /// <param name="file">name of the file in format mm-dd-yyyy_type.json // type is either "Error" or "Telemetry"</param>
        /// <returns></returns>
        public List<string> GetLog(string file)
        {
            string path = directory + file;
            List<string> logs = new List<string>();

            if (File.Exists(path))
            {
                using (StreamReader logReader = File.OpenText(path))
                {
                    
                    string data = "";
                    while ((data = logReader.ReadLine()) != null)
                    {
                        logs.Add(data);
                    }
                }
                return logs;
            }
            else
            {
                Console.WriteLine(file + " Log does not exist.");
                return logs;
            }
            
        }
    }
}
