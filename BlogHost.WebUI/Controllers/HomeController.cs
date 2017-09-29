﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogHost.Domain;

namespace BlogHost.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BlogContext bc = new BlogContext();
            /*if (bc.Tags.Count() == 0)
            {
                bc.Tags.Add(new Tag() {Name = "oleg"});
                bc.Tags.Add(new Tag() {Name = "oleg2"});
                bc.SaveChanges();
            }*/
            ViewBag.value = bc.Tags;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}