using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CheckIt.DataAccessLayer
{
    public class User
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid userID { get; set; }

        //TODO: make userEmail PK and redo dependencies
        //[Key, Column(Order = 1)]
        //[Index(IsUnique = true)]
        public string userEmail { get; set; }
        //setting up parent recursion
        public Guid? parentID { get; set; }
        [ForeignKey("parentID")]
        public virtual User Parent { get; set; }

        //setting up client
        public Guid? clientID { get; set; }
        [ForeignKey("clientID")]
        public virtual Client client { get; set; }

        public Guid? ssoID { get; set; }

        public int height { get; set; }

        public string accountType { get; set; }
        public bool active { get; set; }
       


        //[ForeignKey("UserActions")]
        public virtual List<UserAction> userActions { get; set; }
        

        public User()
        {
        }

        //creates normal user with height of 2
        public User(string email, string atype, Guid? clientID, Guid? parentID, Guid? ssoID)
        {
            userEmail = email;
            accountType = atype;
            this.clientID = clientID;
            height = 2;
            active = true;
            this.parentID = parentID;
            this.ssoID = ssoID;
            userActions = new List<UserAction>();
            
        }

    }

}