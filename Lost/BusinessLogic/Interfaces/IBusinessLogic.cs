﻿using System.Collections.Generic;
using DB.Models;
using MongoDB.Bson;

namespace BusinessLogic.Interfaces
{
    public interface IBusinessLogic
    {


        List<Thing> FindThing(string about, ItemStates itemStates);
        List<Thing> FindReturnedThing(string about);
        void AddThing(Thing thing);
        void DeleteThing(ObjectId thingId);
        Thing GetThingById(ObjectId thingId);
        //void authorize();
        //void login();

    }
}
