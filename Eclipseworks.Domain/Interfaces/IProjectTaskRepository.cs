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
        Task<ProjectTask> GetById(int id);
        Task<ProjectTask> GetByName(string name);
        Task<ProjectTask> Create(ProjectTask projectTask);
        Task<ProjectTask> Remove(ProjectTask projectTask);
        Task<ProjectTask> Update(ProjectTask projectTask);
    }
}
