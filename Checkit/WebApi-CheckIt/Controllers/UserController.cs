using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CheckIt.DataAccessLayer;
using CheckIt.DataAccessLayer.Repositories;


namespace CheckIt.WebApi_CheckIt.Controllers
{
    public class UserController : ApiController
    {

        // GET api/User
        [HttpGet]
        [Route("api/user")]
        public String Get()
        { 
            return"Successful Get Without Parameters. Returned at: " + DateTime.Now;
        }

        // GET api/User/5
        [HttpGet]
        [Route("api/user/{id}")] //route specific
        public String Get(int id)
        {
            List<String> list = new List<String>();
            list.Add("Bryan");
            list.Add("Kunal");
            list.Add("Alex");
            list.Add("Jonathan");
            if (id <= 3 && id >= 0)
            {
                return list[id];
            }
            return "Index not found! Try again (0-3)";
        }

        [HttpGet]
        [Route("api/user/test")]
        public string TestDeploymentDB()
        {
            try
            {
                using (var db = new DataBaseContext())
                {
                    UserRepository ur = new UserRepository(db);
                    User user = ur.GetUserbyEmail("example1@gmail.com");
                    return user.userID.ToString();
                }
            }catch(Exception e)
            {
                return "Got to the backend, but had following error: " + e.GetType() + " " + e.Message;
            }
        }

        [HttpGet]
        [Route("api/user/login")]
        public IHttpActionResult CheckItLogin()
        {
            return Redirect("https://kfc-sso.com/#/login"); 
        }

        [HttpGet]
        [Route("api/user/register")]
        public IHttpActionResult CheckItRegister()
        {
            return Redirect("https://kfc-sso.com/#/register");
        }
        
        /*
        // POST api/User
        [HttpPost]
        [Route("api/user/post/{password}")]
        public async System.Threading.Tasks.Task<string> PostAsync(string password)
        {
            int pwned = await PasswordService.ValidatePassword(password);
            if (pwned == 1)
            {
                return "That password has been hacked before. Please choose a more secure password.";
            }
            else
            {
                return "That password is safe to use.";
            }
            //return "To confirm, you sent this password: " + password;
        }
        /*
        public async System.Threading.Tasks.Task<IHttpActionResult> PostPasswordAsync([FromBody] string password) //using a POCO to represent request
        {  
            int pwned = await PasswordService.ValidatePassword(password);
            if (pwned == 1) {
                return Content((HttpStatusCode)401, "That password has been hacked before. Please choose a more secure password.");
            }
            else {
                return Ok("Password is safe to use.");
            }
        }*/

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
            //users.Add(id, value);
        }

        // DELETE api/user/5
        public IHttpActionResult Delete(int id)
        {
            var response = new { id = id };
            return Ok(response);
        }

    }
}