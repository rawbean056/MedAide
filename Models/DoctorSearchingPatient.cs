using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedAide.Models
{
    public class DoctorSearchingPatient
    {
        public int patient_id { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public bool typeJournalData { get; set; }
        public bool typeReportData { get; set; }
        public bool typePrescriptionData { get; set; }
    }
}