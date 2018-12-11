using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordValidation;

namespace PasswordUnitTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public async Task TestPasswordPass()
		{
			//Act
			string password; // Create a password to be passed into the method. 
			int expected; // We assume that the incorrect password passed in will return 1 - 1 indicates that the password is insecure
			int actual; // The var that will call the method to see if what was actually was true is the same as expected.
						//Arrange
			password = "Hello123;"; //Assign password a value that is known the fail. 
			expected = 0; 
			actual = await ValidationHandler.ValidatePassword(password);
			//Assert
			Assert.AreEqual(expected, actual);
		}
		[TestMethod]
		public async Task TestPasswordFail()
		{
			//Act
			string password;
			int expected;
			int actual;
			//Arrange
			expected = 1;
			password = "Hello123"; //This password is a uncompromised password.
			actual = await ValidationHandler.ValidatePassword(password);
			//Assert
			Assert.AreEqual(expected, actual);
		}
		[TestMethod]
		public async Task TestPasswordNoParam()
		{
			//Act
			string password;
			int expected;
			int actual;
			//Arrange
			password = ""; //Sending in a password that is not long enough for the specified hash of PCheck
			expected = 3;
			actual = await ValidationHandler.ValidatePassword(password);
			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
