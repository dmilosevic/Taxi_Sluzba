using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxi_Sluzba.Models
{
    public class Adresa
    {
        public string Ulica { get; set; }
        public int Broj { get; set; }
        public string Mesto { get; set; }
        public int PozivniBroj { get; set; }

        public Adresa()
        {

        }

        public override string ToString()
        {
            return $"{Ulica} {Broj}, {Mesto} {PozivniBroj}";
        }
    }
}