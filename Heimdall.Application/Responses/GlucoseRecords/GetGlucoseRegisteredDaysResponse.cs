using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Application.Responses.GlucoseRecords
{
    public record GetGlucoseRegisteredDaysResponse
    {
        public IEnumerable<RegisteredDaysDto>? RegisteredDays { get; set; }
    }

    public record RegisteredDaysDto
    {
        public string? Date { get; set; }
        public int? RecordsCountPerDay { get; set; }
    }
}
