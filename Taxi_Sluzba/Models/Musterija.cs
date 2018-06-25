using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxi_Sluzba.Models
{
    public class Musterija : Korisnik
    {
        public Musterija() :base()
        {
            this.Uloga = Enums.Uloge.Musterija;
        }

        public override string ToString()
        {
            return UserName + ", " + Ime;
        }
    }
}