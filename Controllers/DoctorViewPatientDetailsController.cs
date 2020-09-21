using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedAide.Models;
using MedAide.Data;

namespace MedAide.Controllers
{
    public class DoctorViewPatientDetailsController : Controller
    {
        // GET: DoctorViewPatientDetails
        MedaideEntities obj1 = new MedaideEntities();
        public ActionResult DoctorViews()
        {
            DoctorViewPatientDetails a =new DoctorViewPatientDetails();
            a.typeJournalData= (bool)Session["typeJournalData"];
            a.typeReportData = (bool)Session["typeReportData"];
            a.typePrescriptionData = (bool)Session["typePrescriptionData"];
            a.patient_id= (int)Session["pa_id"];
            a.startTime= (DateTime)Session["StartTime"];
            a.endTime= (DateTime)Session["EndTime"];
            Patient pa = obj1.Patients.Where(m => m.id == a.patient_id).FirstOrDefault();
            a.pa = pa;
            
            a.date = pa.dob != null ? (pa.dob.ToString()).Split(' ')[0] : string.Empty;

            if (a.typeJournalData)
            {
                a.resultJournal = obj1.Journals.Where(m => m.date_time >= a.startTime && m.date_time <= a.endTime && m.patient_id == a.patient_id).ToList();
            }

            if (a.typeReportData)
            {
                List<DiagnosticCenter> Dia = obj1.DiagnosticCenters.ToList();
                List<Report> report = obj1.Reports.Where(m => m.date_time >= a.startTime && m.date_time <= a.endTime && m.patient_id == a.patient_id).ToList();
                var result = from r in report
                    join d in Dia on r.center_id equals d.id into table1
                    from d in table1.ToList()
                    select new JoinDiagnosticCenterReport()
                    {
                        center = d,
                        rep = r

                    };
                a.resultReport = result;
            }

            if (a.typePrescriptionData)
            {
                List<Doctor> doctor = obj1.Doctors.ToList();
                List<Prescription> prescription = obj1.Prescriptions.Where(m => m.date_time >= a.startTime && m.date_time <= a.endTime && m.patient_id == a.patient_id).ToList();
                var result = from p in prescription
                    join d in doctor on p.doc_id equals d.id into table1
                    from d in table1.ToList()
                    select new JoinDoctorPrescription
                    {
                        pre = p,
                        doc = d

                    };
                a.resultPrescription = result;
            }
            return View(a);
        }
        public FileResult DownloadReport(int id)
        {
            Report re = obj1.Reports.Where(m => m.id >= id).FirstOrDefault();


            return File(re.data, re.datatype, re.dataName);

        }
        public FileResult DownloadPrescription(int id)
        {
            Prescription pe = obj1.Prescriptions.Where(m => m.id >= id).FirstOrDefault();


            return File(pe.data, pe.datatype, pe.dataname);

        }
    }
}