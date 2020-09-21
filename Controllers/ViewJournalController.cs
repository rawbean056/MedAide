using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedAide.Models;
using MedAide.Data;

namespace MedAide.Controllers
{
    public class ViewJournalController : Controller
    {
        MedaideEntities obj1=new MedaideEntities();
        // GET: ViewJournal
        public ActionResult ViewJournal()
        {
           ViewJournal a=new ViewJournal();
           string email = (string)Session["Email"];
           Patient pa = obj1.Patients.Where(m => m.email == email).FirstOrDefault();
            a.result = obj1.Journals.Where(m => m.patient_id == pa.id).ToList();
            return View(a);
        }
        [HttpPost]
        public ActionResult ViewJournal(ViewJournal ab)
        {
            if (ModelState.IsValid)
            {
                string email = (string)Session["Email"];
                Patient pa = obj1.Patients.Where(m => m.email == email).FirstOrDefault();
                ab.result = obj1.Journals.Where(m => m.date_time >= ab.starTime && m.date_time <= ab.endTime && m.patient_id == pa.id).ToList();

                return View(ab);
            }

            return View();
        }

        
    }
}