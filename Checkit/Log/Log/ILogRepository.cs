using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
    interface ILogRepository
    {
        void LogTelemetry(string description);
        void LogError(string description);
        List<string> GetLog(string file);

    }
}
