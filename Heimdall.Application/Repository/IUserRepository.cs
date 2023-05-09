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
        User GetUserByID(int studentId);
        void InsertUser(User student);
        void DeleteUser(int studentID);
        void UpdateUser(User student);
        void Save();
    }
}
