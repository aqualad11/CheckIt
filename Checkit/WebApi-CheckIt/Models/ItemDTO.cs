using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CheckIt.WebApi_CheckIt.Models
{
    public class ItemDTO
    {
        [Required]
        public string itemName { get; set; }
        [Required]
        public string price { get; set; }
        
        public string url { get; set; }
        public string picKey { get; set; }

        public string jwt { get; set; }

        public ItemDTO() { }

    }
}