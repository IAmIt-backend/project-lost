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

        public List<Thing> addThingToFound(ObjectId userId, string about, string description, string place)
        {
            List<Thing> list1 = _repository.FindLostThing(about);
            if (list1.Count == 0)
            {
                _repository.AddFindThing(new Thing { UserId = userId, About = about, Description = description, Place = place, });
                return list1;
            }
            else {
                return list1;
            }


        }
        
        public List<Thing> addThingToLost(ObjectId userId, string about, string description, string place)
        {
            List<Thing> list2 = _repository.FindFoundThing(about);
            if (list2.Count == 0)
            {
                _repository.AddLostThing(new Thing { UserId = userId, About = about, Description = description, Place = place, });
                return list2;
            }
            else {
                //уведомляем другого пользователя
                return list2;
            }
        }



        public List<Thing> findFoundThing(string about)
        {

            List<Thing> list3 = _repository.FindFoundThing(about);
            return list3;
        }

        public List<Thing> findLostThing(string about)
        {

            List<Thing> list4 = _repository.FindLostThing(about);
            return list4;
        }        
    }
}
