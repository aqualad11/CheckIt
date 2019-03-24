using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Text;

namespace CheckIt.DataAccessLayer
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid userID { get; set; }

        public String userEmail { get; set; }
        //setting up parent recursion
        public Guid? parentID { get; set; }
        [ForeignKey("parentID")]
        public virtual User Parent { get; set; }

        //setting up client
        public Guid? clientID { get; set; }
        [ForeignKey("clientID")]
        public virtual Client client { get; set; }

        public int height { get; set; }
        public String fName { get; set; }
        public String lName { get; set; }
        public String accountType { get; set; }
        public Boolean firstLogin { get; set; }
        public Boolean active { get; set; }
        public DateTime? DoB { get; set; }
        public String locCity { get; set; }
        public String locState { get; set; }
        public String locCountry { get; set; }

        //[ForeignKey("UserActions")]
        public virtual List<UserAction> userActions { get; set; }



        public User()
        {

        }

        public User(String email, String first, String last, DateTime? dob, String atype, String city, String state,
            String country, String client, int height, Guid? parentID)
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
            this.active = true;
            this.height = height;
            //this.userID = userID;
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