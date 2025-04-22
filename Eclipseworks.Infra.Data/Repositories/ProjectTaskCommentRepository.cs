using System.Collections.Generic;
using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Interfaces;
using Eclipseworks.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eclipseworks.Infra.Data.Repositories
{
    public class ProjectTaskCommentRepository : IProjectTaskCommentRepository 
    {
        ApplicationDbContext _context;
        public ProjectTaskCommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProjectTaskComment>> GetProjectTaskComments()
        {
            return await _context.ProjectTaskComments.ToListAsync();
        }
        public async Task<ProjectTaskComment> Get(int id)
        {
            return await _context.ProjectTaskComments.FindAsync(id);
        }
        public async Task<IEnumerable<ProjectTaskComment>> GetByProjectTask(int id)
        {
            return await _context.ProjectTaskComments.Where(e => e.ProjectTaskId == id).ToListAsync();
        }
        public async Task<ProjectTaskComment> Create(ProjectTaskComment projectTaskComment)
        {
            _context.ProjectTaskComments.Add(projectTaskComment);
            await _context.SaveChangesAsync();
            return projectTaskComment;
        }
        public async Task<ProjectTaskComment> Remove(ProjectTaskComment projectTaskComment)
        {
            _context.Remove(projectTaskComment);
            await _context.SaveChangesAsync();
            return projectTaskComment;
        }
        public async Task<ProjectTaskComment> Update(ProjectTaskComment projectTaskComment)
        {
            _context.Update(projectTaskComment);
            await _context.SaveChangesAsync();
            return projectTaskComment;
        }
    }
}
