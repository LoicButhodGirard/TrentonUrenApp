﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrentonTestApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Urenregistratie()
        {
            return View();
        }

        public ActionResult Urenoverzicht()
        {
            return View();
        }

        public ActionResult Projectbeheer()
        {
            return View();
        }

        public ActionResult Accountbeheer()
        {
            return View();
        }

        public ActionResult Installatieinstructie()
        {
            return View();
        }
    }
}