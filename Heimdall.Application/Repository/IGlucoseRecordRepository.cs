using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heimdall.Domain.GlucoseRecordDomain;

namespace Heimdall.Application.Repository
{
    public interface IGlucoseRecordRepository
    {
        IEnumerable<GlucoseRecord> GetGlucoseRecords();

        Task<IEnumerable<GlucoseRecord>> GetGlucoseRecordsAsync();

        Task<GlucoseRecord> GetGlucoseRecordByID(int id);
        
        Task<int> InsertGlucoseRecord(GlucoseRecord record);

        void DeleteGlucoseRecord(int id);

        Task<GlucoseRecord> UpsertGlucoseRecordAsync(GlucoseRecord record);

        void Save();
    }
}
