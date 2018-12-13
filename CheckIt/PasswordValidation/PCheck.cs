using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace PasswordValidation
{
    

    /// <summary>
    /// Summary description for Class1
    /// </summary>
    /// 

    public class PCheck
    {
        static HttpClient client = new HttpClient();
        private static readonly string baseURL = "https://api.pwnedpasswords.com/range/";
        public static async Task<string[]> Check(string Password)
        {
            //Send a query to the API - Sends only the first 5 digits of hashed password.
            Uri siteURi = new Uri(baseURL + Password);
			//Create a variable to hold the result of the API call in the form of a string.
            var searchResultsString = await client.GetStringAsync(siteURi);
			// Create results variable and set it to the results of the response from the API.
			// Note - the Split methods splits the results with "\r\n" - this is used as a new line character in Window.
			// Note - the next call is part of the method param - it states to not keep empty array elemenets of the substring.
			var results = searchResultsString.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries); 
			//Return the resulted String[]
            return results;
        }
    }
}
