using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedAide.Models;
using MedAide.Data;

namespace MedAide.Controllers
{
    public class ViewReportController : Controller
    {
        // GET: ViewReport
        MedaideEntities obj1 = new MedaideEntities();
        public ActionResult ViewReport()
        {
            string email = (string) Session["Email"];
            Patient pa = obj1.Patients.Where(m => m.email ==email).FirstOrDefault();
            ViewReport a = new ViewReport();
            List<DiagnosticCenter> Dia = obj1.DiagnosticCenters.ToList();
            List<Report> report=obj1.Reports.Where(m=>m.patient_id==pa.id).ToList();
            var result = from r in report
                join d in Dia on r.center_id equals d.id into table1
                from d in table1.ToList()
                select new JoinDiagnosticCenterReport()
                {
                    center = d,
                    rep= r

                };
            a.result = result;




            return View(a);
        }
        [HttpPost]
        public ActionResult ViewReport(ViewReport ab)
        {
            if (ModelState.IsValid)
            {
                string email = (string)Session["Email"];
                Patient pa = obj1.Patients.Where(m => m.email == email).FirstOrDefault();
                List<DiagnosticCenter> Dia = obj1.DiagnosticCenters.ToList();
                List<Report> report = obj1.Reports.Where(m => m.date_time >= ab.starTime && m.date_time <= ab.endTime&&m.patient_id==pa.id).ToList();
                var result = from r in report
                    join d in Dia on r.center_id equals d.id into table1
                    from d in table1.ToList()
                    select new JoinDiagnosticCenterReport()
                    {
                        center = d,
                        rep = r

                    };
                ab.result = result;


                return View(ab);
            }
            return View();
        }
        public FileResult Download(int id)
        {


            Report a = obj1.Reports.Where(m => m.id == id).FirstOrDefault();

            return File(a.data, a.datatype, a.dataName);

        }
    }
}