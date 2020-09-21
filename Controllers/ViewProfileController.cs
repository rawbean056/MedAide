using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using MedAide.Models;
using MedAide.Data;
using Microsoft.Ajax.Utilities;


namespace MedAide.Controllers
{
    public class ViewProfileController : Controller
    {
        // GET: ViewProfile
        MedaideEntities obj1 = new MedaideEntities();
        

        public ActionResult ViewProfile()
        {


            var email = (string)Session["Email"];
            Patient pa = new Data.Patient();
            pa = obj1.Patients.Where(m => m.email == email).FirstOrDefault();
            ViewProfile obj = new ViewProfile();
            obj.email = pa.email;
            obj.id = pa.id;
            obj.Address = pa.address;
            obj.blood_group = pa.blood_group;
            obj.name = pa.name;
            obj.contact = pa.contact;
            obj.emergency_contact = pa.emergency_contact;
            obj.gender = pa.gender;
            
            obj.date = pa.dob != null ? (pa.dob.ToString()).Split(' ')[0] : string.Empty;

            




            return View(obj);
        }
        
       

        public ActionResult EditProfile()
        {
            ViewProfile obj = new ViewProfile();

            return View(obj);
        }
        [HttpPost]
        public ActionResult EditProfile(ViewProfile user)
        {

            if (ModelState.IsValid)
            {
                var email = (string)Session["Email"];

                Patient pa = new Data.Patient();
                pa = obj1.Patients.Where(m => m.email == email).FirstOrDefault();
                if (user.name != null)
                {
                    pa.name = user.name;
                }

                if (user.contact != null)
                {
                    pa.contact = user.contact;
                }

                if (user.emergency_contact != null)
                {
                    pa.emergency_contact = user.emergency_contact;
                }

                if (user.Address != null)
                {
                    pa.address = user.Address;
                }

                if (user.gender != null)
                {
                    pa.gender = user.gender;
                }

                if (user.blood_group != null)
                {
                    pa.blood_group = user.blood_group;
                }

                if (user.dob != null)
                {
                    pa.dob = user.dob;
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

                obj1.Patients.AddOrUpdate(pa);
                obj1.SaveChanges();

                return RedirectToAction("ViewProfile", "ViewProfile");


            }

            return RedirectToAction("ViewProfile", "ViewProfile");

        }
    }
}