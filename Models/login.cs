using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedAide.Models
{
    public class login
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "User is Required")]
        public string usertype { get; set;}
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Required")]
        public string email{get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required")]
        public string password { get; set; }
    }
}