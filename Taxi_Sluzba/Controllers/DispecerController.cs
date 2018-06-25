using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxi_Sluzba.Models;

namespace Taxi_Sluzba.Controllers
{
    public class DispecerController : Controller
    {
        // GET: Dispecer
        [NoDirectAccess]
        public ActionResult Index()
        {
            return View("DispecerView");
        }

        [NoDirectAccess]
        public ActionResult Details(string id)
        {
            Dictionary<string, Voznja> voznje = HttpContext.Application["voznje"] as Dictionary<string, Voznja>;
            Voznja voznja = voznje[id];

            return View(voznja);
        }

        [NoDirectAccess]
        public ActionResult ObradiVoznju(string id)
        {
            Dictionary<string, Voznja> voznje = HttpContext.Application["voznje"] as Dictionary<string, Voznja>;
            Voznja voznja = voznje[id];

            return View(voznja);
        }

        [NoDirectAccess]
        public ActionResult VoznjaObradjena(Voznja v)
        {
            Voznja updated = (HttpContext.Application["voznje"] as Dictionary<string, Voznja>)[v.ID];
            updated.Vozac = v.Vozac;
            updated.Status = Enums.StatusVoznje.OBRADJENA;
            updated.Dispecer = Session["User"] as Dispecer;

            return View("DispecerView");
        }
    }
}