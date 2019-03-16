using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class Logger : ILog
    {
        string connectionString = string.Empty;
        public override void TelLog(string message, Guid userID, DateTime login, DateTime logout, DateTime pageVisit, IPAddress userIP, string location)
        {
            lock (lockObj)
            {
                //Code to log data to the MongoDB
            }
        }
    }
}
