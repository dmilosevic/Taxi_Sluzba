using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxi_Sluzba.Models;
using Taxi_Sluzba.ViewModel;

namespace Taxi_Sluzba.Controllers
{
    public class DispecerController : Controller
    {
        // GET: Dispecer
        [NoDirectAccess]
        public ActionResult Index(string filter, string sort)
        {
            Dispecer dispecer = Session["User"] as Dispecer;
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
                Korisnik = dispecer,
                Voznje = voz,
                Status = filterMode,
            };

            return View("DispecerView", model);
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

            Vozac vozac = ((HttpContext.Application["korisnici"] as Dictionary<string, Korisnik>)[v.Vozac.UserName] as Vozac);
            vozac.Voznje.Add(updated);
            updated.Vozac = v.Vozac;

            Helpers.Functions.ZauzmiVozaca(v.Vozac.UserName);

            updated.Status = Enums.StatusVoznje.OBRADJENA;
            Dispecer disp = Session["User"] as Dispecer;
            updated.Dispecer = disp;
            disp.Voznje.Add(updated);

            return RedirectToAction("Index");
        }

        [NoDirectAccess]
        public ActionResult FormirajVoznju()
        {
            return View();
        }

        [NoDirectAccess]
        public ActionResult FormiranaVoznja(Voznja voznja)
        {
            voznja.DatumIVreme = DateTime.Now;
            voznja.ID = voznja.DatumIVreme.GetHashCode().ToString();
            voznja.Status = Enums.StatusVoznje.FORMIRANA;
            Dispecer disp = Session["User"] as Dispecer;
            voznja.Dispecer = disp;
            disp.Voznje.Add(voznja);

            Vozac vozac = ((HttpContext.Application["korisnici"] as Dictionary<string, Korisnik>)[voznja.Vozac.UserName] as Vozac);
            vozac.Voznje.Add(voznja);

            Helpers.Functions.ZauzmiVozaca(vozac.UserName);

            Dictionary<string, Voznja> voznje = HttpContext.Application["voznje"] as Dictionary<string, Voznja>;
            voznje.Add(voznja.ID, voznja);

            return RedirectToAction("Index");
        }
    }
}