using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heimdall.Application.Repository;
using Heimdall.Application.Responses;
using Heimdall.Application.Responses.GlucoseRecords;
using Heimdall.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Heimdall.Infrastracture.Database.Repository
{
    public class GlucoseRecordRepository: GenericRepository<GlucoseRecord>, IGlucoseRecordRepository, IDisposable
    {
        public GlucoseRecordRepository(DataContext dbContext) : base(dbContext)
        {
        }
        public async Task<GlucoseRecord?> GetGlucoseRecordAsync(int id)
        {
            return await _dbContext.GlucoseRecords.FindAsync(id);
        }

        public IEnumerable<GlucoseRecord?> GetGlucoseRecords()
        {
            return _dbContext.GlucoseRecords.ToList();
        }

        public async Task<IEnumerable<GlucoseRecord>> GetGlucoseRecordsAsync(string? userID, string? date)
        {
            DateTime.TryParseExact(date, "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out DateTime dateObj);
            
            return await Task.FromResult(_dbContext.GlucoseRecords.AsQueryable()
                .Where(x => x.UserId == userID).AsEnumerable().Where(x => x.DateRegistered.Date == dateObj.Date).OrderByDescending(x=>x.DateRegistered));
        }

        public async Task<IEnumerable<GlucoseRecord>> GetGlucoseRecordsFromSpecifiedDateUntilNow(string? userID, string date)
        {
            DateTime.TryParseExact(date, "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out DateTime dateObj);
            return _dbContext.GlucoseRecords.AsQueryable().Where(x => x.UserId == userID)
                .OrderByDescending(x => x.DateRegistered).AsEnumerable().Where(x => x.DateRegistered > dateObj).ToList();
        }

        public async Task<IEnumerable<GlucoseRecordBarChartDTO>> GetGlucoseRecordsForBarChart(string? userID)
        {
            var rand = await _dbContext.GlucoseRecords.Where(x =>
                    x.UserId == userID && x.DateRegistered.Date > DateTime.Now.AddMonths(-1))
                .GroupBy(x => x.DateRegistered).OrderBy(x=>x.Key)
                .Select(x=> new GlucoseRecordBarChartDTO(){Date = x.Key.ToShortDateString(), AvgGlucoseLevels = System.Math.Round(x.Average(c => c.GlucoseLevel), 2)}).ToListAsync();

            return rand;
        }

        public async Task<IEnumerable<RegisteredDaysDto>> GetRegisteredDaysAsync()
        {
            var groupedDates = await _dbContext.GlucoseRecords.GroupBy(x => x.DateRegistered).OrderByDescending(x=>x.Key).Select(g =>
                    new RegisteredDaysDto() { Date = g.Key.ToShortDateString(), RecordsCountPerDay = g.Count() })
                .ToListAsync();

            return groupedDates;
        }

        public async Task<GlucoseRecord?> GetGlucoseRecordByID(int id)
        {
            return await _dbContext.GlucoseRecords.FindAsync(id);
        }

        public async Task<int> InsertGlucoseRecord(GlucoseRecord record)
        {
            await _dbContext.GlucoseRecords.AddAsync(record);
            Save();

            return record.Id;
        }

        public void DeleteGlucoseRecord(int id)
        {
            GlucoseRecord record = _dbContext.GlucoseRecords.Find(id);
            _dbContext.GlucoseRecords.Remove(record);
            Save();
        }

        public async Task<GlucoseRecord> UpdateGlucoseRecordAsync(GlucoseRecord record)
        {
            _dbContext.GlucoseRecords.Entry(record).State = EntityState.Modified;
            Save();
            return record;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
