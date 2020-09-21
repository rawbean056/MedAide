using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedAide.Models
{
    public class DrugStoreAndDiagnosticCenterViewProfile
    {

        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string current_password { get; set; }
        public string new_password { get; set; }
        public string address { get; set; }
        public string workingHour { get; set; }
        public string contact { get; set; }
        public string type { get; set; }
    }
}