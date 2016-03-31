using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;


namespace DB
{
    public class MongoClientFactory
    {
        public static MongoClient GetMongoClient()
        {
            var dbConnectionString = System.Configuration.ConfigurationManager.AppSettings["DB"];
            if (!String.IsNullOrEmpty(dbConnectionString))
            {
                return new MongoClient(dbConnectionString);
            }
            return new MongoClient();
        }

        public static IMongoDatabase GetMongoDatabase(String name = "mongodb")
        {
            return GetMongoClient().GetDatabase(name);
        }
    }
}
