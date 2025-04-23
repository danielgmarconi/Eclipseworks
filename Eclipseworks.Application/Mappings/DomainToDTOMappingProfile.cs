using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Eclipseworks.Application.DTOs;
using Eclipseworks.Domain.Entities;
using Eclipseworks.Domain.Enums;

namespace Eclipseworks.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<Project, ProjectDTO>().ReverseMap();
        CreateMap<ProjectTask, ProjectTaskDTO>().ReverseMap();
        CreateMap<ProjectTaskComment, ProjectTaskCommentDTO>().ReverseMap();
    }
}
