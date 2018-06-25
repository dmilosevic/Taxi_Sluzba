using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taxi_Sluzba.Models
{
    public class Adresa
    {
        [Required (ErrorMessage = "Morate uneti adresu")]
        public string Ulica { get; set; }

        [Required(ErrorMessage = "Morate uneti kucni broj")]
        public int Broj { get; set; }

        [Required(ErrorMessage = "Morate uneti mesto")]
        public string Mesto { get; set; }

        [Required(ErrorMessage = "Morate uneti pozivni broj")]
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