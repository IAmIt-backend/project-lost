
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Interfaces;
using Lost.ViewModel;
using DB.Models;

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
        public ActionResult Index(string search, string searchButton, string addButton)
        {
          
            if(searchButton != null)
            {
        return View(new IndexViewModel
            {
                Text = search + " " + searchButton
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
