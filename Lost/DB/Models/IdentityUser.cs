using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MongoDB.Bson;

namespace DB.Models
{
    public class User : IUser
    {
        public string Id
        {
            get { return this.UserId.ToString();}
            set
            {
                this.UserId = new ObjectId(value);
            }
        }

        public ObjectId UserId { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
