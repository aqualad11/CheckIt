using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.UserManagement
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
}
