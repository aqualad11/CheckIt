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
        private StreamWriter logWriter;
        //private StreamReader logReader;
        private Config config = new Config();
        private string directory;

        public LogRepository()
        {

        }

        public LogRepository(string fileName)
        {

            directory = config.GetLogDirectory();
            logWriter = new StreamWriter(Path.Combine(directory, fileName), true);
            //logReader = new StreamReader(Path.Combine(directory, fileName), true);
           
        }


        /// <summary>
        /// This method uses a StreamWriter object to write the log description to a file
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
           logWriter.WriteLine(message);
           logWriter.Close();
        }

        /*
        public string ReadTelemetryLog()
        {
            var jsonFile = logReader.ReadToEnd();
            List<Telemetry> contents = JsonConvert.DeserializeObject<Telemetry>(jsonFile);
            return jsonFile;
        }

     */

    }
}
