using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogHost.Domain;

namespace BlogHost.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BlogContext bc = new BlogContext();
            
            ViewBag.value = bc.Tags;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A simple blog application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}