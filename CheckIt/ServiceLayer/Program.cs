using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIt.ServiceLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "HelloWorld";
            byte[] salt = PasswordService.CreateSalt();
            string passwordHash = PasswordService.GetPasswordHash(password, salt);
            Console.WriteLine("passwordHash = " + passwordHash);

            string salty = Convert.ToBase64String(salt);
            byte[] salt2 = Convert.FromBase64String(salty);
            string passwordHash2 = PasswordService.GetPasswordHash(password, salt2);
            Console.WriteLine("PasswordHash2 = " + passwordHash2);
            Console.WriteLine("salt = " + salty);
            Console.WriteLine(passwordHash == passwordHash2);

            Console.ReadKey();
        }
    }
}
