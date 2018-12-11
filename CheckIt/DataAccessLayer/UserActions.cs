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
        //[Key,Column(Order =0)]
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid actionID { set; get; }
        public String action { set; get; }
        [Key,Column(Order =1)]
        [ForeignKey("User")]
        public Guid userID { get; set; }
        public User User { get; set; }

        

        public UserAction(Guid userID, String act)
        {
            this.userID = userID;
            this.action = act;

        }

        public UserAction()
        {

        }
    }
}
