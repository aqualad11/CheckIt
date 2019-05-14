
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApi_CheckIt.Models
{
    public class SearchDTO
    {

        public string searchQuery { get; set; }

        public string userToken { get; set; }

    }
}