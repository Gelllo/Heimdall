using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heimdall.Domain;

namespace Heimdall.Application.Responses.GlucoseRecords
{
    public record UpdateGlucoseRecordResponse
    {
        public GlucoseRecord? GlucoseRecord { get; set;}
    }
}
