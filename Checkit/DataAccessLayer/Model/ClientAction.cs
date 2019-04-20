using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckIt.DataAccessLayer
{
    public class ClientAction
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Client")]
        public Guid clientID { get; set; }
        public Client Client { get; set; }

        [Key,Column(Order = 1)]
        public string action { set; get; }

        public ClientAction(Guid clientID, string action)
        {
            this.clientID = clientID;
            this.action = action;
        }

        public ClientAction()
        {
        }
    }
}