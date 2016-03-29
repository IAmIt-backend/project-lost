using System.Collections.Generic;
using System.Linq;
using Lost.Models;
using Lost.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace DataBase.DbRepository
{
    public class DbThingRepository:IThingRepository
    {
        private readonly IMongoCollection<Thing> _lostThingCollection;
        private readonly IMongoCollection<Thing> _findThingCollection;

        public DbThingRepository()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("mongodb");
            _lostThingCollection = database.GetCollection<Thing>("lostThings");
            _findThingCollection = database.GetCollection<Thing>("findThings");
        }
        public void AddThing(Thing thing)
        {
            _lostThingCollection.InsertOneAsync(thing);
        }

        public void DeleteThing(ObjectId thingId)
        {
            _lostThingCollection.DeleteOne(t => t.Id == thingId);
            /*thing = _findThingCollection.FindOneAndDelete(t => t.Id == thingId);
            thing.ItemStatus = ItemStates.Returned;
            _findThingCollection.InsertOneAsync(thing);*/
        }

        public List<Thing> FindLostThing(string about)
        {
            return _lostThingCollection.AsQueryable().Where(t => t.About.Equals(about)).ToList();
        }

        public List<Thing> FindFoundThing(string about)
        {
            return _findThingCollection.AsQueryable().Where(t => t.About.Equals(about)).ToList();

        }
    }
}