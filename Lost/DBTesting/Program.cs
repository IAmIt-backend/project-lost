using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Models;
using DB.Repositories;

namespace DBTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var _things = new DbThingRepository();
            var _retThings = new DbThingReturnedRepository();
            int a;
            string about, place, descr;
            Thing thing = new Thing();
            for (int i = 0; i < 10; i++)
            {
                thing.About = "Cat";
                thing.Place = "Moskov";
                thing.Description = "Cat" + i;
                thing.ItemStatus = ItemStates.Lost;
                _things.AddThing(thing);
            }
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
