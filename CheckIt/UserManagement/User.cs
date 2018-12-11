using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckIt.UserManagement
{
    //TODO: Seperate Registration Parameters that are rarely used (dob, location, QAs)
    //      OR 
    //      add seperate Query call for desired user object
    //ASKVONG
    public class User
    {
        public class QA
        {
            public String question { set; get; }
            public String answer { set; get; }
            public QA(String q, String a)
            {
                question = q;
                answer = a;
            }
        }

		public int userID { get; set; }
		[ForeignKey("Client")]
		public int clientID { get; set; }
        public String email { set; get; }
        public String fName { set; get; }
        public String lName { set; get; }
        public DateTime DoB { set; get; }
		[ForeignKey("User")]
		public int parentID { get; set; }
        public String accountType { set; get; }
        public Boolean active { set; get; }
        public String locCity { set; get; }
        public String locState { set; get; }
        public String locCountry { set; get; }
        public List<String> actions;
        public List<QA> securityQA;

        public User()
        {

        }

        public User(String email, String first, String last, DateTime dob, String atype, String city, String state, String country, List<QA> quesans)
        {
            this.email = email;
            this.fName = first;
            this.lName = last;
            this.DoB = dob;
            this.accountType = atype;
            this.locCity = city;
            this.locState = state;
            this.locCountry = country;
            foreach (QA qua in quesans)
            {
                //this.securityQA.Insert(qua);
            }
        }


    }
    
}