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
    public class DbUserReposirory : IUserReposirory
    {
        private readonly IMongoCollection<User> _userCollection;
        public DbUserReposirory()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("mongodb");
            _userCollection = database.GetCollection<User>("users");
        }
        public IdentityUser AddUser(IdentityUser user)
        {
            _userCollection.InsertOne(User.GetUserFromIdentityUser(user));
            return user;
        }

        public IdentityUser GetUser(string stringId)
        {
            ObjectId id = new ObjectId(stringId);
            return User.GetIdentityUserFromIUser(_userCollection.AsQueryable().FirstOrDefault(u => u.Id.Equals(id)));
        }

        public IdentityUser UpdateUser(IdentityUser user)
        {
            var update = new ObjectUpdateDefinition<User>(User.GetUserFromIdentityUser(user));
            _userCollection.UpdateOne<User>(u=>u.Id == new ObjectId(user.Id), update);
            return user;
        }
    }
}
