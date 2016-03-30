using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Interfaces;
using DB.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace DB.Repositories
{
    public class DbUserReposirory: IUserReposirory
    {
        private readonly IMongoCollection<IdentityUser> _userCollection;
        public DbUserReposirory()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("mongodb");
            _userCollection = database.GetCollection<IdentityUser>("users");
        }
        public void AddUser(IdentityUser user)
        {
            _userCollection.InsertOne(user);
        }

        public IdentityUser GetUser(string id)
        {
            return _userCollection.AsQueryable().FirstOrDefault(u => u.Id.Equals(id));
        }
    }
}
