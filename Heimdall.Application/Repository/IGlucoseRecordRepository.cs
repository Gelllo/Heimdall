using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heimdall.Application.Responses;
using Heimdall.Application.Responses.GlucoseRecords;
using Heimdall.Domain;

namespace Heimdall.Application.Repository
{
    public interface IGlucoseRecordRepository
    {
        Task<GlucoseRecord?> GetGlucoseRecordAsync(int id);
        IEnumerable<GlucoseRecord?> GetGlucoseRecords();
        Task<IEnumerable<GlucoseRecord>> GetGlucoseRecordsAsync(string? userID, string? date);
        Task<IEnumerable<GlucoseRecord>> GetGlucoseRecordsFromSpecifiedDateUntilNow(string? userID, string? date);
        Task<IEnumerable<GlucoseRecordBarChartDTO>> GetGlucoseRecordsForBarChart(string? userID);
        Task<IEnumerable<RegisteredDaysDto>> GetRegisteredDaysAsync(string userID);
        Task<GlucoseRecord?> GetGlucoseRecordByID(int id);
        Task<int> InsertGlucoseRecord(GlucoseRecord record);
        void DeleteGlucoseRecord(int id);
        Task<GlucoseRecord> UpdateGlucoseRecordAsync(GlucoseRecord record);
        void Save();
    }
}
