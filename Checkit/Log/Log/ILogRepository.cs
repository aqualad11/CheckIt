using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
    interface ILogRepository
    {
        void Log(string description);
        //List<Telemetry> ReadTelemetryLog();

        /*
        void Read(string fileName);
        
        void Delete(string fileName);
        */
    }
}
