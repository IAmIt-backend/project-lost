
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lost.ViewModel;

namespace Lost.Controllers
{
    public class ThingController : Controller
    {
        [HttpPost]
        public ActionResult Index(string text0, string text1, string text2, string text3) // bool found, bool lost-)
        {
            var place = text1;
            var about = text2;
            var description = text3;
            string total = "0";
            if (text0=="Lost")
            {
                
            }
            else if(text0=="Found")
            {

            }
            return View(new IndexViewModels
            {
                text = total
            });

        }

        [HttpGet]
        public ActionResult Index()
        {

            return View(new IndexViewModels
            {
                text = ""
            });
        }
    }
}
