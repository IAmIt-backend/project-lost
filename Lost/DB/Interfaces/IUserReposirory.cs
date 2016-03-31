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
        IdentityUser2 AddUser(IdentityUser2 user);
        Task<IdentityUser2> AddUserAsync(IdentityUser2 user);

        IdentityUser2 GetUser(string id);
        Task<IdentityUser2> GetUserAsync(string id);

        IdentityUser2 UpdateUser(IdentityUser2 user);
        Task<IdentityUser2> UpdateUserAsync(IdentityUser2 user);

    }
}
