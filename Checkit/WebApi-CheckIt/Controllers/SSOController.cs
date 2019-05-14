using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheckIt.ManagerLayer;
using CheckIt.ServiceLayer;
using CheckIt.DataAccessLayer;
using CheckIt.WebApi_CheckIt.Models;

namespace CheckIt.WebApi_CheckIt.Controllers
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
        public HttpResponseMessage SSOLaunch([FromBody] SSORequestDTO request)
        {
            
            var response = new HttpResponseMessage();
            if(!ModelState.IsValid || request == null)
            {
                response.Content = new StringContent("Invalid request payload.");
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            
            Guid ssoID;
            
            
            //check id is correct format
            try
            {
                ssoID = Guid.Parse(request.ssoUserId); 
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

                    if(token == null)
                    {
                        response.Content = new StringContent("Token is null");
                        response.StatusCode = HttpStatusCode.Conflict;
                        return response;
                    }
                    
                    //Create Redirect response
                    //TODO: make sure our redirect is to our site
                    string redirectUrl = "https://checkitspyderz.net";//https://checkitspyderz.net/home?token=1297yrh4fuhshf
                    response = Request.CreateResponse(HttpStatusCode.Moved);
                    response.Headers.Location = new Uri(redirectUrl);
                    return response;
                }
                catch (InvalidRequestSignature e)
                {
                    //Send the unathorized response with message of exception
                    response.Content = new StringContent(e.Message);
                    response.StatusCode = HttpStatusCode.Unauthorized;
                    return response;
                }
            }
        }

        [HttpGet]
        [Route("sso/healthcheck")]
        public HttpResponseMessage SSOHealthCheck()
        {
            var response = new HttpResponseMessage();
            var ping = new Ping();
            var result = ping.Send("13.52.90.158");

            using (var db = new DataBaseContext())
            {
                bool databaseExists = db.Database.Exists();
                if (result.Status == IPStatus.Success && databaseExists)
                {
                    response.StatusCode = HttpStatusCode.OK;
                }
                else if(result.Status != IPStatus.Success)
                {
                    response.Content = new StringContent("status failed. Status: " + result.Status);
                    response.StatusCode = HttpStatusCode.Conflict;
                }else if(!databaseExists)
                {
                    response.Content = new StringContent("user is null. user = ");
                    response.StatusCode = HttpStatusCode.Conflict;
                }
            }

            return response;
         
        }

        [HttpPost]
        [Route("sso/logout")]
        public HttpResponseMessage SSOLogout([FromBody] SSORequestDTO request)
        {

            var response = new HttpResponseMessage();
            if (!ModelState.IsValid || request == null)
            {
                response.Content = new StringContent("Invalid request payload.");
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }


            Guid ssoID;
            //check id is correct format
            try
            {
                ssoID = Guid.Parse(request.ssoUserId);
            }
            catch (Exception)
            {
                response.Content = new StringContent("Invalid Guid format");
                response.StatusCode = HttpStatusCode.Conflict;
                return response;
            }

            using (var db = new DataBaseContext())
            {
                try
                {
                    //Logout user from any instances
                    LogoutManager logoutManager = new LogoutManager(db);
                    logoutManager.SSOLogout(ssoID, request.email, request.timeStamp, request.signature);

                    //make response
                    response.StatusCode = HttpStatusCode.OK;
                    return response;
                }
                catch (InvalidRequestSignature e)
                {
                    //TODO: log
                    response.Content = new StringContent(e.Message);
                    response.StatusCode = HttpStatusCode.Unauthorized;
                    return response;
                }
                catch (UserDoesNotExistException e)
                {
                    //TODO: log
                    response.Content = new StringContent(e.Message);
                    response.StatusCode = HttpStatusCode.Conflict;
                    return response;
                }
            }
        }

        [HttpPost]
        [Route("sso/delete")]
        public HttpResponseMessage SSODelete([FromBody] SSORequestDTO request)
        {
            var response = new HttpResponseMessage();
            if (!ModelState.IsValid || request == null)
            {
                //TODO: log
                response.Content = new StringContent("Invalid request payload.");
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }


            Guid ssoID;
            //check id is correct format
            try
            {
                ssoID = Guid.Parse(request.ssoUserId);
            }
            catch (Exception)
            {
                //TODO: Log
                response.Content = new StringContent("Invalid Guid format");
                response.StatusCode = HttpStatusCode.Conflict;
                return response;
            }

            using (var db = new DataBaseContext())
            {
                try
                {
                    //Remove user from database
                    UserManager userManager = new UserManager(db);
                    userManager.DeleteUserFromSSO(ssoID, request.email, request.timeStamp, request.signature);

                    //make response
                    response.StatusCode = HttpStatusCode.OK;
                    return response;
                }
                catch (InvalidRequestSignature e)
                {
                    //TODO: log
                    response.Content = new StringContent(e.Message);
                    response.StatusCode = HttpStatusCode.Unauthorized;
                    return response;
                }
                catch (UserDoesNotExistException e)
                {
                    //TODO: log
                    response.Content = new StringContent(e.Message);
                    response.StatusCode = HttpStatusCode.OK;
                    return response;
                }
            }
        }

    }
}
