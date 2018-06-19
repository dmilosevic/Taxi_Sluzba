using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxi_Sluzba.Models;

namespace Taxi_Sluzba.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegisterUser(Musterija musterija)
        {
            Response.Write(musterija.UserName);
            return View("Error");
        }
    }
}