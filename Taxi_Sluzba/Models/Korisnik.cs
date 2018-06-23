using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Taxi_Sluzba.Enums;

namespace Taxi_Sluzba.Models
{
    public class Korisnik
    {
        bool loggedIn = false;

        [Required(ErrorMessage ="Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        [DisplayName("Pol:")]
        public Pol Pol { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        //uloga ??
        public List<Voznja> Voznje { get; set; }

        public Uloge Uloga { get; set; }

        public bool IsLoggedIn
        {
            get { return loggedIn; }
            set { loggedIn = value; }
        }
    }
}