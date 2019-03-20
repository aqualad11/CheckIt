using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Text;

namespace DataAccessLayer
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

        public string pwdHash { get; set; }
        public string salt { get; set; }

        public string question1 { get; set; }
        public string answer1 { get; set; }
        public string question2 { get; set; }
        public string answer2 { get; set; }
        public string question3 { get; set; }
        public string answer3 { get; set; }

        //[ForeignKey("UserActions")]
        public virtual List<UserAction> userActions { get; set; }



        public User()
        {

        }

        public User(string email, string first, string last, DateTime? dob, string atype, string city, string state,
            string country, string client, Guid? parentID)
        {
            this.userEmail = email;
            this.fName = first;
            this.lName = last;
            this.DoB = dob;
            this.accountType = atype;
            this.locCity = city;
            this.locState = state;
            this.locCountry = country;
            this.height = 2;
            this.active = true;
            this.firstLogin = false;
            this.parentID = parentID;
            this.userActions = new List<UserAction>();

        }
        /*
        public void addAction(string action)
        {
            UserAction act = new UserAction(userEmail, action);
            actions.Add(act);
        }
        public void addAction(List<UserAction> list)
        {
            foreach (UserAction a in list)
            {
                actions.Add(a);
            }
        }
        public void removeAction(UserAction action)
        {
            if (actions.Contains(action))
            {
                actions.Remove(action);
            }
            else
            {
                Console.Write("No action to remove!");
            }
        }
        */

    }

}