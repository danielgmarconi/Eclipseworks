using Eclipseworks.Application.Common;
using Eclipseworks.Application.DTOs;

namespace Eclipseworks.Application.Interfaces
{
    public interface IProjectService
    {
        Task<MethodResponse> GetProjects();
        Task<MethodResponse> GetById(int id);
        Task<MethodResponse> GetByName(string name);
        Task<MethodResponse> Create(ProjectDTO projectDTO);
        Task<MethodResponse> Update(ProjectDTO projectDTO);
        Task<MethodResponse> Remove(int id);
    }
}
