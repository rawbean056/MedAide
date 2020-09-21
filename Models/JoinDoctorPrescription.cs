using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedAide.Data;

namespace MedAide.Models
{
    public class JoinDoctorPrescription
    {
        public Doctor doc { get; set; }
        public Prescription pre { get; set; }
    }
}