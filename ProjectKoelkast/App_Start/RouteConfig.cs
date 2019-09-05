using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectKoelkast
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AdminRegister",
                url: "Admin/Register",
                defaults: new { controller = "Account", action = "AdminRegister" }
            );

            routes.MapRoute(
                "AdminPanel",
                "AdminPanel",
                new { controller = "Account", action = "AdminPanel"}
            ); 

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}
