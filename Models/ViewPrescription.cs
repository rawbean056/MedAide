using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedAide.Data;
using MedAide.Models;

namespace MedAide.Models
{
    public class ViewPrescription
    {
        public DateTime starTime { get; set; }
        public DateTime endTime { get; set; }
        public IEnumerable<JoinDoctorPrescription> result { get; set; }
    }
}