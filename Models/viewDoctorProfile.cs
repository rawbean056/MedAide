using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedAide.Models
{
    public class viewDoctorProfile
    {
        public  int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string current_password { get; set; }
        public string new_password { get; set; }
        public string visiting_hour { get; set; }
        public string academic { get; set; }
        public string expertice { get; set; }
        public string chamber_address { get; set; }
        public string chamber_contact { get; set; }



    }
}