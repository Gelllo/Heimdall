using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heimdall.Application.Requests;

namespace Heimdall.Application.Responses.GlucoseRecords
{
    public record GetGlucoseRecordsFromSpecifiedDateUntilNowResponse
    {
        public IEnumerable<GlucoseRecordDTO>? GlucoseRecords { get; set; }
    }
}
