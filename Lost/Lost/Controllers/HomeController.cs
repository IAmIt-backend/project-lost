
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Interfaces;
using Lost.ViewModel;

namespace Lost.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Index(string status, string place, string about, string description)
        {

            string total = "0";
  
                total = status + " " + place + " " + about + " " + description;
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
