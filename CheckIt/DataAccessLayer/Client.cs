using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckIt.DataAccessLayer
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid clientID { get; set; }

        public string name { get; set; }
        //List of users associated with client
        public virtual List<User> user { get; set; }
        //List of ClientActions associated with each client 
        public virtual List<ClientAction> actions { get; set; }

        public Client()
        {

        }
    }
}
