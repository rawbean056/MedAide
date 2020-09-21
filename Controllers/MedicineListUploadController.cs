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
    public class MedicineListUploadController : Controller
    {
        // GET: MedicineListUpload
        MedaideEntities obj1 = new MedaideEntities();
        public ActionResult MedicineListUpload()
        {
            MedicineListUpload obj = new MedicineListUpload();
            return View(obj);
        }
        [HttpPost]
        public ActionResult MedicineListUpload(MedicineListUpload file)
        {
            if (ModelState.IsValid)
            {
                var email = (string)Session["Email"];
                if (obj1.Patients.Where(m => m.id == file.patient_id).FirstOrDefault() != null)
                {
                    DrugStore Drug = new Data.DrugStore();
                    Drug = obj1.DrugStores.Where(m => m.email == email).FirstOrDefault();
                    MedList M = new Data.MedList();
                    M.drugstore_id = Drug.id;
                    M.patient_id = file.patient_id;
                    M.date_time = DateTime.Now;
                    byte[] data;
                    using (BinaryReader br = new BinaryReader(file.data.InputStream))
                    {
                        data = br.ReadBytes(file.data.ContentLength);
                    }

                    M.dataname = Path.GetFileName(file.data.FileName);
                    M.datatype = file.data.ContentType;

                    M.data = data;

                    obj1.MedLists.Add(M);
                    obj1.SaveChanges();
                    ViewBag.a = "Successfully Added";

                    return View("MedicineListUpload");

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