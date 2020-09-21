using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedAide.Data;

namespace MedAide.Models
{
    public class JoinDiagnosticCenterReport
    {
        public DiagnosticCenter center { get; set; }
        public Report  rep { get; set; }
    }
}