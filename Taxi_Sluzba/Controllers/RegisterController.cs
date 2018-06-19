using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxi_Sluzba.Models;

namespace Taxi_Sluzba.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegisterUser(Musterija musterija)
        {
            //nakon validacije sa klijentske strane sledi serverska provera
            if (!isUsernameAvailable(musterija.UserName))
            {
                return View("Error", musterija);
            }

            //add user to database
            Dictionary<string, Korisnik> dic = HttpContext.Application["korisnici"] as Dictionary<string, Korisnik>;
            if(dic == null)
            {
                dic = new Dictionary<string, Korisnik>();
            }
            dic.Add(musterija.UserName, musterija);
            return View("Success");
        }

        private bool isUsernameAvailable(string username)
        {
            Dictionary<string, Korisnik> dic = HttpContext.Application["korisnici"] as Dictionary<string, Korisnik>;
            if (dic != null)
                return !dic.ContainsKey(username);

            return true;
        }
    }
}