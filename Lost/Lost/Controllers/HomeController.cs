
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.Interfaces;
using BL.Implementation;
using Lost.ViewModel;
using DB.Models;

namespace Lost.Controllers
{
    public class HomeController : Controller
    {
        private readonly BL.Interfaces.IBusinessLogic _logic = new BL.Implementation.BusinessLogic();

        [HttpPost]
        public ActionResult Index(string status, string place, string about, string description)
        {
            string total = "0";
            Thing thing;            
            if (status.Equals("lost"))
            {
                thing = new Thing
                {
                    About = about,
                    Description = description,
                    Place = place,
                    ItemStatus = ItemStates.Lost
                };                
            }
            else
            {
                thing = new Thing
                {
                    About = about,
                    Description = description,
                    Place = place,
                    ItemStatus = ItemStates.Found
                };
            }
            _logic.AddThing(thing);
            return View(new IndexViewModel
            {
                Text = total
            });

        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new IndexViewModel
            {
                Text = ""
            });
        }
    }
}
