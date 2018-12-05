using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordValidation;

namespace PasswordUnitTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public async Task TestPassword()
		{
			string password; // Create a password to be passed into the method. 
			int expected = 1; // We assume that the incorrect password passed in will return 1 - 1 indicates that the password is insecure
			int actual; // The var that will call the method to see if what was actually was true is the same as expected.
		    //Act
			password = "Hello123"; //Assign password a value that is known the fail. 
			 //Arrange 
			actual = await ValidationHandler.ValidatePassword(password);
			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
