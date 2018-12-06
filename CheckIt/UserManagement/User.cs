using System;
using System.Collections.Generic;
using System.Text;

namespace CheckIt.UserManagement
{
    public class User
    {

        public long userID { set; get; }
        public String clientID { set; get; }
        public long parentID { set; get; }
        public int height { set; get; }
        public String email { set; get; }
        public String fName { set; get; }
        public String lName { set; get; }
        public String accountType { set; get; }
        public Boolean firstLogin { set; get; }
        public Boolean active { set; get; }
        public DateTime DoB { set; get; }
        public String locCity { set; get; }
        public String locState { set; get; }
        public String locCountry { set; get; }
        public List<String> actions { set; get; }
        public virtual List<Item> itemList { set; get; }

        public User()
        {

        }

        public User(String email, String first, String last, DateTime dob, String atype, String city, String state, String country,List<String> actions, String client, int height, long userID, long parentID )
        {
            this.email = email;
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
            this. active = true;
            this.height = height;
            this.actions = actions;
            this.itemList = new List<Item>();
            this.userID = userID;
            this.clientID = client;
            this.parentID = parentID;

        }


    }
    
}