using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace DB.Models
{
    public enum ItemStates
    {
        Found,
        Lost,
        Returned
    }
    public class Thing
    {

        public ObjectId Id { get; set; }
        public string Place { get; set; }
        public string About { get; set; }
        public string Description { get; set; }
        public ObjectId UserId { get; set; }
        public ItemStates ItemStatus { get; set; }
    }
}