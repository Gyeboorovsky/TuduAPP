using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuduAPI.Models;

namespace WebApplication.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task AddUser(User user);
        Task<string> GetUsername(string username, string password);
    }
}
