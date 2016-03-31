
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
        public ActionResult ThingAdd(string status, string place, string about, string description, string submitButton, string returnButton)
        {
            //  string total = "0";
            
           
            //   return this.RedirectToAction("Info", "Home");
            if (submitButton != null) {
                Thing thing;
                if (status.Equals("lost"))
                {
                    thing = new Thing
                    {
                        About = about,
                        Description = description,
                        Place = place,
                        UserId = new ObjectId(User.Identity.GetUserId()),
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
                        UserId = new ObjectId(User.Identity.GetUserId()),
                        ItemStatus = ItemStates.Found
                    };
                }
                _logic.AddThing(thing);
                return View(new IndexViewModel
            {
                Text = ""
            });
            }
            else
            {
                return this.RedirectToAction("Index", "Home");
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
        public ActionResult Index(string search, string searchButton, string addButton, string status)
        {
          
            if(searchButton != null)
            {
                List<Thing> list;
                if (status.Equals("lost"))
                {
                    list = _logic.FindThing(search, ItemStates.Lost);
                }
                else
                {
                    list = _logic.FindThing(search, ItemStates.Found);
                }
                
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
