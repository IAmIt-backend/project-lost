using System.Collections.Generic;
using System.Linq;
using Lost.Models;
using Lost.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace DataBase.DbRepository
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
        public void AddThing(Thing thing)
        {
            _thingCollection.InsertOneAsync(thing);
        }

        public void AddLostThing(Thing thing)
        {
            throw new System.NotImplementedException();
        }

        public void AddFindThing(Thing thing)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteThing(ObjectId thingId)
        {
            _thingCollection.DeleteOne(t => t.Id == thingId);
            /*thing = _findThingCollection.FindOneAndDelete(t => t.Id == thingId);
            thing.ItemStatus = ItemStates.Returned;
            _findThingCollection.InsertOneAsync(thing);*/
        }

        public List<Thing> FindLostThing(string about)
        {
            throw new System.NotImplementedException();
        }

        public List<Thing> FindFoundThing(string about)
        {
            throw new System.NotImplementedException();
        }

        public List<Thing> FindThing(string about, ItemStates states)
        {
            return _thingCollection.AsQueryable().Where(t => t.About.Equals(about)).ToList();
        }
    }
}