using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class NoDirectAccessAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        string controllerName = "Home";
        string actionName = "Index";
        if (HttpContext.Current.Session["User"] != null)
        {
            Taxi_Sluzba.Models.Korisnik k = HttpContext.Current.Session["User"] as Taxi_Sluzba.Models.Korisnik;
            switch (k.Uloga)
            {
                case Taxi_Sluzba.Enums.Uloge.Musterija:
                    controllerName = "Musterija";
                    break;
                case Taxi_Sluzba.Enums.Uloge.Vozac:
                    controllerName = "Vozac";
                    break;
                case Taxi_Sluzba.Enums.Uloge.Dispecer:
                    controllerName = "Dispecer";
                    break;
                default:
                    break;
            }
        }
        if (filterContext.HttpContext.Request.UrlReferrer == null ||
                    filterContext.HttpContext.Request.Url.Host != filterContext.HttpContext.Request.UrlReferrer.Host)
        {
            filterContext.Result = new RedirectToRouteResult(new
                           RouteValueDictionary(new { controller = controllerName, action = actionName, area = "" }));
        }
    }
}