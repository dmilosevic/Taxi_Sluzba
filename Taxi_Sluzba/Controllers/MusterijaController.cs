using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxi_Sluzba.Models;

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

        [NoDirectAccess]
        public ActionResult ZahtevVoznje()
        {
            return View();
        }

        [NoDirectAccess]
        public ActionResult KreirajVoznju(Voznja voznja)
        {
            /*
             * OVDE JE PROBLEM VALIDACIJA
             * UPISUJE VOZNJE IAKO SU SVI PODACI OSTAVLJENI PRAZNI
             * SREDI TAJ BAG NA KRAJU
             * */
            voznja.DatumIVreme = DateTime.Now;
            voznja.ID = voznja.DatumIVreme.GetHashCode().ToString();
            voznja.Status = Enums.StatusVoznje.KREIRANA_NA_CEKANJU;
            voznja.Musterija = Session["User"] as Musterija;

            Dictionary<string, Voznja> voznje = HttpContext.Application["voznje"] as Dictionary<string, Voznja>;
            voznje.Add(voznja.ID, voznja);
            
            return View("MusterijaView");
        }

        public ActionResult OtkaziVoznju(string id)
        {
            Dictionary<string, Voznja> voznje = HttpContext.Application["voznje"] as Dictionary<string, Voznja>;
            voznje.Remove(id);
            return View("MusterijaView");
        }
    }
}