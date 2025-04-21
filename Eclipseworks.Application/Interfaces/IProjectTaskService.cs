using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eclipseworks.Application.Common;
using Eclipseworks.Application.DTOs;

namespace Eclipseworks.Application.Interfaces
{
    public interface IProjectTaskService
    {
        Task<MethodResponse> GetProjectTasks();
        Task<MethodResponse> Get(int id);
        Task<MethodResponse> Get(int id, int projectId);
        Task<MethodResponse> Get(string name);
        Task<MethodResponse> GetByProject(int projectId);
        Task<MethodResponse> Create(ProjectTaskDTO projectTaskDTO);
        Task<MethodResponse> Update(ProjectTaskDTO projectTaskDTO);
        Task<MethodResponse> Remove(int id);
    }
}
