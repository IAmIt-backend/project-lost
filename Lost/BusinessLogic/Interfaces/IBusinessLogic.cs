using System.Collections.Generic;
using DB.Models;
using MongoDB.Bson;

namespace BusinessLogic.Interfaces
{
    interface IBusinessLogic
    {


        List<Thing> FindThing(string about, ItemStates itemStates);
        List<Thing> FindReturnedThing(string about);
        void AddThing(ObjectId userId, string about, string description, string place);
        void DeleteThing(ObjectId thingId);
        //void authorize();
        //void login();

    }
}
