using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taxi_Sluzba.Enums;
using Taxi_Sluzba.Models;

namespace Taxi_Sluzba.Helpers
{
    public class Functions
    {
        public static void ZauzmiVozaca(string vozacUserName)
        {
            Dictionary<string, Korisnik> korisnici = HttpContext.Current.Application["korisnici"] as Dictionary<string, Korisnik>;

            Vozac vozac = korisnici[vozacUserName] as Vozac;
            vozac.IsAvailable = false;
        }

        public static void OslobodiVozaca(string vozacUserName)
        {
            Dictionary<string, Korisnik> korisnici = HttpContext.Current.Application["korisnici"] as Dictionary<string, Korisnik>;

            Vozac vozac = korisnici[vozacUserName] as Vozac;
            vozac.IsAvailable = true;
        }

        public static IEnumerable<Voznja> GetFilteredData(IEnumerable<Voznja> voz, string filter)
        {
            switch (filter)
            {
                case "KREIRANA_NA_CEKANJU":
                    voz = voz.Where(v => v.Status == StatusVoznje.KREIRANA_NA_CEKANJU);
                    break;
                case "FORMIRANA":
                    voz = voz.Where(v => v.Status == StatusVoznje.FORMIRANA);
                    break;
                case "OBRADJENA":
                    voz = voz.Where(v => v.Status == StatusVoznje.OBRADJENA);
                    break;
                case "PRIHVACENA":
                    voz = voz.Where(v => v.Status == StatusVoznje.PRIHVACENA);
                    break;
                case "OTKAZANA":
                    voz = voz.Where(v => v.Status == StatusVoznje.OTKAZANA);
                    break;
                case "NEUSPESNA":
                    voz = voz.Where(v => v.Status == StatusVoznje.NEUSPESNA);
                    break;
                case "USPESNA":
                    voz = voz.Where(v => v.Status == StatusVoznje.USPESNA);
                    break;
                default:
                    break;
            }
            return voz;
        }

        public static IEnumerable<Voznja> GetSortedData(IEnumerable<Voznja> voz, string sortMode)
        {
            switch (sortMode)
            {
                case "Datum":
                    voz = voz.OrderByDescending(v => v.DatumIVreme);
                    break;
                case "Ocena":
                    voz = voz.OrderByDescending(v => v.Komentar.Ocena);
                    break;

                default:
                    break;
            }
            return voz;
        }
    }
}