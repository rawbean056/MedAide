using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedAide.Data;

namespace MedAide.Models
{
    public class DoctorViewPatientDetails
    {
        public int patient_id { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public bool typeJournalData { get; set; }
        public bool typeReportData { get; set; }
        public bool typePrescriptionData { get; set; }
        public List<Journal> resultJournal { get; set; }
        public Patient pa { get; set; }
        public IEnumerable<JoinDiagnosticCenterReport> resultReport { get; set; }
        public IEnumerable<JoinDoctorPrescription> resultPrescription { get; set; }

        public string date { get; set; }
    }
}