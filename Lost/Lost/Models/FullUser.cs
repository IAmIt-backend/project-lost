using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lost.Models
{
    //Для сохранения статистики о вещах
    public class FullUser:User
    {
        public List<Guid> FoundThings { get; set; }
        public List<Guid> LostThings { get; set; }  
    }
}