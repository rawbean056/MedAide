﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedAide.Models
{
    public class ReportUpload
    {
        public int patient_id { get; set; }
        public int id { get; set; }
        public HttpPostedFileBase data { get; set; }

    }
}