
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
        private BusinessLogic.Interfaces.IBusinessLogic _logic = new BusinessLogic.Implementation.BusinessLogic();
        private BusinessLogic.Interfaces.IUserLogic _userlogic = new BusinessLogic.Implementation.UserLogic();

        [HttpPost]
        public ActionResult ThingAdd(ItemStates status, string place, string about, string description, string submitButton)
        {

            if (submitButton != null)
            {
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

            if (searchButton != null)
            {
                List<Thing> list = new List<Thing>();

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
        [HttpGet]
        public ActionResult ThingInfo(string thingId)
        {
            Thing thing = new Thing();
            thing = _logic.GetThingById(new ObjectId(thingId));
            return View(new IndexViewModel
            {
                //Text = thingId,
                ThingId = thing.Id,
                About = thing.About,
                Description = thing.Description,
                Place = thing.Place,
                Status = thing.ItemStatus,
                UserId = thing.UserId
            });
        }
        [HttpPost, Authorize]
        public ActionResult ThingInfo(string status, string about, string description, string place, string deleteButton, string editButton, string thingId)
        {
              if (deleteButton != null)
            {
                Thing thing = _logic.DeleteThing(new ObjectId(thingId));
                return this.RedirectToAction("Index", "Home");
            }
            else if(editButton != null)
            {
                Thing thing = new Thing
                {
                    About = about,
                    Id = new ObjectId(thingId),
                    Description = description,
                    Place = place,
                    UserId = new ObjectId(User.Identity.GetUserId()),
                    ItemStatus = ItemStates.Lost
                };
                if (status.Equals("Found")) {
                    thing.ItemStatus = ItemStates.Found;                
                }
                 thing = _logic.UpdateThing(thing);
                
                return View(new IndexViewModel
                {
                    //Text = thingId,
                    ThingId = thing.Id,
                    About = thing.About,
                    Description = thing.Description,
                    Place = thing.Place,
                    Status = thing.ItemStatus,
                    UserId = thing.UserId
                });
             }
            else
            {
                return View(new IndexViewModel
                {
                 
                });
            }
            
        }
        [HttpGet]
        public ActionResult UserProfile( string userId)
        {

            User user = new User();
            user = _userlogic.GetUser(userId);
            return View(new IndexViewModel
                {
                    Id = userId,
                    UserName = user.UserName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Phone = user.Phone  
                   
           
            });
        }
        [HttpPost]
        public ActionResult UserProfile(string fname, string lname, string email, string phone, string userId, string thingId, string editButton)
        {

            if (editButton != null)
            {
                User user = new User
                {
                    LastName = lname,
                    Id = userId,
                    Phone = phone,
                    UserName = fname,
                    Email = email
                };
               
                user = _userlogic.UpdateUser(user);

                return View(new IndexViewModel
                {
                    LastName = lname,
                    Id = userId,
                    Phone = phone,
                    UserName = fname,
                    Email = email
                });
            }
            else
            {
                return View(new IndexViewModel
                {
                });
                }
        }



    }
}
