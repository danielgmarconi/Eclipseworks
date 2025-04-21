using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Eclipseworks.Application.Common;
using Eclipseworks.Application.DTOs;
using Eclipseworks.Application.Interfaces;
using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Enums;
using Eclipseworks.Domain.Interfaces;
using Eclipseworks.Domain.Validation;

namespace Eclipseworks.Application.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private IProjectTaskRepository _projectTaskRepository;
        private readonly IMapper _mapper;
        public ProjectTaskService(IProjectTaskRepository projectTaskRepository, IMapper mapper)
        {
            _projectTaskRepository = projectTaskRepository;
            _mapper = mapper;
        }
        public async Task<MethodResponse> Create(ProjectTaskDTO projectTaskDTO)
        {
            var result = new MethodResponse();
            if (projectTaskDTO == null)
            {
                result.StatusCode = 400;
                result.Message = "Bad Request";
                return result;
            }
            try
            {
                var projectTaskEntity = new ProjectTask(projectTaskDTO.UserId,
                                                        projectTaskDTO.ProjectId,
                                                        projectTaskDTO.Name, 
                                                        projectTaskDTO.Description,
                                                        Enum.Parse<PriorityStatus>(projectTaskDTO.Priority, ignoreCase: true), 
                                                        projectTaskDTO.TimeHoursTask);
                projectTaskEntity.StatusUpdate(ProjectTaskStatus.none);
                projectTaskEntity.DateCreated = DateTime.Now;
                await _projectTaskRepository.Create(projectTaskEntity);
                result.Success = true;
                result.StatusCode = 201;
                result.Response = _mapper.Map<ProjectTaskDTO>(projectTaskEntity);
            }
            catch (Exception e)
            {
                result.StatusCode = 500;
                result.Message = e.Message;
            }
            return result;
        }
        public async Task<MethodResponse> Get(int id)
        {
            var result = new MethodResponse();
            try
            {
                DomainExceptionValidation.When(id <= 0, "Invalid Id.");
                result.Response = _mapper.Map<ProjectTaskDTO>(await _projectTaskRepository.Get(id));
                result.Success = true;
                result.StatusCode = 200;
            }
            catch (Exception e)
            {
                result.StatusCode = 500;
                result.Message = e.Message;
            }
            return result;
        }
        public async Task<MethodResponse> Get(int id, int projectId)
        {
            var result = new MethodResponse();
            try
            {
                DomainExceptionValidation.When(id <= 0, "Invalid Id.");
                DomainExceptionValidation.When(projectId <= 0, "Invalid projectId.");
                result.Response = _mapper.Map<ProjectTaskDTO>(await _projectTaskRepository.Get(id, projectId));
                result.Success = true;
                result.StatusCode = 200;
            }
            catch (Exception e)
            {
                result.StatusCode = 500;
                result.Message = e.Message;
            }
            return result;
        }
        public async Task<MethodResponse> Get(string name)
        {
            var result = new MethodResponse();
            try
            {
                DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name.");
                result.Response = _mapper.Map<ProjectTaskDTO>(await _projectTaskRepository.Get(name));
                result.Success = true;
                result.StatusCode = 200;
            }
            catch (Exception e)
            {
                result.StatusCode = 500;
                result.Message = e.Message;
            }
            return result;
        }
        public async Task<MethodResponse> GetProjectTasks()
        {
            var result = new MethodResponse();
            try
            {
                result.Response = _mapper.Map<IEnumerable<ProjectTaskDTO>>(await _projectTaskRepository.GetProjectTasks());
                result.Success = true;
                result.StatusCode = 200;
            }
            catch (Exception e)
            {
                result.StatusCode = 500;
                result.Message = e.Message;
            }
            return result;
        }
        public async Task<MethodResponse> GetByProject(int projectId)
        {
            var result = new MethodResponse();
            try
            {
                DomainExceptionValidation.When(projectId <= 0, "Invalid projectId.");
                result.Response = _mapper.Map<IEnumerable<ProjectTaskDTO>>(await _projectTaskRepository.GetByProject(projectId));
                result.Success = true;
                result.StatusCode = 200;
            }
            catch (Exception e)
            {
                result.StatusCode = 500;
                result.Message = e.Message;
            }
            return result;
        }
        public Task<MethodResponse> Remove(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<MethodResponse> Update(ProjectTaskDTO projectTaskDTO)
        {
            var result = new MethodResponse();
            if (projectTaskDTO == null)
            {
                result.StatusCode = 400;
                result.Message = "Bad Request";
                return result;
            }
            try
            {
                DomainExceptionValidation.When(projectTaskDTO.Id <= 0, "Invalid Id.");
                var projectTask = await _projectTaskRepository.Get(projectTaskDTO.Id);
                if (projectTask == null)
                {
                    result.StatusCode = 400;
                    result.Message = "Bad Request";
                    return result;
                }
                projectTask.Update(projectTaskDTO.Name,
                                   projectTaskDTO.Description,
                                   projectTaskDTO.Priority,
                                   projectTaskDTO.TimeHoursTask);
                result.Response = _mapper.Map<ProjectTaskDTO>(projectTask);
                result.Success = true;
                result.StatusCode = 200;
            }
            catch (Exception e)
            {
                result.StatusCode = 500;
                result.Message = e.Message;
            }
            return result;
        }
    }
}
