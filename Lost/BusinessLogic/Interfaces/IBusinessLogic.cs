using DB.Models;
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


        List<Thing> findThing(string about, ItemStates.);
        void addThing(ObjectId userId, string about, string description, string place);
        void deleteThing(Thing thing);
        //void authorize();
        //void login();

    }
}
