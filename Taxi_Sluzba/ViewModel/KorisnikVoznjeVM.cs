using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taxi_Sluzba.Models;
using Taxi_Sluzba.Enums;

namespace Taxi_Sluzba.ViewModel
{
    public class KorisnikVoznjeVM
    {
        public Korisnik Korisnik { get; set; }
        public IEnumerable<Voznja> Voznje { get; set; }
        public string Status { get; set; }
    }
}