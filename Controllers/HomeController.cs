using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedAide.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["Email"]=null;
            Session["UserType"]=null;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Services()
        {
            ViewBag.Message = "Services";
            return View();
        }
    }
}