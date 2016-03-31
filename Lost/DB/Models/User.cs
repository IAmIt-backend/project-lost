using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace DB.Models
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public static User GetUserFromIdentityUser(IdentityUser2 identityUser)
        {
            User user = new User();
            user.Email = identityUser.Email;
            user.LastName = identityUser.LastName;
            user.Phone = identityUser.Phone;
            user.UserName = identityUser.UserName;
            user.Id = new ObjectId(identityUser.Id);
            return user;
        }

        public static IdentityUser2 GetIdentityUserFromIUser(User user)
        {
            IdentityUser2 ideuser = new IdentityUser2();
            ideuser.Email = user.Email;
            ideuser.LastName = user.LastName;
            ideuser.Phone = user.Phone;
            ideuser.UserName = user.UserName;
            ideuser.Id = user.Id.ToString();
            return ideuser;
        }
    }
}
