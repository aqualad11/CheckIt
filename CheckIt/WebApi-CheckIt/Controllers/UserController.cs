using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheckIt.PasswordValidation;

namespace WebApi_Checkit.Controllers
{
    public class UserController : ApiController
    {

        // GET api/User
        [HttpGet]
        [Route("api/user")]
        public IHttpActionResult Get()
        { 
            return Ok("successful get");
        }

        // GET api/User/5
        [HttpGet]
        [Route("api/user/{id}")] //route specific
        public IHttpActionResult Get(int id)
        {
            return Ok();

   
        }

        // POST api/User
        [HttpPost]
        [Route("api/user")]
        public async System.Threading.Tasks.Task<IHttpActionResult> PostPasswordAsync([FromBody] string password) //using a POCO to represent request
        {  
            int pwned = await ValidationHandler.ValidatePassword(password);
            if (pwned == 1) {
                return Content((HttpStatusCode)401, "That password has been hacked before. Please choose a more secure password.");
            }
            else {
                return Ok("Password is safe to use.");
            }
        }

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