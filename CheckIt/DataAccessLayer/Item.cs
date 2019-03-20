using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccessLayer
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid itemID { get; set; }
        public string ItemName { get; set; }
        public double price { get; set; }
        public string url { get; set; }
        public string picKey { get; set; }


        public Item()
        {
        }

        public Item(string name, double price, string url, string picKey)
        {
            ItemName = name;
            this.price = price;
            this.url = url;
            this.picKey = picKey;
        }

    }
}