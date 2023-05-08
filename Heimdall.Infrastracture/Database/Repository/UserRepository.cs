using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heimdall.Application.Repository;
using Heimdall.Domain.UsersDomain;
using Microsoft.EntityFrameworkCore;

namespace Heimdall.Infrastracture.Database.Repository
{
    public class UserRepository: GenericRepository<User>, IUserRepository, IDisposable
    {
        public UserRepository(DataContext context) : base(context)
        {

        }

        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await GetAllAsync();
        }

        public User GetUserByID(int userId)
        {
            return _dbContext.Users.Find(userId);
        }

        public void InsertUser(User user)
        {
            _dbContext.Users.Add(user);
        }

        public void DeleteUser(int userID)
        {
            User user = _dbContext.Users.Find(userID);
            _dbContext.Users.Remove(user);
        }

        public void UpdateUser(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
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
