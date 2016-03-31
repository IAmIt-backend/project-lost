using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUserLogic
    {
        Task AddUserAsync(IdentityUser user);
        Task<IdentityUser> GetUserAsync(string id);
        Task<IdentityUser> UpdateUserAsync(IdentityUser user);
        void AddUser(IdentityUser user);
        IdentityUser GetUser(string id);
        IdentityUser UpdateUser(IdentityUser user);
    }
}