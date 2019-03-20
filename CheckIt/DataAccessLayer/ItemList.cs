﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer
{
    public class ItemList
    {
        [Key,Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid itemListID { get; set; }
        //public ulong itemListId { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        public Guid userID { get; set; }
        [ForeignKey("userID")]
        public virtual User user { get; set; }

        //setting up itemID
        [Key, Column(Order = 2)]
        [Required]
        public Guid itemID { get; set; }
        [ForeignKey("itemID")]
        public virtual Item item { get; set; }

        public ItemList()
        {
        }

        public ItemList(Guid userID, Guid itemID)
        {
            this.userID = userID;
            this.itemID = itemID;
        }
    }
}
