using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxi_Sluzba.Models;

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
            Korisnik k = Session["User"] as Korisnik;
            return View(k);
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

        public ActionResult ChangeUserData()
        {
            Korisnik k = Session["User"] as Korisnik;
            return View("ChangeUserData", k);
        }

        [HttpPost]
        public ActionResult UpdateChanges(Korisnik k)
        {
            Korisnik updated; //Session["User"] as Korisnik;

            CopyData(ref k, out updated);
            Session["User"] = updated;

            Dictionary<string, Korisnik> korisnici = HttpContext.Application["korisnici"] as Dictionary<string, Korisnik>;
            korisnici[k.UserName] = updated;
           

            return View("Welcome", k);
        }

        private void CopyData(ref Korisnik A, out Korisnik B)
        {
            B = Session["User"] as Korisnik;

            B.Email = A.Email;
            B.Ime = A.Ime;
            B.Prezime = A.Prezime;
            B.Pol = A.Pol;
            B.Password = A.Password;
            B.JMBG = A.JMBG;
        }

    }
}