using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TelerikMvcApp4.Controllers
{
    public class CarViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }


        public string Type { get; set; }




    }







    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
