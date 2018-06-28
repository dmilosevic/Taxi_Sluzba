using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxi_Sluzba.Models;
using Taxi_Sluzba.ViewModel;

namespace Taxi_Sluzba.Controllers
{
    public class MusterijaController : Controller
    {
        // GET: Musterija
        [NoDirectAccess]
        public ActionResult Index(string filter, string sort)
        {
            Musterija musterija = Session["User"] as Musterija;
            string filterMode = filter;
            var voz = from s in (HttpContext.Application["voznje"] as Dictionary<string, Voznja>).Values
                      select s;

            if (filter != null)
                voz = Helpers.Functions.GetFilteredData(voz, filter);
            else
                filter = "";

            if (sort != null)
                voz = Helpers.Functions.GetSortedData(voz, sort);
            else
                sort = "";

            KorisnikVoznjeVM model = new KorisnikVoznjeVM()
            {
                Korisnik = musterija,
                Voznje = voz,
                Status = filterMode,
            };

            return View("MusterijaView", model);
        }

        [NoDirectAccess]
        public ActionResult ZahtevVoznje()
        {
            return View();
        }

        [NoDirectAccess]
        public ActionResult KreirajVoznju(Voznja voznja)
        {            
            voznja.DatumIVreme = DateTime.Now;
            voznja.ID = voznja.DatumIVreme.GetHashCode().ToString();
            voznja.Status = Enums.StatusVoznje.KREIRANA_NA_CEKANJU;
            Musterija musterija = Session["User"] as Musterija;

            voznja.Musterija = musterija;
            musterija.Voznje.Add(voznja);

            Dictionary<string, Voznja> voznje = HttpContext.Application["voznje"] as Dictionary<string, Voznja>;
            voznje.Add(voznja.ID, voznja);

            return RedirectToAction("Index");
        }

        [NoDirectAccess]
        public ActionResult OtkaziVoznju(string id)
        {
            Dictionary<string, Voznja> voznje = HttpContext.Application["voznje"] as Dictionary<string, Voznja>;
            Voznja voznja = voznje[id];
            voznja.Status = Enums.StatusVoznje.OTKAZANA;

            return View("Otkazi", voznja);//voznja);
        }

        [NoDirectAccess]
        public ActionResult KomentarOstavljen(string id, string opis, int ocena)
        {
            Voznja voznja = (HttpContext.Application["voznje"] as Dictionary<string, Voznja>)[id];
            voznja.Komentar = new Komentar()
            {
                DatumObjave = DateTime.Now,
                Korisnik = Session["User"] as Korisnik,
                Ocena = ocena,
                Opis = opis,
                Voznja = voznja,                
            };
            return RedirectToAction("Index");
        }

        [NoDirectAccess]
        public ActionResult Details(string id)
        {
            Dictionary<string, Voznja> voznje = HttpContext.Application["voznje"] as Dictionary<string, Voznja>;
            Voznja voznja = voznje[id];

            return View(voznja);
        }

        [NoDirectAccess]
        public ActionResult Izmeni(string id)
        {
            Dictionary<string, Voznja> voznje = HttpContext.Application["voznje"] as Dictionary<string, Voznja>;
            Voznja voznja = voznje[id];

            return View(voznja);
        }

        [NoDirectAccess]
        public ActionResult UpdateVoznjaData(Voznja v)
        {
            Voznja updated = (HttpContext.Application["voznje"] as Dictionary<string, Voznja>)[v.ID];
            updated.TipAutomobila = v.TipAutomobila;
            updated.LokacijaMusterije.Adresa = v.LokacijaMusterije.Adresa;

            return RedirectToAction("Index");
        }

        [NoDirectAccess]
        public ActionResult KomentarNaVoznju(Voznja v)
        {
            Voznja updated = (HttpContext.Application["voznje"] as Dictionary<string, Voznja>)[v.ID];
            return View("Otkazi", updated); //promeniti ime View-a sa otkazi na nesto tipa "komentarisanje"
        }
    }
}