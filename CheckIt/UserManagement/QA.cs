using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.UserManagement
{
    public class QA
    {
        public String question1 { set; get; }
        public String answer1 { set; get; }
        public String question2 { set; get; }
        public String answer2 { set; get; }
        public String question3 { set; get; }
        public String answer3 { set; get; }

        public QA(String q1, String a1, String q2, String a2, String q3, String a3)
        {
            this.question1 = q1;
            this.question2 = q2;
            this.question3 = q3;
            this.answer1 = a1;
            this.answer2 = a2;
            this.answer3 = a3;
        }

    }

}
