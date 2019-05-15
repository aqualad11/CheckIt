using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CheckIt.ManagerLayer;
using CheckIt.ServiceLayer;
using CheckIt.DataAccessLayer;
using CheckIt.DataAccessLayer.Repositories;
using CheckIt.WebApi_CheckIt.Models;
using Newtonsoft.Json;


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


        [HttpPost]
        [Route("api/user/additemtolist")]
        public HttpResponseMessage AddItemToList([FromBody] ItemDTO item)
        {
            var response = new HttpResponseMessage();
            if(item.jwt == null)
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
                    string newJWT = tokenManager.ValidateToken(item.jwt);
                    //if jwt not valid redirect to SSO login
                    if(newJWT == null)
                    {
                        response = Request.CreateResponse(HttpStatusCode.Moved);
                        response.Content = new StringContent("https://kfc-sso.com/#/login");
                        return response;
                    }

                    //Athorize
                    AuthorizationManager authManager = new AuthorizationManager(db);
                    if(!authManager.AuthorizeAction(newJWT, Actions.WISHLIST))
                    {
                        response.Content = new StringContent("User in unauthorized to access watchlist.");
                        response.StatusCode = HttpStatusCode.Unauthorized;
                    }

                    Guid userID = tokenManager.ExtractUserID(newJWT);

                    //Add item to list
                    ItemManager itemManager = new ItemManager(db);
                    itemManager.AddItemToList(item.itemName, item.price, item.url, item.picKey, userID);

                    //create and return response
                    response.Content = new StringContent(newJWT);
                    response.StatusCode = HttpStatusCode.OK;
                    return response;
                }
                catch(AddFailedException e)
                {
                    response.Content = new StringContent(e.Message);
                    response.StatusCode = HttpStatusCode.Conflict;
                    return response;
                }
            }
        }

        [HttpPost]
        [Route("api/user/deleteitemfromlist")]
        public HttpResponseMessage DeleteItemFromList([FromBody] ItemDTO item)
        {
            var response = new HttpResponseMessage();
            if (item.jwt == null)
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
                    string newJWT = tokenManager.ValidateToken(item.jwt);
                    //if jwt not valid redirect to SSO login
                    if (newJWT == null)
                    {
                        response = Request.CreateResponse(HttpStatusCode.Moved);
                        response.Content = new StringContent("https://kfc-sso.com/#/login");
                        return response;
                    }

                    //Athorize
                    AuthorizationManager authManager = new AuthorizationManager(db);
                    if (!authManager.AuthorizeAction(newJWT, Actions.WISHLIST))
                    {
                        response.Content = new StringContent("User in unauthorized to access watchlist.");
                        response.StatusCode = HttpStatusCode.Unauthorized;
                    }

                    Guid userID = tokenManager.ExtractUserID(newJWT);

                    //Remove item to list
                    ItemManager itemManager = new ItemManager(db);
                    itemManager.RemoveItemFromList(item.itemName, item.price, item.url, item.picKey, userID);

                    //create and return response
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
        
        //TODO: Test
        [HttpGet]
        [Route("api/user/getwatchlist")]
        public HttpResponseMessage GetWatchList()
        {
            var jwt = Request.Headers.GetValues("token").FirstOrDefault();

            var response = new HttpResponseMessage();
            if(jwt == null)
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
                    string newJWT = tokenManager.ValidateToken(jwt);
                    //if jwt not valid redirect to SSO login
                    if (newJWT == null)
                    {
                        response = Request.CreateResponse(HttpStatusCode.Moved);
                        response.Content = new StringContent("https://kfc-sso.com/#/login");
                        return response;
                    }

                    //Athorize
                    AuthorizationManager authManager = new AuthorizationManager(db);
                    if (!authManager.AuthorizeAction(newJWT, Actions.WISHLIST))
                    {
                        response.Content = new StringContent("User in unauthorized to access watchlist.");
                        response.StatusCode = HttpStatusCode.Unauthorized;
                    }

                    Guid userID = tokenManager.ExtractUserID(newJWT);

                    //Get items and make DTO
                    ItemManager itemManager = new ItemManager(db);
                    var items = itemManager.GetItemsFromWatchList(userID);
                    var itemsDTO = new ItemsDTO()
                    {
                        jwt = newJWT,
                        items = items
                    };

                    //make response
                    response.Content = new StringContent(JsonConvert.SerializeObject(itemsDTO),
                                                                System.Text.Encoding.UTF8, "application/json");
                    response.StatusCode = HttpStatusCode.OK;
                    return response;
                }catch(Exception e)
                {
                    response.Content = new StringContent(e.Message);
                    response.StatusCode = HttpStatusCode.Conflict;
                    return response;
                }
            }
        }


        [HttpGet]
        [Route("api/user/login")]
        public HttpResponseMessage CheckItLogin()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent("https://kfc-sso.com/#/login");
            return response;
        }

        [HttpGet]
        [Route("api/user/register")]
        public HttpResponseMessage CheckItRegister()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent("https://kfc-sso.com/#/register");
            return response;
        }

        
        [HttpPost]
        [Route("api/user/logout")]
        public HttpResponseMessage CheckItLogout([FromBody] string jwt)
        {
            var response = new HttpResponseMessage();

            if (jwt == null)
            {
                response.Content = new StringContent("JWT is null.");
                response.StatusCode = HttpStatusCode.Conflict;
                return response;
            }
            using (var db = new DataBaseContext())
            {
                try
                {
                    LogoutManager logoutManager = new LogoutManager(db);
                    logoutManager.CheckItLogout(jwt);
                    response.StatusCode = HttpStatusCode.OK;
                    return response;
                }catch(Exception e)
                {
                    response.Content = new StringContent(e.Message);
                    response.StatusCode = HttpStatusCode.Conflict;
                    return response;
                }
            }
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