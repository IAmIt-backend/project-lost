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
        void AddUser(IdentityUser user);
        IdentityUser GetUser(string id);
        IdentityUser UpdateUser(IdentityUser user);
    }
}