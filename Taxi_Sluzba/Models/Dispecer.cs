using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxi_Sluzba.Models
{
    public class Dispecer : Korisnik
    {
        public Dispecer() :base()
        {
            this.Uloga = Enums.Uloge.Dispecer;
        }
    }
}