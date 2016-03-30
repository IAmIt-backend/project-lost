﻿using System.Collections.Generic;
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
            Thing thing = _thingCollection.FindOneAndDelete(t => t.Id == thingId);
            _returnedThingCollection.InsertOne(thing);
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

        public List<Thing> FindReturnedThing(string about)
        {
            return _returnedThingCollection.AsQueryable().Where(t => t.About.Equals(about)).ToList();
        }
    }
}