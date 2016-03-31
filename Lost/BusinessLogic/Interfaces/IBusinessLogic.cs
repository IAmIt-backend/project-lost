using System.Collections.Generic;
using DB.Models;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IBusinessLogic
    {


        Task<List<Thing>> FindThingAsync(string about, ItemStates itemStates);
        Task<List<Thing>> FindReturnedThingAsync(string about);
        Task<Thing> AddThingAsync(Thing thing);
        Task<Thing> DeleteThingAsync(ObjectId thingId);
        Task<Thing> GetThingByIdAsync(ObjectId thingId);
        List<Thing> FindThing(string about, ItemStates itemStates);
        List<Thing> FindReturnedThing(string about);
        Thing AddThing(Thing thing);
        Thing DeleteThing(ObjectId thingId);
        Thing GetThingById(ObjectId thingId);
        //void authorize();
        //void login();

    }
}
