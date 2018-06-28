using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Ime je obavezno")]        
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno")]
        public string Prezime { get; set; }

        [MinLength(13, ErrorMessage ="JMBG mora imati 13 cifara")]
        [MaxLength(13, ErrorMessage = "JMBG mora imati 13 cifara")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid JMBG")]
        public string JMBG { get; set; }

        public Pol Pol { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Number")]
        public string Telefon { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public List<Voznja> Voznje { get; set; } = new List<Voznja>();

        public Uloge Uloga { get; set; }

        public bool IsLoggedIn
        {
            get { return loggedIn; }
            set { loggedIn = value; }
        }
    }
}