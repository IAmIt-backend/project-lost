using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lost.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Phone { set; get; }
        public string Email { get; set; }
    }
}