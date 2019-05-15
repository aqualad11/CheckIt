using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheckIt.ManagerLayer;
using CheckIt.ServiceLayer;
using CheckIt.DataAccessLayer;
using CheckIt.DataAccessLayer.Repositories;
using CheckIt.WebApi_CheckIt.Models;

namespace CheckIt.WebApi_CheckIt.Controllers
{
    public class AdminController : ApiController
    {
        [HttpPost]
        [Route("api/admin/adduser")]
        public HttpResponseMessage AddUser([FromBody] AdminUserDTO adminUserDTO)
        {
            var response = new HttpResponseMessage();
            if (adminUserDTO.jwt == null)
            {
                response.Content = new StringContent("JWT is null.");
                response.StatusCode = HttpStatusCode.Conflict;
                return response;
            }

            using (var db = new DataBaseContext())
            {
                try
                {
                    TokenManager tokenManager = new TokenManager(db);

                    //Validate Token
                    string newJWT = tokenManager.ValidateToken(adminUserDTO.jwt);
                    //if jwt not valid redirect to SSO login
                    if (newJWT == null)
                    {
                        response = Request.CreateResponse(HttpStatusCode.Moved);
                        response.Content = new StringContent("https://kfc-sso.com/#/login");
                        return response;
                    }


                    AuthorizationManager authManager = new AuthorizationManager(db);
                    
                    //authorize action
                    if(!authManager.AuthorizeUserToUser(adminUserDTO.jwt, new Guid(adminUserDTO.userID),Actions.ADDUSER))
                    {
                        response.Content = new StringContent("Unauthorized to add user.");
                        response.StatusCode = HttpStatusCode.Unauthorized;
                        return response;
                    }

                    //create user
                    User user = new User()
                    {
                        userEmail = adminUserDTO.userEmail,
                        height = adminUserDTO.height,
                        accountType = adminUserDTO.accountType,
                        parentID = new Guid(adminUserDTO.parentID),
                        clientID = new Guid(adminUserDTO.clientID)
                    };

                    //Add user to database
                    UserManager userManager = new UserManager(db);
                    userManager.AddUser(user);

                    //create response
                    response.Content = new StringContent(newJWT);
                    response.StatusCode = HttpStatusCode.OK;
                    return response;
                }
                catch(Exception e)
                {
                    response.Content = new StringContent(e.Message);
                    response.StatusCode = HttpStatusCode.Conflict;
                    return response;
                }
            }
        }

        [HttpPost]
        [Route("api/admin/updateuser")]
        public HttpResponseMessage UpdateUser([FromBody] AdminUserDTO adminUserDTO)
        {
            var response = new HttpResponseMessage();
            if (adminUserDTO.jwt == null)
            {
                response.Content = new StringContent("JWT is null.");
                response.StatusCode = HttpStatusCode.Conflict;
                return response;
            }

            using (var db = new DataBaseContext())
            {
                try
                {
                    TokenManager tokenManager = new TokenManager(db);

                    //Validate Token
                    string newJWT = tokenManager.ValidateToken(adminUserDTO.jwt);
                    //if jwt not valid redirect to SSO login
                    if (newJWT == null)
                    {
                        response = Request.CreateResponse(HttpStatusCode.Moved);
                        response.Content = new StringContent("https://kfc-sso.com/#/login");
                        return response;
                    }

                    AuthorizationManager authManager = new AuthorizationManager(db);

                    //authorize action
                    if (!authManager.AuthorizeUserToUser(adminUserDTO.jwt, new Guid(adminUserDTO.userID), Actions.UPDATEUSER))
                    {
                        response.Content = new StringContent("Unauthorized to add user.");
                        response.StatusCode = HttpStatusCode.Unauthorized;
                        return response;
                    }

                    UserManager userManager = new UserManager(db);

                    //update user
                    User user = userManager.GetUser(new Guid(adminUserDTO.userID));
                    user.userEmail = adminUserDTO.userEmail;
                    user.height = adminUserDTO.height;
                    user.active = adminUserDTO.active;
                    user.accountType = adminUserDTO.accountType;
                    user.parentID = new Guid(adminUserDTO.parentID);
                    user.clientID = new Guid(adminUserDTO.clientID);

                    //update user on database
                    userManager.UpdateUser(user);

                    //return response\
                    response.Content = new StringContent(newJWT);
                    response.StatusCode = HttpStatusCode.OK;
                    return response;
                }
                catch (Exception e)
                {
                    response.Content = new StringContent(e.Message);
                    response.StatusCode = HttpStatusCode.Conflict;
                    return response;
                }
            }
        }

        [HttpPost]
        [Route("api/admin/deleteuser")]
        public HttpResponseMessage DeleteUser([FromBody] AdminUserDTO adminUserDTO)
        {
            var response = new HttpResponseMessage();
            if (adminUserDTO.jwt == null)
            {
                response.Content = new StringContent("JWT is null.");
                response.StatusCode = HttpStatusCode.Conflict;
                return response;
            }

            using (var db = new DataBaseContext())
            {
                try
                {
                    TokenManager tokenManager = new TokenManager(db);

                    //Validate Token
                    string newJWT = tokenManager.ValidateToken(adminUserDTO.jwt);
                    //if jwt not valid redirect to SSO login
                    if (newJWT == null)
                    {
                        response = Request.CreateResponse(HttpStatusCode.Moved);
                        response.Content = new StringContent("https://kfc-sso.com/#/login");
                        return response;
                    }

                    AuthorizationManager authManager = new AuthorizationManager(db);

                    //authorize action
                    if (!authManager.AuthorizeUserToUser(adminUserDTO.jwt, new Guid(adminUserDTO.userID), Actions.DELETEUSER))
                    {
                        response.Content = new StringContent("Unauthorized to add user.");
                        response.StatusCode = HttpStatusCode.Unauthorized;
                        return response;
                    }

                    //delete user from db
                    UserManager userManager = new UserManager(db);
                    userManager.DeleteUser(new Guid(adminUserDTO.userID));

                    //return response
                    response.Content = new StringContent(newJWT);
                    response.StatusCode = HttpStatusCode.OK;
                    return response;

                }
                catch (UserDoesNotExistException e)
                {
                    response.Content = new StringContent(e.Message);
                    response.StatusCode = HttpStatusCode.OK;
                    return response;
                }
                catch(Exception e)
                {
                    response.Content = new StringContent(e.Message);
                    response.StatusCode = HttpStatusCode.Conflict;
                    return response;
                }
            }
        }

        [HttpGet]
        [Route("api/admin/getChart")]
        public IHttpActionResult GetChart(string chartName)
        {
            var list = new List<int>();
            UADManager uADManager = new UADManager();
            list = uADManager.GetChartStats(chartName);
            var jwt = Request.Headers.GetValues("token").FirstOrDefault();

            return Ok(list);
        }
    }
}