using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxi_Sluzba.Models;
using Taxi_Sluzba.ViewModel;

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

            if (k != null)
            {
                //vrati odgovarajuci VIEW u zavisnosti od uloge korisnika    
                switch (k.Uloga)
                {
                    case Taxi_Sluzba.Enums.Uloge.Musterija:
                        return RedirectToAction("Index", "Musterija");
                    case Taxi_Sluzba.Enums.Uloge.Vozac:
                        return RedirectToAction("Index", "Vozac");
                    case Taxi_Sluzba.Enums.Uloge.Dispecer:
                        return RedirectToAction("Index", "Dispecer");
                    default:
                        break;
                }
            }

            return RedirectToAction("Index", "Home");
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
            Korisnik updated;

            CopyData(ref k, out updated);
            Session["User"] = updated;

            Dictionary<string, Korisnik> korisnici = HttpContext.Application["korisnici"] as Dictionary<string, Korisnik>;
            korisnici[k.UserName] = updated;
           

            return RedirectToAction("Welcome");
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

        public ActionResult ChangeLocation()
        {
            return View();
        }

        public ActionResult Pretraga(string userID)
        {
            Korisnik kor = (HttpContext.Application["korisnici"] as Dictionary<string, Korisnik>)[userID];
            KorisnikVoznjeVM model = new KorisnikVoznjeVM()
            {
                Korisnik = kor,
                Voznje = kor.Voznje,
            };
            return View(model);
        }

        public ActionResult Pretrazi(KorisnikVoznjeVM model)
        {
            Korisnik kor = (HttpContext.Application["korisnici"] as Dictionary<string, Korisnik>)[model.Korisnik.UserName];
            IEnumerable<Voznja> voz = kor.Voznje;

            #region filteri
            //datum
            if(model.PretragaDetails.DatumStart != null)
            {
                if(model.PretragaDetails.DatumEnd != null)
                {
                    voz = voz.Where(v => (v.DatumIVreme >= model.PretragaDetails.DatumStart && v.DatumIVreme <= model.PretragaDetails.DatumEnd));
                }
                else
                {
                    voz = voz.Where(v => v.DatumIVreme >= model.PretragaDetails.DatumStart);
                }
            }
            else if(model.PretragaDetails.DatumEnd != null)
            {
                voz = voz.Where(v => v.DatumIVreme <= model.PretragaDetails.DatumEnd);
            }

            //cena
            if(model.PretragaDetails.CenaStart != 0)
            {
                if(model.PretragaDetails.CenaEnd != 0)
                {
                    voz = voz.Where(v => v.Iznos >= model.PretragaDetails.CenaStart && v.Iznos <= model.PretragaDetails.CenaEnd);
                }
                else
                {
                    voz = voz.Where(v => v.Iznos >= model.PretragaDetails.CenaStart);
                }
            }
            else if(model.PretragaDetails.CenaEnd != 0)
            {
                voz = voz.Where(v => v.Iznos <= model.PretragaDetails.CenaEnd);
            }

            //ocena
            if (model.PretragaDetails.OcenaStart != 0)
            {
                if (model.PretragaDetails.OcenaEnd != 0)
                {
                    voz = voz.Where(v => v.Komentar.Ocena >= model.PretragaDetails.OcenaStart && v.Komentar.Ocena <= model.PretragaDetails.OcenaEnd);
                }
                else
                {
                    voz = voz.Where(v => v.Komentar.Ocena >= model.PretragaDetails.OcenaStart);
                }
            }
            else if (model.PretragaDetails.OcenaEnd != 0)
            {
                voz = voz.Where(v => v.Komentar.Ocena <= model.PretragaDetails.OcenaEnd);
            }
            #endregion

            KorisnikVoznjeVM filtered = new KorisnikVoznjeVM()
            {
                Korisnik = kor,
                Voznje = voz,
            };
            return View("Pretraga", filtered);
        }
    }
}
