using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Taxi_Sluzba.Models;

namespace Taxi_Sluzba.Helpers
{
    public class DataAccess
    {
        public static List<Korisnik> GetAdministratoreIzFajla(string fileName)
        {
            List<Korisnik> retVal = new List<Korisnik>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while (( line = sr.ReadLine()) != null)
                {
                    Dispecer novi = new Dispecer();
                    string[] info = line.Split(';');
                    novi.UserName = info[0];
                    novi.Password = info[1];
                    novi.Ime = info[2];
                    novi.Prezime = info[3];
                    novi.JMBG = info[4];
                    novi.Pol = info[5] == "M" ? Enums.Pol.MALE : Enums.Pol.FEMALE;
                    novi.Telefon = info[6];
                    novi.Email = info[7];

                    retVal.Add(novi);
                }
            }

            return retVal;
        }
    }
}