using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eclipseworks.Application.Common;
using Eclipseworks.Application.DTOs;

namespace Eclipseworks.Application.Interfaces
{
    public interface IProjectTaskCommentService
    {
        Task<MethodResponse> GetProjectTaskComments();
        Task<MethodResponse> Get(int id);
        Task<MethodResponse> GetByProjectTask(int projectTaskId);
        Task<MethodResponse> Create(ProjectTaskCommentDTO projectTaskCommentDTO);
        Task<MethodResponse> Update(ProjectTaskCommentDTO projectTaskCommentDTO);
        Task<MethodResponse> Remove(int id);
    }
}
