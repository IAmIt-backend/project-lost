using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Interfaces;
using DB.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace DB.Repositories
{
    public class DbThingReturnedRepository : IThingReturnedRepository
    {
        private readonly IMongoCollection<Thing> _returnedThingCollection;

        public DbThingReturnedRepository()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("mongodb");
            _returnedThingCollection = database.GetCollection<Thing>("returnedThing");
        }

        public Thing AddThing(Thing thing)
        {
            _returnedThingCollection.InsertOne(thing);
            return thing;
        }

        public async Task<Thing> AddThingAsync(Thing thing)
        {
            await _returnedThingCollection.InsertOneAsync(thing);
            return thing;
        }

        public Thing DeleteThing(ObjectId thingid)
        {
            return _returnedThingCollection.FindOneAndDelete(t => t.Id == thingid);
        }

        public async Task<Thing> DeleteThingAsync(ObjectId thingid)
        {
            return await _returnedThingCollection.FindOneAndDeleteAsync(t => t.Id == thingid);
        }

        public List<Thing> FindThing(string about)
        {
            return _returnedThingCollection.AsQueryable().Where(t => t.About.Equals(about)).ToList();
        }

        async public Task<List<Thing> > FindThingAsync(string about)
        {
            return await _returnedThingCollection.AsQueryable().Where(t => t.About.Equals(about)).ToListAsync();
        }
    }
}

