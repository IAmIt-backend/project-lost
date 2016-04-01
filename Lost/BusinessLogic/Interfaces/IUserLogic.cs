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
        Task AddUserAsync(User user);
        Task<User> GetUserAsync(string id);
        Task<User> UpdateUserAsync(User user);
        void AddUser(User user);
        User GetUser(string id);
        User UpdateUser(User user);
    }
}