using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lost.Models
{
    //Для сохранения статистики о вещах
    public class FullUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { set; get; }
        public List<Guid> FoundThings { get; set; }
        public List<Guid> LostThings { get; set; }  
    }
}