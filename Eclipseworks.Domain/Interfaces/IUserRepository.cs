using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eclipseworks.Domain.Entities;

namespace Eclipseworks.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetById(int id);
        Task<User> GetByEmail(string Email);
        Task<User> Create(User user);
        Task<User> Remove(User user);
        Task<User> Update(User user);
    }
}
