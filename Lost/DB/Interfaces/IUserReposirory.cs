﻿using System;
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
        IdentityUser GetUser(string id);
        IdentityUser UpdateUser(IdentityUser user);
    }
}
