using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
/// <summary>
/// Poco class which represents an error object
/// </summary>
    public class Error
    {
        public string userID { get; set; } //current logged in user
        public string timeOfError { get; set; }//datetime of error
        public string errorMsg { get; set; } //message
        public string stackTrace { get; set; } //user request/action
        public string targetSite { get; set; } //target site

    }
}
