using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedAide.Data;
using MedAide.Models;

namespace MedAide.Controllers
{
    public class SignUpController : Controller
    {
        MedaideEntities obj1 = new MedaideEntities();
        MedaideEntities obj2 = new MedaideEntities();
        MedaideEntities obj3 = new MedaideEntities();
        MedaideEntities obj4 = new MedaideEntities();
        // GET: SignUp
        public ActionResult SignUp()
        {
            Signup user = new Signup();
            return View(user);
        }
        [HttpPost]
        public ActionResult SignUp(Signup user)

        {
            if (ModelState.IsValid)
            {
                if (string.Equals(user.usertype , "Patient"))
                {
                    if (!(obj1.Patients.Where(m => m.email == user.email ).FirstOrDefault() == null))
                    {
                        ViewBag.a = "Account already exists";

                    }
                    else
                    {
                        if (string.Equals(user.password, user.confirmpassword))
                        {
                            Patient pa = new Data.Patient();
                            pa.name = user.name;
                            pa.email = user.email;
                            pa.password = user.confirmpassword;
                            obj1.Patients.Add(pa);
                            obj1.SaveChanges();
                            ViewBag.a = "Successfully Added";
                            return RedirectToAction("Login", "Login");
                        }
                        else
                        {
                            ViewBag.a = "Password not match";
                            return View("SignUp");

                        }

                       
                    }
                }
               else if (string.Equals(user.usertype, "Doctor"))
                {
                    if (!(obj2.Doctors.Where(m => m.email == user.email).FirstOrDefault() == null))
                    {

                        ViewBag.a = "Account already exists";
                    }
                    else
                    {
                        if (string.Equals(user.password, user.confirmpassword))
                        {
                            Doctor doc = new Data.Doctor();
                            doc.name = user.name;
                            doc.email = user.email;
                            doc.password = user.confirmpassword;
                            obj2.Doctors.Add(doc);
                            obj2.SaveChanges();
                            ViewBag.a = "Successfully Added";
                            return RedirectToAction("Login", "Login");
                        }
                        else
                        {
                            ViewBag.a = "Password not match";
                            return View("SignUp");

                        }

                        
                    }
                    
                }
               else if (string.Equals(user.usertype, "DrugStore"))
                {
                    if (!(obj3.DrugStores.Where(m => m.email == user.email ).FirstOrDefault() == null))
                    {

                        ViewBag.a = "Account already exists";
                    }
                    else
                    {
                        if (string.Equals(user.password, user.confirmpassword))
                        {
                            DrugStore dru = new Data.DrugStore();
                            dru.name = user.name;
                            dru.email = user.email;
                            dru.password = user.confirmpassword;
                            obj3.DrugStores.Add(dru);
                            obj3.SaveChanges();
                            ViewBag.a = "Successfully Added";

                            return RedirectToAction("Login", "Login");
                        }
                        else
                        {
                            ViewBag.a = "Password not match";
                            return View("SignUp");

                        }

                       
                    }
                    
                }
                    else if (string.Equals(user.usertype, "DiagnosticCenter"))
                    {
                    if (!(obj4.DiagnosticCenters.Where(m => m.email == user.email ).FirstOrDefault() == null))
                    {

                        ViewBag.a = "Account already exists";
                    }
                    else
                    {
                        if (string.Equals(user.password, user.confirmpassword))
                        {
                            DiagnosticCenter dia = new Data.DiagnosticCenter();
                            dia.name = user.name;
                            dia.email = user.email;
                            dia.password = user.confirmpassword;
                            obj4.DiagnosticCenters.Add(dia);
                            obj4.SaveChanges();
                            ViewBag.a = "Successfully Added";
                            return RedirectToAction("Login", "Login");
                        }

                        else
                        {
                            ViewBag.a = "Password not match";
                            return View("SignUp");

                        }
                    }



                    }
                }


                return View();
            }

        }
    }

