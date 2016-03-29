using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lost.Models;
using MongoDB.Bson;

namespace Lost.Repositories
{
    public interface IThingRepository
    {
        void AddThing(Thing thing);
        List<Thing> FoundThing(string about);

    }
}