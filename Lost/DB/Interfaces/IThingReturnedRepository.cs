using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models;
using MongoDB.Bson;

namespace DB.Interfaces
{
    public interface IThingReturnedRepository
    {
        Thing AddThing(Thing thing);
        Task<Thing> AddThingAsync(Thing thing);
        Thing DeleteThing(ObjectId thingid);
        Task<Thing> DeleteThingAsync(ObjectId thingid);

        List<Thing> FindThing(string about);
        Task<List<Thing> > FindThingAsync(string about);

    }
}
