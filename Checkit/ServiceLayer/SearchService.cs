using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIt.DataAccessLayer;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System.Collections;

namespace CheckIt.ServiceLayer
{
    public class SearchService
    {
        MongoContext _db;

        public SearchService(MongoContext _db)
        {
            this._db = _db;
        }

        public List<BsonDocument> GetItem(string name, MongoContext _db, string Collection)
        {
            this._db = _db;
            //var sort = Builders<BsonDocument>.Sort.Descending("price");
            //var builder = Builders<BsonDocument>.Filter;
            //var builder = Builders<BsonDocument>.Filter.Text(name);
            //var builder = Builders<BsonDocument>.Filter.Lt("name",name);
            var filter = Builders<BsonDocument>.Filter.Text(name);
            var sort = Builders<BsonDocument>.Sort.Ascending("score");                                  //Ascending("score").Descending("price");
                                                                                                        //var filter = builder.Regex("name", name);
                                                                                                        //var filter = new BsonDocument("name", name);
                                                                                                        //var filter = builder.Text(name);
            var collection = this._db.database.GetCollection<BsonDocument>(Collection);
            var result = collection.Find(filter).Sort(sort).ToList();
            //	var query =
            //		(from e in collection.AsQueryable<MongoItem>()
            //		 orderby e.Price descending
            //		 where e.Any( k => k.Keywords == name)
            //		 select e);

            return result;
            //}

        }
    }

}
//Builders<BsonDocument>.Sort.Descending("price")