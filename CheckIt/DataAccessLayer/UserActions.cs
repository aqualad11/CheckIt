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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int actionID { set; get; }
        
        public String actionEmail { set; get; }
   
        public String action { set; get; }

        public UserAction(String name, String act)
        {
            this.actionEmail = name;
            this.action = act;

        }

        public UserAction()
        {

        }
    }
}
