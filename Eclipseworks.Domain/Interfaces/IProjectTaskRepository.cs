using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eclipseworks.Domain.Entities;

namespace Eclipseworks.Domain.Interfaces
{
    public interface IProjectTaskRepository
    {
        Task<IEnumerable<ProjectTask>> GetProjectTasks();
        Task<ProjectTask> Get(int id);
        Task<ProjectTask> Get(string name);
        Task<ProjectTask> Get(int id, int projectId);
        Task<IEnumerable<ProjectTask>> GetByProject(int projectId);
        Task<ProjectTask> Create(ProjectTask projectTask);
        Task<ProjectTask> Remove(ProjectTask projectTask);
        Task<ProjectTask> Update(ProjectTask projectTask);
    }
}
