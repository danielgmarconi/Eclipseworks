using AutoMapper;
using Eclipseworks.Application.Common;
using Eclipseworks.Application.DTOs;
using Eclipseworks.Application.Interfaces;
using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Interfaces;
using Eclipseworks.Domain.Validation;

namespace Eclipseworks.Application.Services
{
    public class ProjectService : IProjectService
    {
        private IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        public async Task<MethodResponse> GetProjects()
        {
            var result = new MethodResponse();
            try
            {
                result.Response = _mapper.Map<IEnumerable<ProjectDTO>>(await _projectRepository.GetProjects());
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

        public async Task<MethodResponse> GetById(int id)
        {
            var result = new MethodResponse();
            try
            {
                DomainExceptionValidation.When(id <= 0, "Invalid Id.");
                result.Response = _mapper.Map<ProjectDTO>(await _projectRepository.GetById(id));
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
        public async Task<MethodResponse> GetByName(string name)
        {
            var result = new MethodResponse();
            try
            {
                DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name.");
                result.Response = _mapper.Map<ProjectDTO>(await _projectRepository.GetByName(name));
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

        public async Task<MethodResponse> Update(ProjectDTO projectDTO)
        {
            var result = new MethodResponse();
            if (projectDTO == null)
            {
                result.StatusCode = 400;
                result.Message = "Bad Request";
                return result;
            }
            try
            {
                DomainExceptionValidation.When(projectDTO.Id <= 0, "Invalid Id.");
                var project  = await _projectRepository.GetById(projectDTO.Id);
                if (project == null)
                {
                    result.StatusCode = 400;
                    result.Message = "Bad Request";
                    return result;
                }
                project.Update(projectDTO.UserId,
                               projectDTO.Name,
                               projectDTO.Description,
                               projectDTO.StartDate,
                               projectDTO.EndDate);
                await _projectRepository.Update(project);
                result.Response = _mapper.Map<ProjectDTO>(project);
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

        public async Task<MethodResponse> Remove(int id)
        {
            var result = new MethodResponse();
            DomainExceptionValidation.When(id <= 0, "Invalid Id.");
            try
            {
                var user = await _projectRepository.GetById(id);
                if (user == null)
                {
                    result.StatusCode = 400;
                    result.Message = "Bad Request";
                    return result;
                }
                await _projectRepository.Remove(user);
                result.Response = _mapper.Map<ProjectDTO>(user);
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
        public async Task<MethodResponse> Create(ProjectDTO projectDTO)
        {
            var result = new MethodResponse();
            if (projectDTO == null)
            {
                result.StatusCode = 400;
                result.Message = "Bad Request";
                return result;
            }
            try
            {
                var projectEntity = _mapper.Map<Project>(projectDTO);
                projectEntity.DateCreated = DateTime.Now;
                await _projectRepository.Create(projectEntity);
                result.Success = true;
                result.StatusCode = 201;
                result.Response = _mapper.Map<ProjectDTO>(projectEntity);
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
