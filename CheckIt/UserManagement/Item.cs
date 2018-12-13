using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.UserManagement
{
    public class Item
    {
        public long itemID;
        public String itemName;
        public Double price;

        public Item(long itemID, String name, Double price)
        {
            this.itemID = itemID;
            this.itemName = name;
            this.price = price;
        }
    }
}
