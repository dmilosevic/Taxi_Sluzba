using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taxi_Sluzba.Enums;

namespace Taxi_Sluzba.Models
{
    public class Automobil
    {
        public Vozac Vozac { get; set; }
        public int Godiste { get; set; }
        public string RegOznaka { get; set; }
        public string BrojVozila { get; set; }
        public TipAutomobila Tip { get; set; }

       
    }
}