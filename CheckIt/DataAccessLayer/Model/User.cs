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

        public int height { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string accountType { get; set; }
        public bool firstLogin { get; set; }
        public bool active { get; set; }
        public DateTime? DoB { get; set; }
        public string locCity { get; set; }
        public string locState { get; set; }
        public string locCountry { get; set; }

        //[ForeignKey("UserActions")]
        public virtual List<UserAction> userActions { get; set; }

        public string pwdHash { get; set; }
        public string salt { get; set; }

        public string question1 { get; set; }
        public string answer1 { get; set; }
        public string question2 { get; set; }
        public string answer2 { get; set; }
        public string question3 { get; set; }
        public string answer3 { get; set; }

        

        public User()
        {
        }

        //creates normal user with height of 2
        public User(string email, string first, string last, DateTime? dob, string atype, string city, string state,
            string country, Guid? clientID, Guid? parentID, string passwordHash, string salt, string q1, string a1,
            string q2, string a2, string q3, string a3)
        {
            userEmail = email;
            fName = first;
            lName = last;
            DoB = dob;
            accountType = atype;
            locCity = city;
            locState = state;
            locCountry = country;
            this.clientID = clientID;
            height = 2;
            active = true;
            firstLogin = true;
            this.parentID = parentID;
            userActions = new List<UserAction>();
            pwdHash = passwordHash;
            this.salt = salt;
            question1 = q1;
            answer1 = a1;
            question2 = q2;
            answer2 = a2;
            question3 = q3;
            answer3 = a3;
        }

    }

}