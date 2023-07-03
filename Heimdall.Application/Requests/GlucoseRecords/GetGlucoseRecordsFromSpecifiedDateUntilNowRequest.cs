using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Application.Requests.GlucoseRecords
{
    public record GetGlucoseRecordsFromSpecifiedDateUntilNowRequest
    {
        public string UserID { get; set; }
        public string Date { get; set; }
    }
}
