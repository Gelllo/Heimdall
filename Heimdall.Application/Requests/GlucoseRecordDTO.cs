using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Application.Requests
{
    public record GlucoseRecordDTO
    {
        public int GlucoseLevel { get; set; }

        public string? DateRegistered { get; set; }

        public string? UserId { get; set; }

        public string? RegisteredAfter { get; set;}
    }
}
