﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taxi_Sluzba.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult Musterija()
        {
            return View("MusterijaView");
        }
        public ActionResult Vozac()
        {
            return View("VozacView");
        }
        public ActionResult Dispecer()
        {
            return View("DispecerView");
        }


    }
}