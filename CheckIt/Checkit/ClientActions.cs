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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid clientActionID { set; get; }
        public String action { set; get; }
        [Key, Column(Order = 1)]
        [ForeignKey("Client")]
        public Guid clientID { get; set; }
        public Client Client { get; set; }

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
