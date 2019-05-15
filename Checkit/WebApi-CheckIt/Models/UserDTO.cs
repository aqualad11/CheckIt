using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CheckIt.DataAccessLayer;

namespace CheckIt.WebApi_CheckIt.Models
{
    public class UserDTO
    {
        [Required]
        public User user { get; set; }
        [Required]
        public string jwt { get; set; }

        public UserDTO() { }
    }
}