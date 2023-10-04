using AutoMapper;
using ProjectManagementApi.Dtos;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto, User>();

            CreateMap<Project, GetProjectDto>();
            CreateMap<AddProjectDto, Project>();

            CreateMap<Assignment, GetAssignmentDto>();
            CreateMap<AddAssignmentDto, Assignment>();
        }
    }
}
