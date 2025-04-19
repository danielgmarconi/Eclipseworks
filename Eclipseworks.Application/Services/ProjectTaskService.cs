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
                var projectTaskEntity = _mapper.Map<ProjectTask>(projectTaskDTO);
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

        public Task<MethodResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MethodResponse> GetByName(string name)
        {
            throw new NotImplementedException();
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

        public Task<MethodResponse> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MethodResponse> Update(ProjectTaskDTO projectTaskDTO)
        {
            throw new NotImplementedException();
        }
    }
}
