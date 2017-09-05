using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebSellBuy
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
           name: "UserProfile",
           url: "UserProfile",
           defaults: new { controller = "UserProfile", action = "Index" }
        );

            routes.MapRoute(
             name: "SignIn",
             url: "SignIn",
             defaults: new { controller = "Authentication", action = "SignIn" }
          );

            routes.MapRoute(
          name: "Authorization",
          url: "Authorization",
          defaults: new { controller = "Authentication", action = "Authorization" }
       );

            routes.MapRoute(
      name: "AuthorizationUser",
      url: "AuthorizationUser",
      defaults: new { controller = "Authentication", action = "AuthorizationUser" }
   );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
