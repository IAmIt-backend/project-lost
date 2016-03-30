
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lost.ViewModel;

namespace Lost.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Index(string text0, string text1, string text2, string text3)
        {
            var place = text1;
            var about = text2;
            var description = text3;
            string total = "0";
            if (text0 == "Lost")
            {
                total = text0 + text1 + text2 + text3;
            }
            else if (text0 == "Found")
            {
                total = text0 + text1 + text2 + text3;
            }
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
