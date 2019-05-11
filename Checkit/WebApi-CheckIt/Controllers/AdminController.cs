using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi_CheckIt.Controllers
{
    public class AdminController : ApiController
    {
        // GET api/User
        [HttpGet]
        [Route("api/uad/timeperpage")]
        public List<int> Get()
        {
            return [1, 2, 3, 4, 5, 6];
        }
    }
}
