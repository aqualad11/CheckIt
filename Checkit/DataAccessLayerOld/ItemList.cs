using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIt.DataAccessLayer
{
    public class ItemList
    {
        //[Key]
        public Guid itemID;
        //[ForeignKey("Client")]
        public Guid clientID;
        public Client Client;
    }
}