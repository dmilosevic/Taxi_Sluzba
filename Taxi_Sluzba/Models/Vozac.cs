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
        public bool IsAvailable { get; set; }

        public Vozac() : base()
        {
            this.Uloga = Enums.Uloge.Vozac;
            IsAvailable = true;

            Random r = new Random();
            Lokacija = new Lokacija(r.Next(100), r.Next(100),
                new Adresa()
                {
                    Broj = r.Next(40),
                    Mesto = "Novi Sad",
                    PozivniBroj = r.Next(10000, 30000),
                    Ulica = "Petra Drapsina"
                }
                );
        }

    }
}