using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Application.Requests.GlucoseRecords
{
    public record DeleteGlucoseRecordRequest
    {
        public int Id { get; set; }
    }
}
