using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CheckIt.DataAccessLayer.Repositories
{
    /// <summary>
    /// This class is used to write, read, and delete log files.
    /// </summary>
    public class LogRepository : ILogRepository
    {
        private readonly Config config;
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
            directory = config.LOG_DIRECTORY;
            telFileName = DateTime.UtcNow.ToString(config.DATE_FORMAT) + config.TEL_LOG_EXT;
            errFileName = DateTime.UtcNow.ToString(config.DATE_FORMAT) + config.ERROR_LOG_EXT;
            telPath = Path.Combine(directory, telFileName);
            errPath = Path.Combine(directory, errFileName);
        }

        /// <summary>
        /// This method uses a StreamWriter object to write telemetry data to a file
        /// </summary>
        /// <param name="message">text to be written</param>
        public bool LogTelemetry(string message)
        {
            try
            {
                if (!File.Exists(telPath))
                {
                    using (StreamWriter tLogWriter = File.CreateText(telPath))
                    {
                        tLogWriter.WriteLine(message);
                        tLogWriter.Flush();
                    }
                    return true;
                }
                    using (StreamWriter tLogWriter = File.AppendText(telPath))
                    {
                        tLogWriter.WriteLine(message);
                        tLogWriter.Flush();
                    }
                    return true;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found! " + e.Message);
            }
            return false;
        }
        /// <summary>
        /// This method uses a StreamWriter object to write error data to a file
        /// </summary>
        /// <param name="message">text to be written</param>
        public bool LogError(string message)
        {
            try
            {
                if (!File.Exists(errPath))
                {
                    using (StreamWriter eLogWriter = File.CreateText(errPath))
                    {
                        eLogWriter.WriteLine(message);
                    }
                    return true;
                }
                    using (StreamWriter eLogWriter = File.AppendText(errPath))
                    {
                        eLogWriter.WriteLine(message);
                    }
                    return true;
            }
            catch (FileNotFoundException e) //NEVER GOING TO HIT THIS EX change exception
            {
                Console.WriteLine("File not found! " + e.Message); //IN PRODUCTION, NEVER DO CONSOLE.WRITELINE //ALTERNATIVE: ACTUALLY HANDLE THE ERROR.
            }

            return false;
        }

        /// <summary>
        /// Method which checks for file, then reads the contents of the file into a list.
        /// </summary>
        /// <param name="file">name of the file in format mm-dd-yyyy_type.json // type is either "Error" or "Telemetry"</param>
        /// <returns></returns>
        public List<string> GetLog(string file)
        {
            string path = Path.Combine(directory + file);
            List<string> logs = new List<string>(); 
            //BEST: USE MEMORY STREAM, LOAD INTO MEM STREAM 
            //BETTER: INSTEAD OF LIST USE STRING BUILDER: MEM EFFICIENT WAY TO STORE STRINGS

            try
            {
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
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not does exist. " + e.Message);
            }

            return logs;
        }
        /// <summary>
        /// Method which deletes a given filename.
        /// </summary>
        /// <param name="file"></param>
        public bool DeleteLog(string file)
        {
            try
            {
                string path = directory + file;
                File.Delete(path); //HOVER OVER DELETE TO FIND EXCEPTIONS
                return true;
            }
            catch (IOException e) //all other exceptions will bubble up
            {
                Console.WriteLine("File not found! " + e.Message);
                
            }
            return false;
        }
    }
}
