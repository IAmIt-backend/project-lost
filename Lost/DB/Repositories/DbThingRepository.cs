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

        public DbThingRepository()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("mongodb");
            _thingCollection = database.GetCollection<Thing>("things");
        }
        public Thing AddThing(Thing thing)
        {
            _thingCollection.InsertOneAsync(thing);
            return thing;
        }
        public Thing DeleteThing(ObjectId thingId)
        {
            return _thingCollection.FindOneAndDelete(t => t.Id == thingId);
            /*thing = _findThingCollection.FindOneAndDelete(t => t.Id == thingId);
            thing.ItemStatus = ItemStates.Returned;
            _findThingCollection.InsertOneAsync(thing);*/
        }
        public List<Thing> FindThing(string about, ItemStates states)
        {
            return _thingCollection.AsQueryable().Where(t => t.About.Equals(about) && t.ItemStatus.Equals(states)).ToList();
        }

        public Thing UpdateThing(Thing thing)
        {
            /*var status = _thingCollection.Find(t => t.Id == thing.Id).First().ItemStatus;
            var about = _thingCollection.Find(t => t.Id == thing.Id).First().About;*/
            var update = new ObjectUpdateDefinition<Thing>(thing);
            _thingCollection.UpdateOne<Thing>(t=> t.Id == thing.Id,update);
            return thing;
        }
    }
}