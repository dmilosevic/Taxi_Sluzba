using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Taxi_Sluzba.Models;

namespace Taxi_Sluzba
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //zameni ucitavanjem iz fajla
            Dictionary<string, Korisnik> users = new Dictionary<string, Korisnik>();
            Korisnik k1 = new Musterija()
            {
                UserName = "Pera",
                Password = "123",
                //Uloga = Enums.Uloge.Musterija,
            };
            Korisnik k2 = new Dispecer()
            {
                UserName = "Pekar",
                Password = "123",
                //Uloga = Enums.Uloge.Dispecer,
            };
            Korisnik k3 = new Vozac()
            {
                UserName = "Flojd",
                Password = "123",
                Ime="Dragan",
                Prezime="Nikolic"
                //Uloga = Enums.Uloge.Vozac,
            };
            users.Add(k1.UserName, k1);
            users.Add(k2.UserName, k2);
            users.Add(k3.UserName, k3);


            HttpContext.Current.Application["korisnici"] = users;
        }

        //dodato jer stackoverflow tako kaze i resava bag -.-
        protected void Session_Start()
        {
        }
    }
}
