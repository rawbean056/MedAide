using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MedAide
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           // routes.MapRoute(
           //    name: "Doctor",
           //    url: "doctor",
           //    defaults: new { controller = "DoctorViewPatientDetails", action = "DoctorViews" }
           //);

           // routes.MapRoute(
           //     name: "SignUp",
           //     url: "Signup",
           //     defaults: new { controller = "SignUp", action = "SignUp" }
           // );
           // routes.MapRoute(
           //     name: "Login",
           //     url: "Login",

           //     defaults: new { controller = "Login", action = "Login" }
           // );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
