using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DB.Models;
using MongoDB.Bson;

namespace Lost.ViewModel
{
    public class IndexViewModel
    {
        public string Text { set; get; }
        public string About { set; get; }
        public string Description { set; get; }
        public string Place { set; get; }
        public ItemStates Status { set; get; }
        public ObjectId UserId { set; get; }
        public ObjectId ThingId { set; get; }
        public int Length { set; get; }
        public List<Thing> Things { set; get; }
    }
}