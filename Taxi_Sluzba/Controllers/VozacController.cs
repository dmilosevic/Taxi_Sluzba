using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxi_Sluzba.Models;

namespace Taxi_Sluzba.Controllers
{
    public class VozacController : Controller
    {
        // GET: Vozac
        [NoDirectAccess]
        public ActionResult Index()
        {
            Vozac vozac = Session["User"] as Vozac;

            return View("VozacView", vozac);
        }

        public ActionResult ChangeLocation()
        {
            Vozac vozac = Session["User"] as Vozac;
            return View("ChangeLocation", vozac);
        }

        [HttpPost]
        public ActionResult ApplyChanges(Vozac v)
        {
            Vozac updated; //Session["User"] as Korisnik;

            CopyData(ref v, out updated);
            Session["User"] = updated;

            Dictionary<string, Korisnik> korisnici = HttpContext.Application["korisnici"] as Dictionary<string, Korisnik>;
            korisnici[v.UserName] = updated;
            return RedirectToAction("ChangeLocation");
        }

        private void CopyData(ref Vozac A, out Vozac B)
        {
            B = Session["User"] as Vozac;

            B.Lokacija = A.Lokacija;
            //B = A.Ime;
            //B.Prezime = A.Prezime;
            //B.Pol = A.Pol;
            //B.Password = A.Password;
            //B.JMBG = A.JMBG;
        }
    }
}