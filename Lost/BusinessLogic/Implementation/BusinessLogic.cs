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


        public Thing AddThing(Thing thing)//---
        {
            return _repository.AddThing(thing);
        }

        public List<Thing> FindThing(string about, ItemStates itemStates)//---
        {
            return _repository.FindThing(about, itemStates);
        }

        public List<Thing> FindReturnedThing(string about)//---
        {
            return  _retrepository.FindThing(about);
        }

        public Thing GetThingById(ObjectId thingId)//---
        {
            return _repository.GetThingById(thingId);
        }

        public Thing DeleteThing(ObjectId thingId)//---
        {

            var thing = _repository.DeleteThing(thingId);
            return _retrepository.AddThing(thing);

        }
        public async Task<List<Thing>> FindThingAsync(string about, ItemStates itemStates)
        {
            return await _repository.FindThingAsync(about, itemStates);
        }

        public async Task<List<Thing>> FindReturnedThingAsync(string about)
        {
            return await _retrepository.FindThingAsync(about);
        }

        public async Task<Thing> AddThingAsync(Thing thing)
        {
            return await _repository.AddThingAsync(thing);
        }

        public async Task<Thing> DeleteThingAsync(ObjectId thingId)
        {
            Thing thing = _repository.DeleteThing(thingId);
            return await _retrepository.AddThingAsync(thing);
        }

        public async Task<Thing> GetThingByIdAsync(ObjectId thingId)
        {
            return await _repository.GetThingByIdAsync(thingId);
        }

        async public Task<Thing> UpdateThingAsync(Thing thing)
        {
            return await _repository.UpdateThingAsync(thing);
        }

        public Thing UpdateThing(Thing thing)
        {
            return _repository.UpdateThing(thing);
        }
        
        
    }
}
