using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taxi_Sluzba.Models;

namespace Taxi_Sluzba.Helpers
{
    public class Functions
    {
        public static void ZauzmiVozaca(string vozacUserName)
        {
            Dictionary<string, Korisnik> korisnici = HttpContext.Current.Application["korisnici"] as Dictionary<string, Korisnik>;

            Vozac vozac = korisnici[vozacUserName] as Vozac;
            vozac.IsAvailable = false;
        }

        public static void OslobodiVozaca(string vozacUserName)
        {
            Dictionary<string, Korisnik> korisnici = HttpContext.Current.Application["korisnici"] as Dictionary<string, Korisnik>;

            Vozac vozac = korisnici[vozacUserName] as Vozac;
            vozac.IsAvailable = true;
        }
    }
}