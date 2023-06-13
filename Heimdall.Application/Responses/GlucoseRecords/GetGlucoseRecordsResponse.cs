using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heimdall.Domain.GlucoseRecordDomain;

namespace Heimdall.Application.Responses.GlucoseRecords
{
    public record GetGlucoseRecordsResponse
    {
        public IEnumerable<GlucoseRecord>? GlucoseRecords { get; set;}
    }
}
