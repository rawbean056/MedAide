using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedAide.Models;
using MedAide.Data;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;

namespace MedAide.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        MedaideEntities obj1 = new MedaideEntities();

        public ActionResult Login()

        {
            login loginUser = new login();
            return View(loginUser);
        }
        [HttpPost]
        public ActionResult Login(login loginUser)

        {
            if (ModelState.IsValid)
            {
                if (string.Equals(loginUser.usertype, "Patient"))
                {
                    if (obj1.Patients.Where(m => m.email == loginUser.email && m.password == loginUser.password).FirstOrDefault() == null)
                    {

                        ViewBag.a = "Enter Correct Email and Password";
                        return View("Login");

                    }
                    else
                    {
                        Session["Email"] = loginUser.email;
                        Session["UserType"] = loginUser.usertype;

                        return RedirectToAction("ViewJournal", "ViewJournal");
                        //return RedirectToAction("AddJournal", "AddNewJournal");


                    }


                }
                else if (string.Equals(loginUser.usertype, "Doctor"))
                {
                    if (obj1.Doctors.Where(m => m.email == loginUser.email && m.password == loginUser.password).FirstOrDefault() == null)
                    {
                        ViewBag.a = "Enter Correct Email and Password";
                        return View("Login");

                    }
                    else
                    {
                        Session["Email"] = loginUser.email;
                        Session["UserType"] = loginUser.usertype;
                        return RedirectToAction("DoctorSearching", "DoctorSearchingPatient");


                    }

                }
                else if (string.Equals(loginUser.usertype, "DrugStore"))
                {
                    if (obj1.DrugStores.Where(m => m.email == loginUser.email && m.password == loginUser.password).FirstOrDefault() == null)
                    {
                        ViewBag.a = "Enter Correct Email and Password";
                        return View("Login");

                    }
                    else
                    {
                        Session["Email"] = loginUser.email;
                        Session["UserType"] = loginUser.usertype;



                        return RedirectToAction("MedicineListUpload", "MedicineListUpload");


                    }

                }
                else if (string.Equals(loginUser.usertype, "DiagnosticCenter"))
                {
                    if (obj1.DiagnosticCenters.Where(m => m.email == loginUser.email && m.password == loginUser.password).FirstOrDefault() == null)
                    {
                        ViewBag.a = "Enter Correct Email and Password";
                      return View("Login");

                    }
                    else
                    {
                        Session["Email"] = loginUser.email;
                        Session["UserType"] = loginUser.usertype;
                        return RedirectToAction("ReportUpload", "ReportUpload");


                    }

                }
            }



            return View();
        }
    }
}