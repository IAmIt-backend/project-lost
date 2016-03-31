using System;
using System.Collections.Generic;
using DB.Models;
using MongoDB.Bson;

namespace DB.Interfaces
{
    public interface IThingRepository
    {
        Thing AddThing(Thing thing);
        Thing DeleteThing(ObjectId thingid);
        List<Thing> FindThing(string about, ItemStates states);
        Thing UpdateThing(Thing thing);
        Thing GetThingById(ObjectId id);
    }
}