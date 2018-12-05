using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace CheckIt
{
    

    /// <summary>
    /// Summary description for Class1
    /// </summary>
    /// 

    public class PCheck
    {
        static HttpClient client = new HttpClient();
        private static readonly string baseURL = "https://api.pwnedpasswords.com/range/";
        //static string results;

        public static string[] Check(string Password)
        {
            //Send a query to the API - Sends only the first 5 digits of hashed password. 0 Indicates the start position, and 5 the length of desires string
            Uri siteURi = new Uri(baseURL + Password);
            var searchResultsString = client.GetStringAsync(siteURi).Result;
            var results = searchResultsString.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries); 
            //PCheck p = new PCheck();
            //p.setResults(results);
            return results;
   
        }
        //public void setResults(string s)
       // {
            //results = s;
        //}
        //public string getResults()
        //{
            //return results;
       // }

 
    }
}
