using Lost.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BLInterface
{
    interface IBusinessLogic
    {


        List<Thing> findFoundThing(string about);
        List<Thing> findLostThing(string about);
        List<Thing> addThingToLost(ObjectId userId, string about, string description, string place);
        List<Thing> addThingToFound(ObjectId userId, string about, string description, string place);
        //void authorize();
        //void login();

    }
}
