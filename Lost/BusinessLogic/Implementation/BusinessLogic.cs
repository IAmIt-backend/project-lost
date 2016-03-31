using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
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

    public class BusinessLogic : IBusinessLogic
    {

        private readonly IThingRepository _repository= new DbThingRepository();
        private readonly IThingReturnedRepository _retrepository = new DbThingReturnedRepository();
        


        public void AddThing(Thing thing)
        {
            _repository.AddThing(thing);
        }

        public void DeleteThing(ObjectId thingId)
        {
            
            var thing =_repository.DeleteThing(thingId);
            _retrepository.AddThing(thing);

        }

        public List<Thing> FindThing(string about, ItemStates itemStates)
        {
            return _repository.FindThing(about, itemStates);
        }

        public List<Thing> FindReturnedThing(string about)
        {
            return  _retrepository.FindThing(about);
        }
    }
}
