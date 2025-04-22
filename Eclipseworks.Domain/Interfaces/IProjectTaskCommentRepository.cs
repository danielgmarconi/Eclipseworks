using Eclipseworks.Domain.Entities;

namespace Eclipseworks.Domain.Interfaces
{
    public interface IProjectTaskCommentRepository
    {
        Task<IEnumerable<ProjectTaskComment>> GetProjectTaskComments();
        Task<ProjectTaskComment> Get(int id);
        Task<IEnumerable<ProjectTaskComment>> GetByProjectTask(int projectTaskId);
        Task<ProjectTaskComment> Create(ProjectTaskComment projectTaskComment);
        Task<ProjectTaskComment> Remove(ProjectTaskComment projectTaskComment);
        Task<ProjectTaskComment> Update(ProjectTaskComment projectTaskComment);

    }
}
