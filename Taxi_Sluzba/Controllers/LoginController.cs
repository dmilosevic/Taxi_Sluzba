﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxi_Sluzba.Models;

namespace Taxi_Sluzba.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if(Session["user"] != null)
            {
                Korisnik k = Session["user"] as Korisnik;
                if (k.IsLoggedIn)
                    return View("AlreadyLoggedIn", k);
            }
            return View("Login");
        }

        public ActionResult CheckLogin(string username, string password)
        {
            Dictionary<string, Korisnik> korisnici = HttpContext.Application["korisnici"] as Dictionary<string, Korisnik>;
            if (korisnici == null)
                return View("Login");

            if (!korisnici.ContainsKey(username))
                return View("Error");

            Korisnik korisnik = null;
            if (korisnici[username].Password == password)
                korisnik = korisnici[username];
            else
                return View("Error");

            //successful login            
            Session["user"] = korisnik;
            korisnik.IsLoggedIn = true;

            //vrati odgovarajuci VIEW u zavisnosti od uloge korisnika            
            switch(korisnik.Uloga)
            {
                case Enums.Uloge.Musterija: return View("~/Views/Main/MusterijaView.cshtml", korisnik);
                case Enums.Uloge.Vozac: return View("~/Views/Main/VozacView.cshtml", korisnik);
                case Enums.Uloge.Dispecer: return View("~/Views/Main/DispecerView.cshtml", korisnik);
                default: return View("Login");
            }
        }

        public ActionResult Logout()
        {
            Korisnik k = null;
            k = Session["user"] as Korisnik;
            if(k != null)
            {
                k.IsLoggedIn = false;
                Session["user"] = null;
            }
            return View("~/Views/Login/Login.cshtml");
           // return Index();
            //Response.Redirect("~/Views/Login/Login.cshtml");

        }
    }
}