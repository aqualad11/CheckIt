using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
    public class Telemetry
    {
        public string userID { get; set; }
        public string dateTime { get; set; }
        public string description { get; set; }

        //at login specify ip address and location of user
        // e.g. stringFormat("user id: " + user id + "user logged in" + ipAddress + location )
        // location and ip address will come from get request to URL passed by a post to backend.
    }
}
