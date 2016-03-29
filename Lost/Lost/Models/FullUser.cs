using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace Lost.Models
{
    //Для сохранения статистики о вещах
    public class FullUser:User
    {
        public List<ObjectId> FoundThings { get; set; }
        public List<ObjectId> LostThings { get; set; }  
    }
}