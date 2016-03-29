using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Lost.Models;
using MongoDB.Bson;

namespace Lost.Repositories
{
    public interface IThingRepository
    {
        void AddLostThing(Thing thing);
        void AddFindThing(Thing thing);
        void DeleteThing(ObjectId thingid);
        List<Thing> FindLostThing(string about);
        List<Thing> FindFoundThing(string about);
    }
}