using System.Collections.Generic;
using System.Threading.Tasks;
using WAF.API.Models;

namespace WAF.API.Data
{
    public interface IUserRepository : IGenericRepository
    {
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}