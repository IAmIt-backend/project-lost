using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models;
using MongoDB.Bson;

namespace DB.Interfaces
{
    public interface IUserReposirory
    {
        User AddUser(User user);
        Task<User> AddUserAsync(User user);

        User GetUser(string id);
        Task<User> GetUserAsync(string id);

        User UpdateUser(User user);
        Task<User> UpdateUserAsync(User user);

    }
}
