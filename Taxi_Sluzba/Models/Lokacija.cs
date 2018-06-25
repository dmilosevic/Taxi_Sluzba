using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taxi_Sluzba.Models
{
    public class Lokacija
    {
        [Required(ErrorMessage = "Morate uneti adresu")]
        public int X { get; set; }
        public int Y { get; set; }

        [Required(ErrorMessage = "Morate uneti adresu")]
        public Adresa Adresa { get; set; }

        public Lokacija(int X, int Y, Adresa adr)
        {
            this.X = X;
            this.Y = Y;
            Adresa = adr;
        }

        public Lokacija()
        {

        }
    }
}