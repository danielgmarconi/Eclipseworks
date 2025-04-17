using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eclipseworks.Domain.Entities;

namespace Eclipseworks.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetProjects();
        Task<Project> GetById(int id);
        Task<Project> GetByName(string name);
        Task<Project> Create(Project project);
        Task<Project> Remove(Project project);
        Task<Project> Update(Project project);
    }
}
