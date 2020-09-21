using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedAide.Data;

namespace MedAide.Models
{
    public class ViewMedList
    {
        public DateTime starTime { get; set; }
        public DateTime endTime { get; set; }
        public IEnumerable<JoinDrugStoreMedList> result { get; set; }
    }
}