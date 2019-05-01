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
            //Log instances, NOTE: each controller will have a seperate log instance
            LogManager tcontroller1 = new LogManager();
            LogManager tcontroller2 = new LogManager();
            LogManager eController1 = new LogManager();
            LogManager eController2 = new LogManager();

            //Telemetry Log Data. NOTE: this information would be grabbed from the frontend and passed to the backend through axios calls.
            string uid = "35262";
            string ipAddress = "IP Address: 47.155.230.156";
            string location = "Location: Long Beach, California";
            string pageVisit = "Page visited: Contact Us";
            string functionExe = "Function: Clicked Email Us";


            var info1 = new Telemetry
            {
                userID = uid,
                dateTime = DateTime.UtcNow.ToString(config.GetDateTimeFormat()),
                description = "user has logged in"

            };

            var info2 = new Telemetry
            {
                userID = uid,
                dateTime = DateTime.UtcNow.ToString(config.GetDateTimeFormat()),
                description = ipAddress

            };

            var info3 = new Telemetry
            {
                userID = uid,
                dateTime = DateTime.UtcNow.ToString(config.GetDateTimeFormat()),
                description = location

            };

            var info4 = new Telemetry
            {
                userID = uid,
                dateTime = DateTime.UtcNow.ToString(config.GetDateTimeFormat()),
                description = pageVisit

            };

            var info5 = new Telemetry
            {
                userID = uid,
                dateTime = DateTime.UtcNow.ToString(config.GetDateTimeFormat()),
                description = functionExe

            };

            var info6 = new Telemetry
            {
                userID = uid,
                dateTime = DateTime.UtcNow.ToString(config.GetDateTimeFormat()),
                description = "user has logged out"

            };
            var info7 = new Telemetry
            {
                userID = uid,
                dateTime = DateTime.UtcNow.ToString(config.GetDateTimeFormat()),
                description = "user has timed out"

            };


            //Logging action
            tcontroller1.LogTelemetry(info1);
            tcontroller1.LogTelemetry(info2);
            tcontroller1.LogTelemetry(info3);
            tcontroller1.LogTelemetry(info4);
            tcontroller2.LogTelemetry(info5);
            tcontroller2.LogTelemetry(info6);
            tcontroller2.LogTelemetry(info7);

            //Error Log Data
            try
            {
                divide(4, 0);
            }
            catch (Exception ex)
            {
                //log action
                eController1.LogError(uid,ex);
                eController2.LogError(uid, ex);
            }

            //Read logs to a list, print list
            List<string> logList = new List<string>();

            Console.WriteLine("------TELEMETRY LOGS-------");
            logList = tcontroller1.GetLog("05-01-2019_Telemetry.json");
            logList.ForEach(i => Console.WriteLine("{0}\t", i));

            Console.WriteLine("------ERROR LOGS-------");
            logList = eController1.GetLog("05-01-2019_Error.json");
            logList.ForEach(i => Console.WriteLine("{0}\t", i));

            Console.ReadLine();

        }

        public static int divide(int a, int b)
        {
            return a / b;
        }
    }
}
