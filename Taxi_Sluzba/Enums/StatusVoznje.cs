using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxi_Sluzba.Enums
{
    public enum StatusVoznje
    {
        UNKNOWN,
        KREIRANA_NA_CEKANJU,
        FORMIRANA,
        OBRADJENA,
        PRIHVACENA,
        OTKAZANA,
        NEUSPESNA,
        USPESNA,
    }
}