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
        Task AddUserAsync(IdentityUser2 user);
        Task<IdentityUser2> GetUserAsync(string id);
        Task<IdentityUser2> UpdateUserAsync(IdentityUser2 user);
        void AddUser(IdentityUser2 user);
        IdentityUser2 GetUser(string id);
        IdentityUser2 UpdateUser(IdentityUser2 user);
    }
}