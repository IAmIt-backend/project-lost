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

        public void AddUser(IdentityUser user)
        {
            _urepository.AddUser(user);
        }

        public IdentityUser GetUser(string id)
        {
            return _urepository.GetUser(id);
        }
    }
}