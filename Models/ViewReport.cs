﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedAide.Data;

namespace MedAide.Models
{
    public class ViewReport
    {
        public DateTime starTime { get; set; }
        public DateTime endTime { get; set; }
        public IEnumerable<JoinDiagnosticCenterReport> result { get; set; }
        


    }
}