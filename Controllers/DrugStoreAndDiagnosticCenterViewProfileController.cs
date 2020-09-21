using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedAide.Data;
using MedAide.Models;

namespace MedAide.Controllers
{
    public class DrugStoreAndDiagnosticCenterViewProfileController : Controller
    {
        // GET: DrugStoreAndDiagnosticCenterViewProfile
        MedaideEntities obj1 = new MedaideEntities();
        public ActionResult ViewProfile()
        {
            var user = (string)Session["UserType"];
            if (string.Equals(user, "DrugStore"))
            {
                var email = (string)Session["Email"];
                DrugStore pa = new Data.DrugStore();
                pa = obj1.DrugStores.Where(m => m.email == email).FirstOrDefault();
                DrugStoreAndDiagnosticCenterViewProfile obj = new DrugStoreAndDiagnosticCenterViewProfile();
                obj.email = pa.email;
                obj.id = pa.id;
                obj.address = pa.addess;
                obj.workingHour = pa.working_hour;
                obj.name = pa.name;
                obj.contact = pa.contact;
                obj.type = user;
                return View(obj);
            }
            if (string.Equals(user, "DiagnosticCenter"))
            {
                var email = (string)Session["Email"];
                DiagnosticCenter pa = new Data.DiagnosticCenter();
                pa = obj1.DiagnosticCenters.Where(m => m.email == email).FirstOrDefault();
                DrugStoreAndDiagnosticCenterViewProfile obj = new DrugStoreAndDiagnosticCenterViewProfile();
                obj.email = pa.email;
                obj.id = pa.id;
                obj.name = pa.name;
                obj.address = pa.address;
                obj.workingHour = pa.working_hour;

                obj.contact = pa.contact;
                obj.type = user;
                return View(obj);
            }
            return View();
        }
       

        public ActionResult EditProfile()
        {
            DrugStoreAndDiagnosticCenterViewProfile obj = new DrugStoreAndDiagnosticCenterViewProfile();

            return View(obj);
        }
        [HttpPost]
        public ActionResult EditProfile(DrugStoreAndDiagnosticCenterViewProfile user)
        {

            if (ModelState.IsValid)
            {
                var User = (string)Session["UserType"];
                if (string.Equals(User, "DrugStore"))
                {
                    var email = (string)Session["Email"];

                    DrugStore pa = new Data.DrugStore();
                    pa = obj1.DrugStores.Where(m => m.email == email).FirstOrDefault();
                    if (user.contact != null)
                    {
                        pa.contact = user.contact;
                    }

                    if (user.address != null)
                    {
                        pa.addess = user.address;
                    }

                    if (user.name != null)
                    {
                        pa.name = user.name;
                    }

                    if (user.workingHour != null)
                    {
                        pa.working_hour = user.workingHour;
                    }

                    if (user.new_password != null && user.current_password != null)
                    {
                        if (string.Equals(user.current_password, pa.password))
                        {
                            pa.password = user.new_password;
                        }
                        else
                        {
                            ViewBag.a = "Enter your current password";
                            return View("EditProfile");
                        }

                    }

                    obj1.DrugStores.AddOrUpdate(pa);
                    obj1.SaveChanges();

                    return RedirectToAction("ViewProfile", "DrugStoreAndDiagnosticCenterViewProfile");
                }
                if (string.Equals(User, "DiagnosticCenter"))
                {
                    var email = (string)Session["Email"];

                    DiagnosticCenter pa = new Data.DiagnosticCenter();
                    pa = obj1.DiagnosticCenters.Where(m => m.email == email).FirstOrDefault();
                    if (user.contact != null)
                    {
                        pa.contact = user.contact;
                    }

                    if (user.address != null)
                    {
                        pa.address = user.address;
                    }

                    if (user.name != null)
                    {
                        pa.name = user.name;
                    }

                    if (user.workingHour != null)
                    {
                        pa.working_hour = user.workingHour;
                    }
                    if (user.new_password != null && user.current_password != null)
                    {
                        if (string.Equals(user.current_password, pa.password))
                        {
                            pa.password = user.new_password;
                        }
                        else
                        {
                            ViewBag.a = "Enter your current password";
                            return View("EditProfile");
                        }

                    }

                    obj1.DiagnosticCenters.AddOrUpdate(pa);
                    obj1.SaveChanges();

                    return RedirectToAction("ViewProfile", "DrugStoreAndDiagnosticCenterViewProfile");
                }


            }

            return RedirectToAction("ViewProfile", "DrugStoreAndDiagnosticCenterViewProfile");

        }
    }
}