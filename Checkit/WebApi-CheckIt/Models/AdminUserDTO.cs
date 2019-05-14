using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CheckIt.WebApi_CheckIt.Models
{
    public class AdminUserDTO
    {
        public string userID { get; set; }
        [Required]
        public string userEmail { get; set; }
        public string parentID { get; set; }
        public string clientID { get; set; }
        public int height { get; set; }
        public bool active { get; set; }
        public string accountType { get; set; }
        [Required]
        public string jwt { get; set; }

        public AdminUserDTO() { }

    }
}