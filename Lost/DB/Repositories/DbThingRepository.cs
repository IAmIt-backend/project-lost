using System.Collections.Generic;
using System.Linq;
using DB.Interfaces;
using DB.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace DB.Repositories
{
    public class DbThingRepository : IThingRepository
    {
        private readonly IMongoCollection<Thing> _thingCollection;
        private readonly IMongoCollection<Thing> _returnedThingCollection;

        public DbThingRepository()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("mongodb");
            _thingCollection = database.GetCollection<Thing>("things");
            _returnedThingCollection = database.GetCollection<Thing>("returnedThing");
        }
        public void AddThing(Thing thing)
        {
            _thingCollection.InsertOneAsync(thing);
        }
        public void DeleteThing(ObjectId thingId)
        {
            Thing thing = _thingCollection.FindOneAndDelete(t => t.Id == thingId);
            _returnedThingCollection.InsertOne(thing);
            /*thing = _findThingCollection.FindOneAndDelete(t => t.Id == thingId);
            thing.ItemStatus = ItemStates.Returned;
            _findThingCollection.InsertOneAsync(thing);*/
        }
        public List<Thing> FindThing(string about, ItemStates states)
        {
            return _thingCollection.AsQueryable().Where(t => t.About.Equals(about) && t.ItemStatus.Equals(states)).ToList();
        }

        public List<Thing> FindReturnedThing(string about)
        {
            return _returnedThingCollection.AsQueryable().Where(t => t.About.Equals(about)).ToList();
        }
        
    }
}