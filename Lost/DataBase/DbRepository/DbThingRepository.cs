using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Lost.Models;
using Lost.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Lost.DbRepository
{
    public class DbThingRepository:IThingRepository
    {
        private readonly IMongoCollection<Thing> _thingCollection;

        public DbThingRepository()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("mongodb");
            _thingCollection = database.GetCollection<Thing>(nameof(Thing));
        }
        public void AddThing(Thing thing)
        {
            _thingCollection.InsertOneAsync(thing);
        }

        public List<Thing> FoundThing(string about)
        {
            throw new NotImplementedException();
        }
    }
}