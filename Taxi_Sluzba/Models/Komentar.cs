using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxi_Sluzba.Models
{
    public class Komentar
    {
        public string Opis { get; set; } = string.Empty;
        public DateTime DatumObjave { get; set; }
        public Korisnik Korisnik { get; set; }
        public Voznja Voznja { get; set; }
        public int Ocena { get; set; } = 0;

        public Komentar(string opis)
        {
            Opis = opis;
        }

        public Komentar()
        {
        }
    }
}