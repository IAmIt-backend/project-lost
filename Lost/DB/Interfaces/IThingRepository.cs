using System;
using System.Collections.Generic;
using DB.Models;
using MongoDB.Bson;

namespace DB.Interfaces
{
    public interface IThingRepository
    {
        void AddThing(Thing thing);
        void DeleteThing(ObjectId thingid);
        List<Thing> FindThing(string about, ItemStates states);
        List<Thing> FindReturnedThing(string about);
    }
}