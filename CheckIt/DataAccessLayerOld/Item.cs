using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.DataAccessLayer
{
    public class Item
    {
       // [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid itemID { get; set; }
        public string ItemName { get; set; }

        /*
         * Price
         * URL
         * Picture?
        */

        public Item()
        {
        }      
        
    }
}