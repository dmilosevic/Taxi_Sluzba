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
            Korisnik k4 = new Musterija()
            {
                UserName = "Danilo",
                Password = "123",
                //Uloga = Enums.Uloge.Vozac,
            };
            Korisnik k5 = new Vozac()
            {
                UserName = "Soferdzija",
                Password = "123",
                Ime="Kristijan",
                Prezime = "Dolanc"
            };
            users.Add(k1.UserName, k1);
            users.Add(k2.UserName, k2);
            users.Add(k3.UserName, k3);
            users.Add(k4.UserName, k4);
            users.Add(k5.UserName, k5);

            HttpContext.Current.Application["korisnici"] = users;

            //Voznje baza podataka
            Dictionary<string, Voznja> voznje = new Dictionary<string, Voznja>();
            //voznje.Add("12", new Voznja()
            //{
            //    ID = "12",
            //    Status = Enums.StatusVoznje.FORMIRANA,
            //    Vozac = k3 as Vozac,
            //    LokacijaMusterije = new Lokacija(10, 10, new Adresa()),
            //});
            HttpContext.Current.Application["voznje"] = voznje;
        }

        //dodato jer stackoverflow tako kaze i resava bag -.-
        protected void Session_Start()
        {
        }
    }
}
