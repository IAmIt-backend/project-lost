using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DB.Models;

namespace Lost.ViewModel
{
    public class IndexViewModel
    {
        public string Text { set; get; }
        public int Length { set; get; }
        public List<Thing> Things { set; get; }
    }
}