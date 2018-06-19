using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxi_Sluzba.Models
{
    public class Vozac : Korisnik
    {
        public Lokacija Lokacija { get; set; }
        public Automobil Automobil { get; set; }

        public Vozac() : base()
        {
            this.Uloga = Enums.Uloge.Vozac;
        }

    }
}