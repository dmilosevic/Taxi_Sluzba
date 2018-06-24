using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taxi_Sluzba.Controllers
{
    public class MusterijaController : Controller
    {
        // GET: Musterija
        [NoDirectAccess]
        public ActionResult Index()
        {
            return View("MusterijaView");
        }
    }
}