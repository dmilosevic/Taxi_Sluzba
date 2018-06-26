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

        [NoDirectAccess]
        public ActionResult ChangeLocation()
        {
            Vozac vozac = Session["User"] as Vozac;
            return View("ChangeLocation", vozac);
        }

        [NoDirectAccess]
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
        }

        [NoDirectAccess]
        public ActionResult PreuzmiVoznju(string id)
        {
            Dictionary<string, Voznja> voznje = HttpContext.Application["voznje"] as Dictionary<string, Voznja>;
            Voznja voznja = voznje[id];
            
            
            voznja.Vozac = Session["User"] as Vozac;
            voznja.Status = Enums.StatusVoznje.PRIHVACENA;
            Helpers.Functions.ZauzmiVozaca(voznja.Vozac.UserName);

            return RedirectToAction("Index");
        }

        [NoDirectAccess]
        public ActionResult ZavrsiVoznju(string id)
        {
            Dictionary<string, Voznja> voznje = HttpContext.Application["voznje"] as Dictionary<string, Voznja>;
            Voznja voznja = voznje[id];

            return View(voznja);
        }

        [NoDirectAccess]
        public ActionResult VoznjaZavrsena(Voznja v)
        {
            Dictionary<string, Voznja> voznje = HttpContext.Application["voznje"] as Dictionary<string, Voznja>;
            Voznja voznja = voznje[v.ID];
            
            voznja.Status = v.Status;
            if(voznja.Status == Enums.StatusVoznje.USPESNA)
            {
                voznja.Odrediste = new Lokacija(0, 0, v.Odrediste.Adresa);
                voznja.Iznos = v.Iznos;
            }
            else if(voznja.Status == Enums.StatusVoznje.NEUSPESNA)
            {
                voznja.Komentar = new Komentar(v.Komentar.Opis);
            }

            Helpers.Functions.OslobodiVozaca(voznja.Vozac.UserName);

            return RedirectToAction("Index");
        }

        //Potpuno isti kontroler kao i za musteriju sa postpuno istim pogledom, ostavljeno u slucaju da vozac ima veci uvid u podatke od musterije
        [NoDirectAccess]
        public ActionResult Details(string id)
        {
            Dictionary<string, Voznja> voznje = HttpContext.Application["voznje"] as Dictionary<string, Voznja>;
            Voznja voznja = voznje[id];

            return View(voznja);
        }

        
    }
}