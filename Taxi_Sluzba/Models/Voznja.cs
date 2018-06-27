using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Taxi_Sluzba.Enums;

namespace Taxi_Sluzba.Models
{
    public class Voznja
    {
        public string ID { get; set; }
        public DateTime DatumIVreme { get; set; }

        [Required(ErrorMessage = "Morate uneti podatak")]
        public Lokacija LokacijaMusterije { get; set; }

        public Lokacija Odrediste { get; set; }
        public TipAutomobila TipAutomobila { get; set; }
        public Musterija Musterija { get; set; }
        public Dispecer Dispecer { get; set; }
        public Vozac Vozac { get; set; }
        public double Iznos { get; set; }
        public Komentar Komentar { get; set; } = new Komentar();
        public StatusVoznje Status { get; set; }

    }
}