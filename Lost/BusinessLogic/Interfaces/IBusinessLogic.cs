using System.Collections.Generic;
using DB.Models;
using MongoDB.Bson;

namespace BL.Interfaces
{
    public interface IBusinessLogic
    {


        List<Thing> FindThing(string about, ItemStates itemStates);
        List<Thing> FindReturnedThing(string about);
        void AddThing(Thing thing);
        void DeleteThing(ObjectId thingId);
        //void authorize();
        //void login();

    }
}
