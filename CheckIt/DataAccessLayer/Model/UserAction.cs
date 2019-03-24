using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckIt.DataAccessLayer
{
    public class UserAction
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid actionID { set; get; }
        public string action { set; get; }
        [Key, Column(Order = 1)]
        [ForeignKey("User")]
        public Guid userID { get; set; }
        public User User { get; set; }



        public UserAction(Guid userID, string act)
        {
            this.userID = userID;
            action = act;

        }

        public UserAction()
        {

        }
    }
}