using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heimdall.Domain.UsersDomain;

namespace Heimdall.Application.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();

        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByID(int studentId);
        Task<int> InsertUser(User student);
        void DeleteUser(int studentID);
        Task<User> UpdateUserAsync(User student);
        void Save();
    }
}
