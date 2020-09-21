using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedAide.Models
{
    public class Signup
    {
        
        public string usertype { get; set; }
        
        public string name { get; set; }
        
        public string email { get; set; }
       
       
        public string password{ get; set; }
       
        public string confirmpassword{ get; set; }
        public string meg { get; set; }

    }
}