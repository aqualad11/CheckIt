using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer
{
    /// <summary>
    /// This poco class represents a telemetry object, which will be used to logged data.
    /// </summary>
    public class Telemetry
    {
        public string userID { get; set; }
        public string timeStamp { get; set; } //TODO: change to DateTime object, only convert to string right before logging.
        public string description { get; set; }

    }
}
