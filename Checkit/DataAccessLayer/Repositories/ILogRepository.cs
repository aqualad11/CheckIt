using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer.Repositories
{/// <summary>
/// interface which declares methods for a log repository
/// </summary>
    public interface ILogRepository
    {
        bool LogTelemetry(string description);
        bool LogError(string description);
        List<string> GetLog(string file);
        bool DeleteLog(string file);
    }
}
