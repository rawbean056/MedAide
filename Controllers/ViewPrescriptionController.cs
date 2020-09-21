using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedAide.Models;
using MedAide.Data;


namespace MedAide.Controllers
{
    public class ViewPrescriptionController : Controller
    {
        // GET: ViewPrescription
        MedaideEntities obj1 = new MedaideEntities();
        public ActionResult ViewPrescription()
        {
            ViewPrescription a = new ViewPrescription();
            string email = (string)Session["Email"];
            Patient pa = obj1.Patients.Where(m => m.email == email).FirstOrDefault();
            List<Doctor> doctor = obj1.Doctors.ToList();
            List<Prescription> prescription = obj1.Prescriptions.Where(m => m.patient_id == pa.id).ToList();
            var result = from p in prescription
                join d in doctor on p.doc_id equals d.id into table1
                from d in table1.ToList()
                select new JoinDoctorPrescription
                {
                    pre = p,
                    doc = d

                };
            a.result = result;
            return View(a);
        }
        [HttpPost]
        public ActionResult ViewPrescription(ViewPrescription ab)
        {
            if (ModelState.IsValid)
            {
                string email = (string)Session["Email"];
                Patient pa = obj1.Patients.Where(m => m.email == email).FirstOrDefault();
                List<Doctor> doctor = obj1.Doctors.ToList();
                List<Prescription> prescription= obj1.Prescriptions.Where(m => m.date_time >= ab.starTime && m.date_time <= ab.endTime && m.patient_id == pa.id).ToList();
                var result = from p in prescription
                    join d in doctor on p.doc_id equals d.id into table1
                    from d in table1.ToList()
                    select new JoinDoctorPrescription
                    {
                        pre = p,
                        doc = d

                    };

                ab.result = result;
                return View(ab);
            }
            return View();
        }
        public FileResult Download(int id)
        {


            Prescription a = obj1.Prescriptions.Where(m => m.id == id).FirstOrDefault();

            return File(a.data, a.datatype, a.dataname);

        }
    }
}