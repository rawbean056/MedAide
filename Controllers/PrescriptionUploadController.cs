using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedAide.Data;
using MedAide.Models;

namespace MedAide.Controllers
{
    public class PrescriptionUploadController : Controller
    {
        // GET: PrescriptionUpload
        MedaideEntities obj1 = new MedaideEntities();
        public ActionResult PrescriptionUpload()
        {
            PrescriptionUpload obj = new PrescriptionUpload();
            return View(obj);
        }
        [HttpPost]
        public ActionResult PrescriptionUpload(PrescriptionUpload file)
        {
            if (ModelState.IsValid)
            {
                var email = (string)Session["Email"];
                if (obj1.Patients.Where(m => m.id == file.patient_id).FirstOrDefault() != null)
                {
                    Doctor Dia = new Data.Doctor();
                    Dia = obj1.Doctors.Where(m => m.email == email).FirstOrDefault();
                    Prescription P = new Data.Prescription();
                    P.doc_id = Dia.id;
                    P.patient_id = file.patient_id;
                    P.date_time = DateTime.Now;
                    byte[] data;
                    using (BinaryReader br = new BinaryReader(file.data.InputStream))
                    {
                        data = br.ReadBytes(file.data.ContentLength);
                    }

                    P.dataname = Path.GetFileName(file.data.FileName);
                    P.datatype = file.data.ContentType;

                    P.data = data;

                    obj1.Prescriptions.Add(P);
                    obj1.SaveChanges();
                    ViewBag.a = "Successfully Added";

                    return RedirectToAction("DoctorSearching", "DoctorSearchingPatient");

                }
                else
                {
                    ViewBag.a = "Patient ID not exist";

                    return View("PrescriptionUpload");

                }





            }
            return View();


        }
    }
}