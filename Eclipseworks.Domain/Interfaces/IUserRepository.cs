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
        Task<User> Create(User user);
        Task<User> GetById(string Email);
    }
}
