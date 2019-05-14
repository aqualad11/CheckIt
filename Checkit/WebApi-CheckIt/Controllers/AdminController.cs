using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheckIt.WebApi_CheckIt.Models;
using CheckIt.ManagerLayer;


namespace WebApi_CheckIt.Controllers
{
    public class AdminController : ApiController
    {
        // GET api/User
        [HttpGet]
        [Route("api/admin/getChart")]
        public IHttpActionResult GetChart(string chartName)
        {
            //var jwt = Request.Headers.GetValues("token").FirstOrDefault();
            //var list = new List<int> { 5, 6, 3, 4, 5, 6 };
            var list = new List<int>();
            UADManager uADManager = new UADManager();
            list = uADManager.GetChartStats(chartName);

            return Ok(list);

        }
    }
}
