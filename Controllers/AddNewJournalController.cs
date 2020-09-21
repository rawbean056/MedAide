using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedAide.Models;
using MedAide.Data;

namespace MedAide.Controllers
{
    public class AddNewJournalController : Controller
    {
        // GET: AddNewJournal
        MedaideEntities obj1 = new MedaideEntities();//load database
        public ActionResult AddJournal()
        {
            AddNewJournal a = new AddNewJournal();//passing parameter of model
            return View(a);
            
        }
        [HttpPost]
        public ActionResult AddJournal1(AddNewJournal ab)
        {
            if (ModelState.IsValid)
            {
                string email = (string)Session["Email"];
                
                Patient pa = obj1.Patients.Where(m => m.email == email).FirstOrDefault();//find patient from email


                Journal jo = new Data.Journal();
                jo.note = ab.journal; //passing user input to database 
                if(ab.sym1){ jo.symptom1 = "true"; }
                if (ab.sym2) { jo.symptom2 = "true"; }
                if (ab.sym3) { jo.symptom3 = "true"; }
                if (ab.sym4) { jo.symptom4 = "true"; }

              
                jo.date_time = DateTime.Now;
                jo.patient_id = pa.id;

                obj1.Journals.Add(jo);
                obj1.SaveChanges();//add journals to database
                ViewBag.a = "Successfully Added";
                return RedirectToAction("ViewJournal", "ViewJournal");

            }

            return RedirectToAction("ViewJournal", "ViewJournal");
        }
    }
}
