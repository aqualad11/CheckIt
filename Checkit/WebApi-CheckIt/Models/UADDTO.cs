using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheckIt.WebApi_CheckIt.Models
{
    public class UADDTO
    {
        [Required]
        public string chartName { get; set; }
        [Required]
        public string jwt { get; set; }

        public UADDTO() { }
    }
}