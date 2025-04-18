using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Interfaces;
using Eclipseworks.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eclipseworks.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }
    public async Task<User> GetById(int id)
    {
        return await _context.Users.FindAsync(id);
    }
    public async Task<User> GetByEmail(string Email)
    {
        return await _context.Users.Where(e => e.Email.ToLower().Contains(Email)).FirstOrDefaultAsync();
    }
    public async Task<User> Create(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
    public async Task<User> Remove(User user)
    {
        _context.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }
    public async Task<User> Update(User user)
    {
        _context.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }
}
