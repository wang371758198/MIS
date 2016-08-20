using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MIS.Www
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
              //  defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
              defaults: new { controller = "Main", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CSharp",
                url: "{controller}/{action}.html",
                defaults: new { controller = "CSharp", action = "index" }
                );

        }
    }
}
