using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Log
{

    class Program
    {
        static void Main(string[] args)
        {

            Config config = new Config();

            string fileName = DateTime.UtcNow.ToString(config.GetDateTimeFormat()) + config.GetTelemetryLogExtention();
            string tomorrow = "05-01-2019" + config.GetTelemetryLogExtension();

            LogManager tlog = new LogManager(fileName);
            LogManager tlog1 = new LogManager(tomorrow);
            
            //Telemetry Log Data
            string uid = "35262";            
            var info1 = new Telemetry
            {
                userID = uid,
                dateTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt "),
                description = "user has logged in"

            };

            tlog.LogTelemetry(info1);
            tlog1.LogTelemetry(info1);





            /*
            try
            {
                divide(4, 0);
            }
            catch (Exception ex)
            {

                elogger.LogError(uid,ex);
            }

            */

        }

        public static int divide(int a, int b)
        {
            return a / b;
        }
    }
}
