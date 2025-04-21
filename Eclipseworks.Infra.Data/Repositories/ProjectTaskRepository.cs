using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Interfaces;
using Eclipseworks.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eclipseworks.Infra.Data.Repositories;

public class ProjectTaskRepository : IProjectTaskRepository
{
    ApplicationDbContext _context;
    public ProjectTaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<ProjectTask>> GetProjectTasks()
    {
        return await _context.ProjectTasks.ToListAsync();
    }
    public async Task<ProjectTask> Get(int id)
    {
        return await _context.ProjectTasks.FindAsync(id);
    }
    public async Task<ProjectTask> Get(string name)
    {
        return await _context.ProjectTasks.Where(e => e.Name.ToLower().Contains(name)).FirstOrDefaultAsync();
    }
    public async Task<ProjectTask> Get(int id, int projectId)
    {
        return await _context.ProjectTasks.Where(e => e.Id == id && e.ProjectId == projectId).FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<ProjectTask>> GetByProject(int projectId)
    {
        return await _context.ProjectTasks.Where(e => e.ProjectId == projectId).ToListAsync();
    }
    public async Task<ProjectTask> Create(ProjectTask projectTask)
    {
        _context.ProjectTasks.Add(projectTask);
        await _context.SaveChangesAsync();
        return projectTask;
    }
    public async Task<ProjectTask> Remove(ProjectTask projectTask)
    {
        _context.Remove(projectTask);
        await _context.SaveChangesAsync();
        return projectTask;
    }
    public async Task<ProjectTask> Update(ProjectTask projectTask)
    {
        _context.Update(projectTask);
        await _context.SaveChangesAsync();
        return projectTask;
    }
}
