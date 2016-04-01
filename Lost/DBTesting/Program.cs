using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DB.Interfaces;
using DB.Models;
using DB.Repositories;
using MongoDB.Bson;

namespace DBTesting
{
    class Program
    {
        private static readonly IThingRepository _things = new DbThingRepository();
        private static readonly IThingReturnedRepository _retThings = new DbThingReturnedRepository();
        private static readonly IUserReposirory _urepository = new DbUserReposirory();

        async static void MakeDefaltFile()
        {
            User user = new User();
            user.Email = "lost@mail.com";
            user.LastName = "Found";
            user.UserName = "Lost";
            user.Phone = "+123456789";
            user = await _urepository.AddUserAsync(user);
            Thing thing = new Thing();
            for (int i = 0; i < 10; i++)
            {
                thing.About = "Car";
                thing.Place = "Minsk street " + (i + 1);
                thing.Description = "Nissan model " + (i + 1);
                thing.ItemStatus = ItemStates.Lost;
                thing.Id = new ObjectId();
                thing.UserId = user.UserId;
                await _things.AddThingAsync(thing);
            }
            for (int i = 0; i < 10; i++)
            {
                thing.About = "Cat";
                thing.Place = "Moskow street " + (i + 1);
                thing.Description = "Black whith " + (i + 1) + " white spots";
                thing.ItemStatus = ItemStates.Lost;
                thing.Id = new ObjectId();
                thing.UserId = user.UserId;
                await _things.AddThingAsync(thing);
            }
            for (int i = 0; i < 10; i++)
            {
                thing.About = "Dog";
                thing.Place = "Pekin street " + (i + 1);
                thing.Description = "Brown whith " + (i + 1) + " white spots";
                thing.ItemStatus = ItemStates.Lost;
                thing.Id = new ObjectId();
                thing.UserId = user.UserId;
                await _things.AddThingAsync(thing);
            }
            for (int i = 0; i < 10; i++)
            {
                thing.About = "Phone";
                thing.Place = "London street " + (i + 1);
                thing.Description = "Green, screen " + (i + 1) + "' and case";
                thing.ItemStatus = ItemStates.Lost;
                thing.Id = new ObjectId();
                thing.UserId = user.UserId;
                await _things.AddThingAsync(thing);
            }
        }
        static void Main(string[] args)
        {
            int a;
            string about, place, descr;
            MakeDefaltFile();
            Thing thing = new Thing();
            for (;;)
            {
                a = Console.Read();
                if (a == 'a')
                {
                    Console.WriteLine("Add Thing: about, place, description");
                    about = Console.ReadLine();
                    about = Console.ReadLine();
                    place = Console.ReadLine();
                    descr = Console.ReadLine();
                    thing.About = about;
                    thing.Description = descr;
                    thing.Place = place;
                    thing.ItemStatus = ItemStates.Lost;
                    _things.AddThing(thing);
                    Console.WriteLine("Add:Ok");
                }else if (a == 'f')
                {
                    Console.WriteLine("Find Thing: about");
                    about = Console.ReadLine();
                    about = Console.ReadLine();
                    var list = _things.FindThing(about, ItemStates.Lost);
                    foreach (var t in list)
                    {
                        Console.WriteLine(t.About + " " + t.Description + " " + t.Place + " ");
                    }
                    Console.WriteLine("Find:End");
                }else if (a == 'r')
                {
                    Console.WriteLine("Add Returned Thing: about, place, description");
                    about = Console.ReadLine();
                    about = Console.ReadLine();
                    place = Console.ReadLine();
                    descr = Console.ReadLine();
                    thing.About = about;
                    thing.Description = descr;
                    thing.Place = place;
                    thing.ItemStatus = ItemStates.Returned;
                    _retThings.AddThing(thing);
                    Console.WriteLine("AddRet:Ok");
                }else if (a == 'v')
                {
                    Console.WriteLine("Find Returned Thing: about");
                    about = Console.ReadLine();
                    about = Console.ReadLine();
                    var list = _retThings.FindThing(about);
                    foreach (var t in list)
                    {
                        Console.WriteLine(t.About + " " + t.Description + " " + t.Place + " ");
                    }
                    Console.WriteLine("Find:End");
                }else if (a == 'e')
                {
                    break;
                }
            }
        }
    }
}
