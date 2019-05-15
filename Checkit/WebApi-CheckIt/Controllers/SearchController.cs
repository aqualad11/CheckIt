using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CheckIt.DataAccessLayer;
using CheckIt.ManagerLayer;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Net;
using Newtonsoft.Json;
using System.Collections;

namespace WebApi_CheckIt.Controllers
{
    public class SearchController : ApiController
    {
        //	[HttpGet]
        //	[Route("api/search")]
        //	public IHttpActionResult CheckItSearch([FromBody]SearchDTO request)
        //	{
        //		var amazonCollection = "AmazomItems";
        //		var bestBuyCollection = "";
        //		var targetCollection = "";
        //		MongoContext _db = new MongoContext();
        //		SearchManager _sm = new SearchManager(_db);
        //		string list;
        //		List<string> returnResult = new List<string>();


        //		returnResult.Add(_sm.SearchAmazonQuery(request.searchQuery, _db)); 
        //		//list.Add(_sm.SearchBestBuyQuery(request.searchQuery,_db);
        //		//list.Add(_sm.SearchTargetQuery(request.searchQuery, _db);
        //		return Content((HttpStatusCode)200, returnResult);
        //	}
        //}
        [HttpGet]
        [Route("api/search")]
        public HttpResponseMessage CheckItSearch(string searchQuery)
        {
            var response = new HttpResponseMessage();
            var token = Request.Headers.GetValues("token").FirstOrDefault();
            var amazonCollection = "AmazomItems";
            var bestBuyCollection = "";
            var targetCollection = "";
            MongoContext _db = new MongoContext();
            SearchManager _sm = new SearchManager(_db);
            //string list = "Fuck";

			List<List<BsonDocument>> items = new List<List<BsonDocument>>();
			List<BsonDocument> nullTest;
			List<BsonDocument> list = new List<BsonDocument>();
			if ((list = _sm.SearchAmazonQuery(searchQuery, _db)).Count() != 0)
			{
				items.Add(list);
			}
			if ((list = _sm.searchBestBuyQuery(searchQuery, _db)).Count() != 0)
			{
				items.Add(list);
			}
			if ((list = _sm.searchTargetQuery(searchQuery, _db)).Count() != 0)
			{
				items.Add(list);
			}
            //List<string> returnResult = new List<string>();
            IEnumerable testList = _sm.SearchAmazonQuery(searchQuery, _db);
            //returnResult.Add(_sm.SearchAmazonQuery(rsearchQuery, _db));
            ////list.Add(_sm.SearchBestBuyQuery(request.searchQuery,_db);
            ////list.Add(_sm.SearchTargetQuery(request.searchQuery, _db);
            //IEnumerable<string> testList = returnResult.AsEnumerable();
            //return Content((HttpStatusCode)200, testList);
            response.Content = new StringContent(JsonConvert.SerializeObject(items), System.Text.Encoding.UTF8, "application/json");
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}
