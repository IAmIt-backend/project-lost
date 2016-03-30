using System.Collections.Generic;
using BL.Interfaces;
using BL.Interfaces;
using DB.Interfaces;
using DB.Models;
using DB.Repositories;
using MongoDB.Bson;

namespace BL.Implementation
{
    public class BusinessLogic : IBusinessLogic
    {

        private readonly IThingRepository _repository;
        
        //private readonly IThingRepository _repositoryLost;
        public BusinessLogic()
        {
            _repository = new DbThingRepository();
        }

        public void AddThing(Thing thing)
        {
            _repository.AddThing(thing);
        }

        public void DeleteThing(ObjectId thingId)
        {
            _repository.DeleteThing(thingId);
        }

        public List<Thing> FindThing(string about, ItemStates itemStates)
        {
            return _repository.FindThing(about, itemStates);
        }

        public List<Thing> FindReturnedThing(string about)
        {
           return  _repository.FindReturnedThing(about);
        }
    }
}
