using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedAide.Data;

namespace MedAide.Models
{
    public class JoinDrugStoreMedList
    {
        public DrugStore drug { get; set; }
        public MedList med { get; set; }
    }
}