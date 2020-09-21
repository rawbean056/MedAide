using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedAide.Models;
using MedAide.Data;

namespace MedAide.Controllers
{
    public class ViewMedListController : Controller
    {
        // GET: ViewMedList
        MedaideEntities obj1 = new MedaideEntities();
        public ActionResult ViewMedList()
        {
            ViewMedList a = new ViewMedList();
            string email = (string)Session["Email"];
            Patient pa = obj1.Patients.Where(m => m.email == email).FirstOrDefault();
            List<DrugStore> Drug = obj1.DrugStores.ToList();
            List<MedList> medList = obj1.MedLists.Where(m => m.patient_id== pa.id).ToList();
            var result = from m in medList
                join d in Drug on m.drugstore_id equals d.id into table1
                from d in table1.ToList()
                select new JoinDrugStoreMedList()
                {
                    drug =d ,
                    med = m

                };
            a.result = result;

            return View(a);
        }
        [HttpPost]
        public ActionResult ViewMedList(ViewMedList ab)
        {
            if (ModelState.IsValid)
            {
                string email = (string)Session["Email"];
                Patient pa = obj1.Patients.Where(m => m.email == email).FirstOrDefault();
                List<DrugStore> Drug = obj1.DrugStores.ToList();
                List<MedList> medList = obj1.MedLists.Where(m => m.date_time >= ab.starTime && m.date_time <= ab.endTime && m.patient_id == pa.id).ToList();
                var result = from m in medList
                    join d in Drug on m.drugstore_id equals d.id into table1
                    from d in table1.ToList()
                    select new JoinDrugStoreMedList()
                    {
                        drug = d,
                        med = m

                    };
                ab.result = result;

                return View(ab);
            }
            return View();
        }
        public FileResult Download(int id)
        {


            MedList a = obj1.MedLists.Where(m => m.id == id).FirstOrDefault();

            return File(a.data, a.datatype, a.dataname);

        }
    }
}