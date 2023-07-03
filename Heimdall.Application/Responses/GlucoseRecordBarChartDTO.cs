using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Application.Responses
{
    public record GlucoseRecordBarChartDTO
    {
        public string? Date { get; set; }

        public double? AvgGlucoseLevels { get; set; }
    }
}
