using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedAide.Models;
using MedAide.Data;


namespace MedAide.Controllers
{
    public class DoctorSearchingPatientController : Controller
    {
        // GET: DoctorSearchingPatient
        MedaideEntities obj1 = new MedaideEntities();
        public ActionResult DoctorSearching()
        {
            DoctorSearchingPatient obj = new DoctorSearchingPatient();
            return View(obj);
        }
        [HttpPost]
        public ActionResult DoctorSearching(DoctorSearchingPatient a)
        {
            if (ModelState.IsValid)
            {
                
                    if (obj1.Patients.Where(m => m.id == a.patient_id).FirstOrDefault() == null)
                    {

                        ViewBag.a = "Patient id not Valid";
                        return View("DoctorSearching");

                    }
                    else
                    {if(a.typeReportData||a.typeJournalData||a.typePrescriptionData){
                            Session["StartTime"] = a.startTime;
                            Session["EndTime"] = a.endTime;
                            Session["pa_id"] = a.patient_id;
                            Session["typeJournalData"] = a.typeJournalData;
                            Session["typeReportData"] = a.typeReportData;
                            Session["typePrescriptionData"] = a.typePrescriptionData;
                            return RedirectToAction("DoctorViews", "DoctorViewPatientDetails");
                        }
                        else
                        {
                            ViewBag.a = "Choose any of the option";
                            return View("DoctorSearching");
                        }
                        
                    }






            }

           
            return View();
        }
    }
}