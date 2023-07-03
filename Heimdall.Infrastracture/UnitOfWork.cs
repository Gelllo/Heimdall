using Heimdall.Infrastracture.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heimdall.Application;
using Heimdall.Application.Repository;

namespace Heimdall.Infrastracture.Database
{
    public class UnitOfWork :IUnitOfWork, IDisposable
    {
        private readonly DataContext _dbContext;
        private IGlucoseRecordRepository _glucoseRecordRepository;


        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGlucoseRecordRepository GlucoseRecordRepository
        {
            get
            {
                return _glucoseRecordRepository = _glucoseRecordRepository ?? new GlucoseRecordRepository(_dbContext);
            }
        }

        public void Commit()
            => _dbContext.SaveChanges();


        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();

        public void Rollback()
            => _dbContext.Dispose();

        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
        
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    _dbContext.Dispose();
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
