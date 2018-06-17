using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxi_Sluzba.Models
{
    public class Lokacija
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Adresa Adresa { get; set; }

        public Lokacija(int X, int Y, Adresa adr)
        {
            this.X = X;
            this.Y = Y;
            Adresa = adr;
        }
    }
}