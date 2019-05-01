using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheckIt.WebApi_CheckIt.Models
{
    public class LoginDTO
    {
        [Required]
        public string ssoID { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public long timeStamp { get; set; }
        [Required]
        public string signature { get; set; }

        public LoginDTO() { }

        public string PreSignatureString()
        {
            string acc = "";
            acc += "email=" + email + ";";
            acc += "ssoUserId=" + ssoID + ";";
            acc += "timestamp=" + timeStamp + ";";
            return acc;
        }
    }
}