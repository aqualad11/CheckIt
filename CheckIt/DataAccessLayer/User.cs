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
        public String userEmail { set; get; }
        public long userID { set; get; }
        public String clientName { set; get; }
        [ForeignKey("parentEmail")]
        public virtual User Parent { set; get; }
        public string parentEmail { set; get; }
        public int height { set; get; }
        public String fName { set; get; }
        public String lName { set; get; }
        public String accountType { set; get; }
        public Boolean firstLogin { set; get; }
        public Boolean active { set; get; }
        public DateTime? DoB { set; get; }
        public String locCity { set; get; }
        public String locState { set; get; }
        public String locCountry { set; get; }

        [ForeignKey("UserActions")]
        public virtual List<int> ActionIds { get; set; }
        
        

        public User()
        {

        }

        public User(String email, String first, String last, DateTime? dob, String atype, String city, String state, 
            String country, String client, int height, long userID, string parentEmail)
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
            this.userID = userID;
            this.clientName = client;
            this.parentEmail = parentEmail;

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