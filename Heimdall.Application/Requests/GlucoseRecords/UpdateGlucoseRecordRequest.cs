using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Application.Requests.GlucoseRecords
{
    public record UpdateGlucoseRecordRequest
    {
        public int Id { get; set; }
        public string GlucoseLevel { get; set; }

        public DateTime DateRegistered { get; set; }

        public string Color { get; set; }

        public string UserId { get; set; }
    }
}
