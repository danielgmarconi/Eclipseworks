using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Interfaces;
using Eclipseworks.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eclipseworks.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> GetById(string Email)
        {
            return await _context.Users.Where(e => e.Email.ToLower().Contains(Email)).FirstOrDefaultAsync();
        }
    }
}
