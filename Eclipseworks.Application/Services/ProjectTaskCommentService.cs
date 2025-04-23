using AutoMapper;
using Eclipseworks.Application.Common;
using Eclipseworks.Application.DTOs;
using Eclipseworks.Application.Interfaces;
using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Interfaces;
using Eclipseworks.Domain.Validation;

namespace Eclipseworks.Application.Services;

public class ProjectTaskCommentService : IProjectTaskCommentService
{
    private IProjectTaskCommentRepository _projectTaskCommentRepository;
    private readonly IMapper _mapper;
    public ProjectTaskCommentService(IProjectTaskCommentRepository projectTaskCommentRepository, IMapper mapper)
    {
        _projectTaskCommentRepository = projectTaskCommentRepository;
        _mapper = mapper;
    }
    public async Task<MethodResponse> Create(ProjectTaskCommentDTO projectTaskCommentDTO)
    {
        var result = new MethodResponse();
        if (projectTaskCommentDTO == null)
        {
            result.StatusCode = 400;
            result.Message = "Bad Request";
            return result;
        }
        try
        {
            var ProjectTaskCommentEntity = _mapper.Map<ProjectTaskComment>(projectTaskCommentDTO);
            ProjectTaskCommentEntity.DateCreated = DateTime.Now;
            await _projectTaskCommentRepository.Create(ProjectTaskCommentEntity);
            result.Success = true;
            result.StatusCode = 201;
            result.Response = _mapper.Map<ProjectTaskCommentDTO>(ProjectTaskCommentEntity);
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
            result.Response = _mapper.Map<ProjectTaskCommentDTO>(await _projectTaskCommentRepository.Get(id));
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
    public async Task<MethodResponse> GetByProjectTask(int projectTaskId)
    {
        var result = new MethodResponse();
        try
        {
            DomainExceptionValidation.When(projectTaskId <= 0, "Invalid Id.");
            result.Response = _mapper.Map<ProjectTaskCommentDTO>(await _projectTaskCommentRepository.GetByProjectTask(projectTaskId));
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
    public async Task<MethodResponse> GetProjectTaskComments()
    {
        {
            var result = new MethodResponse();
            try
            {
                result.Response = _mapper.Map<IEnumerable<ProjectTaskCommentDTO>>(await _projectTaskCommentRepository.GetProjectTaskComments());
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
    public async Task<MethodResponse> Remove(int id)
    {
        var result = new MethodResponse();
        DomainExceptionValidation.When(id <= 0, "Invalid Id.");
        try
        {
            var user = await _projectTaskCommentRepository.Get(id);
            if (user == null)
            {
                result.StatusCode = 400;
                result.Message = "Bad Request";
                return result;
            }
            await _projectTaskCommentRepository.Remove(user);
            result.Response = _mapper.Map<ProjectTaskCommentDTO>(user);
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

    public Task<MethodResponse> Update(ProjectTaskCommentDTO projectTaskCommentDTO)
    {
        throw new NotImplementedException();
    }
}
