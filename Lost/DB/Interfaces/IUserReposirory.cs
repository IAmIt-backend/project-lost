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
        IdentityUser AddUser(IdentityUser user);
        Task<IdentityUser> AddUserAsync(IdentityUser user);

        IdentityUser GetUser(string id);
        Task<IdentityUser> GetUserAsync(string id);

        IdentityUser UpdateUser(IdentityUser user);
        Task<IdentityUser> UpdateUserAsync(IdentityUser user);

    }
}
