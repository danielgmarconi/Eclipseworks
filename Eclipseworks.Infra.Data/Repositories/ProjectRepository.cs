using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Interfaces;
using Eclipseworks.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eclipseworks.Infra.Data.Repositories;

public class ProjectRepository : IProjectRepository
{
    ApplicationDbContext _context;
    public ProjectRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Project>> GetProjects()
    {
        return await _context.Projects.ToListAsync();
    }
    public async Task<Project> GetById(int id)
    {
        return await _context.Projects.FindAsync(id);
    }
    public async Task<Project> GetByName(string name)
    {
        return await _context.Projects.Where(e => e.Name.ToLower().Contains(name)).FirstOrDefaultAsync();
    }
    public async Task<Project> Create(Project project)
    {
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return project;
    }
    public async Task<Project> Remove(Project project)
    {
        _context.Remove(project);
        await _context.SaveChangesAsync();
        return project;
    }
    public async Task<Project> Update(Project project)
    {
        _context.Update(project);
        await _context.SaveChangesAsync();
        return project;
    }
}
