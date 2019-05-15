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
            List<BsonDocument> amazonResult;
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
        //	public BsonDocument SearchBestBuyQuery(string name, MongoContext _db)
        //	{
        //		BsonDocument bestBuyResult;
        //		try
        //		{
        //			bestBuyResult = searchService.GetItem(name, _db, bestBuyCollection);
        //		}
        //		catch (Exception er)
        //		//catch (ItemNotFoundError er)
        //		{
        //			bestBuyResult = null;
        //		}
        //		return bestBuyResult;
        //	}
        //	public BsonDocument SearchTargetQuery(string name, MongoContext _db)
        //	{
        //		BsonDocument targetResult;
        //		try
        //		{
        //			targetResult = searchService.GetItem(name, _db, targetCollection);
        //		}
        //		catch (Exception er)
        //		//catch (ItemNotFoundError er)
        //		{
        //			targetResult = null;
        //		}
        //		return targetResult;
        //	}

    }
}