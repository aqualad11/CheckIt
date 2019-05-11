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
        private LogRepository logRepo;
        private Config config = new Config();

        public LogService()
        {
        }
        public LogService(string filename)
        {
            logRepo = new LogRepository(filename);
        }

        public void Log(string description)
        {
            logRepo.Log(description);
        }
        public void CreateTelemetryLog()
        {
            logRepo = new LogRepository(DateTime.UtcNow.ToString(config.GetDateTimeFormat()) + config.GetTelemetryLogExtension());
        }

        public void CreateErrorLog()
        {
            logRepo = new LogRepository(DateTime.UtcNow.ToString(config.GetDateTimeFormat()) + config.GetErrorLogExtension());
        }
        /*
        public string ReadTelemetryLog(string fileName)
        {
            return logRepo.ReadTelemetryLog(fileName);
        }
        */
    }
}
