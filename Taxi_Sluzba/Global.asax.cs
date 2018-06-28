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

            Dictionary<string, Korisnik> users = new Dictionary<string, Korisnik>();

            string file = Server.MapPath("~/Helpers/dispeceri.txt");
            List<Korisnik> dispeceri = Helpers.DataAccess.GetAdministratoreIzFajla(file);
            Korisnik k1 = new Musterija()
            {
                UserName = "Pera",
                Password = "123",
            };
            Korisnik k3 = new Vozac()
            {
                UserName = "Flojd",
                Password = "123",
                Ime="Dragan",
                Prezime="Nikolic"
            };
            Korisnik k4 = new Musterija()
            {
                UserName = "Danilo",
                Password = "123",
            };
            Korisnik k5 = new Vozac()
            {
                UserName = "Soferdzija",
                Password = "123",
                Ime="Kristijan",
                Prezime = "Dolanc"
            };
            users.Add(k1.UserName, k1);
            users.Add(k3.UserName, k3);
            users.Add(k4.UserName, k4);
            users.Add(k5.UserName, k5);
            dispeceri.ForEach(d => users.Add(d.UserName, d));

            HttpContext.Current.Application["korisnici"] = users;

            //Voznje baza podataka
            Dictionary<string, Voznja> voznje = new Dictionary<string, Voznja>();
            HttpContext.Current.Application["voznje"] = voznje;
        }

        //dodato jer stackoverflow tako kaze i resava bag -.-
        protected void Session_Start()
        {
        }
    }
}
