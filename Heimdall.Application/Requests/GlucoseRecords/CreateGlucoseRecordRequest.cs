﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Application.Requests.GlucoseRecords
{
    public record CreateGlucoseRecordRequest
    {
        public GlucoseRecordDTO? GlucoseRecordDTO { get; set; }
    }
}
