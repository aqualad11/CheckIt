using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CheckIt.DataAccessLayer;

namespace CheckIt.WebApi_CheckIt.Models
{
    public class ItemsDTO
    {
        [Required]
        public string jwt { get; set; }
        [Required]
        public List<Item> items { get; set; }

        public ItemsDTO() { }
    }
}