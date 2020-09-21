using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedAide.Models
{
    public class ViewProfile
    {
        public string name { get; set; }
        public string email { get; set; }
        public string current_password { get; set; }
        public string new_password { get; set; }
        public string Address { get; set; }
        public string contact { get; set; }
        public string blood_group { get; set; }
        public DateTime? dob { get; set; }
        public int id { get; set; }
        public string gender { get; set; }
        public string emergency_contact { get; set; }

        public string date { get; set; }



    }
}