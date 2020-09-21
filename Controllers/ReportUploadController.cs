using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedAide.Data;
using MedAide.Models;

namespace MedAide.Controllers
{
    public class ReportUploadController : Controller
    {
        // GET: ReportUpload
        MedaideEntities obj1 = new MedaideEntities();
        public ActionResult ReportUpload()
        {
            ReportUpload obj = new ReportUpload();



            return View(obj);
        }
        [HttpPost]
        public ActionResult ReportUpload(ReportUpload file)
        {

            if (ModelState.IsValid)
            {
                var email = (string)Session["Email"];
                if (obj1.Patients.Where(m => m.id == file.patient_id).FirstOrDefault() != null)
                {
                    DiagnosticCenter Dia = new Data.DiagnosticCenter();
                    Dia = obj1.DiagnosticCenters.Where(m => m.email == email).FirstOrDefault();
                    Report R = new Data.Report();
                    R.center_id = Dia.id;
                    R.patient_id = file.patient_id;
                    R.date_time = DateTime.Now;
                    byte[] data;
                    using (BinaryReader br = new BinaryReader(file.data.InputStream))
                    {
                        data = br.ReadBytes(file.data.ContentLength);
                    }

                    R.dataName = Path.GetFileName(file.data.FileName);
                    R.datatype = file.data.ContentType;

                    R.data = data;

                    obj1.Reports.Add(R);
                    obj1.SaveChanges();
                    ViewBag.a = "Successfully Added";

                    return View("ReportUpload");

                }
                else
                {
                    ViewBag.a = "Patient ID not exist";


                }





            }
            return View();
        }
    }
}