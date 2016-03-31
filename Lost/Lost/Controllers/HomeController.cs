
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Interfaces;
using Lost.ViewModel;
using DB.Models;
using Microsoft.AspNet.Identity;
using MongoDB.Bson;

namespace Lost.Controllers
{
    public class HomeController : Controller
    {
        private BusinessLogic.Interfaces.IBusinessLogic _logic = new Business.BLClass.BusinessLogic();

        [HttpPost]
        public ActionResult ThingAdd(ItemStates status, string place, string about, string description, string submitButton)
        {
         
               if (submitButton != null) {
                Thing thing;
               
                thing = new Thing
                {
                    About = about,
                    Description = description,
                    Place = place,
                    UserId = new ObjectId(User.Identity.GetUserId()),
                    ItemStatus = status
                };
                _logic.AddThing(thing);
                return this.RedirectToAction("Index", "Home");
            }
            else
            {
                return View(new IndexViewModel
                {
                    Text = ""
                });
            }
        }
        [HttpGet, Authorize]
        public ActionResult ThingAdd()
        {
            return View(new IndexViewModel
            {
                Text = ""
            });
        }



        [HttpPost]
        public ActionResult Index(string search, string searchButton, string addButton, ItemStates status)
        {
         
            if(searchButton != null)
            {
                List<Thing> list;
              
                    list = _logic.FindThing(search, status);
                return View(new IndexViewModel
                 {
                        Text = "",
                        Things = list,
                        Length = list.Count
                });
            }
            else
            {
                return this.RedirectToAction("ThingAdd", "Home");
            }   
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
