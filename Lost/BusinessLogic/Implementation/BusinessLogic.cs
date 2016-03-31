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
           // Добавить другой репозиторий
           return  _repository.FindThing(about, ItemStates.Found);
        }
    }
}
