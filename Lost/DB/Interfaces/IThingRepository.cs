using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DB.Models;
using MongoDB.Bson;

namespace DB.Interfaces
{
    public interface IThingRepository
    {
        Thing AddThing(Thing thing);
        Task<Thing> AddThingAsync(Thing thing);
        Thing DeleteThing(ObjectId thingid);
        Task<Thing> DeleteThingAsync(ObjectId thingid);
        List<Thing> FindThing(string about, ItemStates states);
        Task<List<Thing> > FindThingAsync(string about, ItemStates states);
        Thing UpdateThing(Thing thing);
        Task<Thing> UpdateThingAsync(Thing thing);
        Thing GetThingById(ObjectId id);
        Task<Thing> GetThingByIdAsync(ObjectId id);
    }
}