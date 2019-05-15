using System;
using System.Collections.Generic;
using CheckIt.ServiceLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIt.UnitTests
{
    [TestClass]
    public class SignatureServiceTest
    {
        [TestMethod]
        public void SignValid()
        {
            //Arrange
            var sigService = new SignatureService();
            string ssoID = "9BC5F4AD-569B-44DA-8FCE-AF02DA88985F";
            string email = "example9@gmail.com";
            string timestamp = "1556419593286";

            var payload = new Dictionary<string, string>()
            {
                { "ssoUserId", ssoID },
                { "email", email },
                { "timestamp", timestamp }
            };

            //Act 
            string signedPayload = sigService.Sign(payload);

            //Assert
            Assert.IsNotNull(signedPayload);
        }
    }
}
