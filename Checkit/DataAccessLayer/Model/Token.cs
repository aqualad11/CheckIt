using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckIt.DataAccessLayer
{
    public class Token
    {
        [Key, Column(Order = 0)]
        [StringLength(450)]
        public string jwt { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("User")]
        public Guid userID { get; set; }
        public virtual User User { get; set; }

        public bool valid { get; set; }

        public Token() { }

        public Token(string jwt, Guid userID)
        {
            this.jwt = jwt;
            this.userID = userID;
            valid = true;
        }
    }
}
