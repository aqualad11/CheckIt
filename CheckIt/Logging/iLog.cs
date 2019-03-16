using System;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Logging
{
    public abstract class ILog
    {
        protected readonly object lockObj = new object();
        public abstract void TelLog(string message, Guid userID, DateTime login, DateTime logout, DateTime pageVisit,/*DateTime functionAccessTimeStamp,*/ IPAddress userIP, string location);
        //public abstract void ErrLog(DateTime errorTime, string errorMessage, string lineNumber, Guid userID, string action);

    }
}
