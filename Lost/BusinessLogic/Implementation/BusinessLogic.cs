using Business.BLInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Interfaces;
using DB.Models;
using MongoDB.Bson;
using DB.Repositories;

namespace Business.BLClass
{
    public enum NewStatus
    {
        found = 0,
        lost = 1
    };

    class BusinessLogic : IBusinessLogic
    {

        private readonly IThingRepository _repository;
        
        //private readonly IThingRepository _repositoryLost;
        public BusinessLogic()
        {
            _repository = new DbThingRepository();
        }

        public void addThing(ObjectId userId, string about, string description, string place)
        {
            _repository.AddThing(new Thing
            {
                About = about,
                Description = description,
                Place = place
            });
        }

        public void deleteThing(ObjectId thingId)
        {
            _repository.DeleteThing(thingId);
        }

        public List<Thing> findThing(string about, ItemStates itemStates)
        {
            return _repository.FindThing(about, itemStates);
        }

        
    }
}
