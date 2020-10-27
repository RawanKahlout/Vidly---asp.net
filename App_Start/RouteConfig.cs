using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace myvidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapMvcAttributeRoutes();
            routes.MapRoute(
               name: "ByReleasedDate",
               url: "{movie}/{Released}/{year}/{month}",
               defaults: new { controller = "movie", action = "ByReleasedDate" ,id = UrlParameter.Optional },//object for restriction
               new {year = @"\d{4}" , month = "\\d{2}" } //@and\ is for escape charected
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
