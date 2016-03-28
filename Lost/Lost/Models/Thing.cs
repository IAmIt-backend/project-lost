using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lost.Models
{
    public enum ItemStates
    {
        Found,
        Lost,
        Returned
    }
    public class Thing
    {
        public Guid Id { get; set; }
        public string Place { get; set; }
        public string About { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public ItemStates ItemStatus { get; set; }
    }
}