using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using  MedAide.Data;
using MedAide.Models;

namespace MedAide.Controllers
{
    public class viewDoctorProfileController : Controller
    {
        // GET: viewDoctorProfile
        MedaideEntities ob= new MedaideEntities();
        public ActionResult viewDoctorProfile()
        {
            var email = (string)Session["Email"];
           
           Doctor doc = ob.Doctors.Where(m => m.email == email).FirstOrDefault();
            viewDoctorProfile obj = new viewDoctorProfile();
            obj.email = doc.email;
            obj.id = doc.id;
            obj.academic = doc.academic;
            obj.chamber_address= doc.chamber_address;
            obj.name = doc.name;
            obj.chamber_contact = doc.chamber_contact;
            obj.expertice = doc.expertice;
            obj.visiting_hour = doc.visiting_hour;
            
            return View(obj);
        }
        public ActionResult editDoctorProfile()
        {
            viewDoctorProfile obj = new viewDoctorProfile();
            return View(obj);
        }
        [HttpPost]
        public ActionResult editDoctorProfile(viewDoctorProfile user)
        {
            if (ModelState.IsValid)
            {
                var email = (string)Session["Email"];

                
                Doctor doc = ob.Doctors.Where(m => m.email == email).FirstOrDefault();
                if (user.name != null)
                {
                    doc.name = user.name;
                }

                if (user.academic != null)
                {
                    doc.academic = user.academic;
                }

                if (user.expertice != null)
                {
                    doc.expertice = user.expertice;
                }

                if (user.chamber_address != null)
                {
                    doc.chamber_address = user.chamber_address;
                }

                if (user.chamber_contact != null)
                {
                   doc.chamber_contact = user.chamber_contact;
                }

                if (user.visiting_hour != null)
                {
                   doc.visiting_hour = user.visiting_hour;
                }

                if (user.new_password != null && user.current_password!=null)
                {
                    if (string.Equals(user.current_password, doc.password))
                    {
                        doc.password = user.new_password;
                    }
                    else
                    {
                        ViewBag.a = "Enter your current password";
                        return View("editDoctorProfile");
                    }

                }

                ob.Doctors.AddOrUpdate(doc);
                ob.SaveChanges();
                

                return RedirectToAction("viewDoctorProfile", "viewDoctorProfile");


            }
            return RedirectToAction("viewDoctorProfile", "viewDoctorProfile");
        }
    }
}