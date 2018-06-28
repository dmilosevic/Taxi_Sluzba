using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taxi_Sluzba.ViewModel
{
    public class PretragaVM
    {
        [DataType(DataType.Date)]
        public DateTime DatumStart { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatumEnd { get; set; }

        public int OcenaStart { get; set; } = 0;
        public int OcenaEnd { get; set; } = 0;

        public double CenaStart { get; set; } = 0;
        public double CenaEnd { get; set; } = 0;
    }
}