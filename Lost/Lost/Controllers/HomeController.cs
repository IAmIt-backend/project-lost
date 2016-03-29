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
        public ActionResult Index(String text1)
        {
            var totalMessage = "";
            try
            {
                if (text1.Length > 0)
                {
                    totalMessage = "Hello " + text1;
                }
            }
            catch (System.NullReferenceException e)
            {
                totalMessage = "";
            }
            return View(new IndexViewModels
            {
                text = totalMessage
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