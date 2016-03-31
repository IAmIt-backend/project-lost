using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models;
using DB.Repositories;
using DB.Interfaces;

namespace BusinessLogic.Implementation
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserReposirory _urepository;

        public UserLogic()
        {
            _urepository = new DbUserReposirory();
        }



        public  void AddUser(IdentityUser2 user)//---
        {
            _urepository.AddUser(user);
        }
        public IdentityUser2 GetUser(string id)//---
        {
            return _urepository.GetUser(id);
        }
        public IdentityUser2 UpdateUser(IdentityUser2 user)//---
        {
            return _urepository.UpdateUser(user);
        }



        public async Task AddUserAsync(IdentityUser2 user)
        {
            await _urepository.AddUserAsync(user);
        }
        public async Task<IdentityUser2> UpdateUserAsync(IdentityUser2 user)
        {
            return await _urepository.UpdateUserAsync(user);
        }
        public async Task<IdentityUser2> GetUserAsync(string id)
        {
            return await _urepository.GetUserAsync(id);
        }

  
    }
}