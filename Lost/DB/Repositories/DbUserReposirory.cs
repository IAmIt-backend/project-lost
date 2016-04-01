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
            var database = MongoClientFactory.GetMongoDatabase();
            _userCollection = database.GetCollection<User>("users");
        }
        public User AddUser(User user)
        {
            _userCollection.InsertOne(user);
            return user;
        }
        async public Task<User> AddUserAsync(User user)
        {
            await _userCollection.InsertOneAsync(user);
            return user;
        }

        public User GetUser(string stringId)
        {
            ObjectId id = new ObjectId(stringId);
            var user =_userCollection.AsQueryable().FirstOrDefault(u => u.UserId.Equals(id));
            return user;
        }
        async public Task<User> GetUserAsync(string stringId)
        {
            ObjectId id = new ObjectId(stringId);
            return await _userCollection.AsQueryable().FirstOrDefaultAsync(u => u.UserId.Equals(id));
        }

        public User DeleteUser(ObjectId id)
        {
            return _userCollection.FindOneAndDelete(u => u.UserId.Equals(id));
        }

        public User UpdateUser(User user)
        {
            DeleteUser(user.UserId);
            AddUser(user);
            return user;
        }
        async public Task<User> DeleteUserAsync(ObjectId id)
        {
            return await _userCollection.FindOneAndDeleteAsync(u => u.UserId.Equals(id));
        }

        async public Task<User> UpdateUserAsync(User user)
        {
            await DeleteUserAsync(user.UserId);
            await AddUserAsync(user);
            return user;
        }
    }
}
