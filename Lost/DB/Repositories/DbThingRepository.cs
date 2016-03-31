using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        async public Task<Thing> AddThingAsync(Thing thing)
        {
            await _thingCollection.InsertOneAsync(thing);
            return thing;
        }
        public Thing DeleteThing(ObjectId thingId)
        {
            return _thingCollection.FindOneAndDelete(t => t.Id == thingId);
            /*thing = _findThingCollection.FindOneAndDelete(t => t.Id == thingId);
            thing.ItemStatus = ItemStates.Returned;
            _findThingCollection.InsertOneAsync(thing);*/
        }
        async public Task<Thing> DeleteThingAsync(ObjectId thingId)
        {
            return await _thingCollection.FindOneAndDeleteAsync(t => t.Id == thingId);
            /*thing = _findThingCollection.FindOneAndDelete(t => t.Id == thingId);
            thing.ItemStatus = ItemStates.Returned;
            _findThingCollection.InsertOneAsync(thing);*/
        }
        public List<Thing> FindThing(string about, ItemStates states)
        {
            return _thingCollection.AsQueryable().Where(t => t.About.Equals(about) && t.ItemStatus.Equals(states)).ToList();
        }
        async public Task<List<Thing> > FindThingAsync(string about, ItemStates states)
        {
             return await _thingCollection.AsQueryable().Where(t => t.About.Equals(about) && t.ItemStatus.Equals(states)).ToListAsync();
        }

        public Thing UpdateThing(Thing thing)
        {
            /*var status = _thingCollection.Find(t => t.Id == thing.Id).First().ItemStatus;
            var about = _thingCollection.Find(t => t.Id == thing.Id).First().About;*/
            var update = new ObjectUpdateDefinition<Thing>(thing);
            _thingCollection.UpdateOne<Thing>(t=> t.Id == thing.Id,update);
            return thing;
        }
        async public Task<Thing> UpdateThingAsync(Thing thing)
        {
            /*var status = _thingCollection.Find(t => t.Id == thing.Id).First().ItemStatus;
            var about = _thingCollection.Find(t => t.Id == thing.Id).First().About;*/
            var update = new ObjectUpdateDefinition<Thing>(thing);
            await _thingCollection.UpdateOneAsync<Thing>(t => t.Id == thing.Id, update);
            return thing;
        }
        public Thing GetThingById(ObjectId id)
        {
            return _thingCollection.AsQueryable().FirstOrDefault(t => t.Id == id);
        }
        async public Task<Thing> GetThingByIdAsync(ObjectId id)
        {
            return await _thingCollection.AsQueryable().FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}