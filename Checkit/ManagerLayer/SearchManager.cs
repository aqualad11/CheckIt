using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.ServiceLayer;
using CheckIt.DataAccessLayer;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;

namespace CheckIt.ManagerLayer
{
    public class SearchManager
    {
        private SearchService searchService;
        private string targetCollection = "TargetItems";
        private string bestBuyCollection = "BestBuyItems";
        private string amazonCollection = "AmazonItems";

        public SearchManager(MongoContext _db)
        {
            searchService = new SearchService(_db);
        }

        public List<BsonDocument> SearchAmazonQuery(string name, MongoContext _db)
        {
            List<BsonDocument> amazonResult = null;
            try
            {
                amazonResult = searchService.GetItem(name, _db, amazonCollection);
            }
            catch (Exception er)
            //catch (ItemNotFoundError er)
            {
                amazonResult = null;
            }
            return amazonResult;
        }
		public List<BsonDocument> searchBestBuyQuery(string name, MongoContext _db)
		{
			List<BsonDocument> bestbuyresult = null;
			try
			{
				bestbuyresult = searchService.GetItem(name, _db, bestBuyCollection);
			}
			catch (Exception er)
			//catch (itemnotfounderror er)
			{
				bestbuyresult = null;
			}
			return bestbuyresult;
		}
		public List<BsonDocument> searchTargetQuery(string name, MongoContext _db)
		{
			List<BsonDocument> targetresult = null;
			try
			{
				targetresult = searchService.GetItem(name, _db, targetCollection);
			}
			catch (Exception er)
			//catch (itemnotfounderror er)
			{
				targetresult = null;
			}
			return targetresult;
		}

	}
}