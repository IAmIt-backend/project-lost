using System;
using System.Collections.Generic;
using DB.Models;
using MongoDB.Bson;

namespace DB.Interfaces
{
    public interface IThingRepository
    {
        void AddThing(Thing thing);
        [Obsolete("Используй AddThing")]
        void AddLostThing(Thing thing);
        [Obsolete("Используй AddThing")]
        void AddFindThing(Thing thing);
        void DeleteThing(ObjectId thingid);
        [Obsolete("Используй FindThing")]
        List<Thing> FindLostThing(string about);
        [Obsolete("Используй FindThing")]
        List<Thing> FindFoundThing(string about);
        List<Thing> FindThing(string about, ItemStates states);
        List<Thing> FindReturnedThing(string about);
    }
}