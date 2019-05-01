using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheckIt.ManagerLayer;
using CheckIt.ServiceLayer;
using CheckIt.DataAccessLayer;
using CheckIt.WebApi_CheckIt.Models;

namespace WebApi_CheckIt.Controllers
{
    public class SSOController : ApiController
    {
        /// <summary>
        /// Route called by SSO when they launch CheckIt
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("sso/launchapp")]
        public HttpResponseMessage SSOLaunch([FromBody] LoginDTO request)
        {
            var response = new HttpResponseMessage();
            if(ModelState.IsValid || request == null)
            {
                response.Content = new StringContent("Invalid request payload.");
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            Guid ssoID;
            //check id is correct format
            try
            {
                ssoID = Guid.Parse(request.ssoID); 
            }catch (Exception)
            {
                response.Content = new StringContent("Invalid Guid format");
                response.StatusCode = HttpStatusCode.Conflict;
                return response;
            }
            
            using (var db = new DataBaseContext())
            {
                try
                {
                    //Create manager
                    LoginManager lm = new LoginManager(db);

                    //Validate request and login user
                    string token = lm.SSOLogin(ssoID, request.email, request.timeStamp, request.signature);

                    //Create Redirect response
                    string redirectUrl = "http://www.checkit.gq/#/launch?token=" + token;
                    response = Request.CreateResponse(HttpStatusCode.Moved);
                    response.Headers.Location = new Uri(redirectUrl);
                    return response;
                }
                catch (InvalidRequestSignature e)
                {
                    //Send the unathorized rsponse with message of exception
                    response.Content = new StringContent(e.Message);
                    response.StatusCode = HttpStatusCode.Unauthorized;
                    return response;
                }
            }
            
        }


    }
}
