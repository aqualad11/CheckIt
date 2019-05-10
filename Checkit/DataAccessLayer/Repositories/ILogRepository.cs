using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{/// <summary>
/// interface which declares methods for a log repository
/// </summary>
    interface ILogRepository
    {
        bool LogTelemetry(string description);
        bool LogError(string description);
        List<string> GetLog(string file);
        bool DeleteLog(string file);
    }
}
