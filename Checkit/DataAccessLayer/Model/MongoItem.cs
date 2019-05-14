using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CheckIt.DataAccessLayer
{
    public class MongoItem
    {
        //[BsonId]
        public Object Id { get; set; }

        //[BsonElement("name")]
        public string Name { get; set; }

        //[BsonElement("price")]
        public double Price { get; set; }

        //[BsonElement("url")]
        public string Url { get; set; }

        //[BsonElement("description")]
        public string Description { get; set; }

        //[BsonElement("keywords")]
        public string[] Keywords { get; set; }


    }
}