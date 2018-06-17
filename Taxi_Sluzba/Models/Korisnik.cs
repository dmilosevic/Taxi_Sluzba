using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taxi_Sluzba.Enums;

namespace Taxi_Sluzba.Models
{
    public abstract class Korisnik
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public Pol Pol { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        //uloga ??
        public List<Voznja> Voznje { get; set; }
    }
}