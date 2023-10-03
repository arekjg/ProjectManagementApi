using ProjectManagementApi.Dtos;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Interfaces
{
    public interface IProjectService
    {
        Task<ServiceResponse<List<GetProjectDto>>> GetAllProjects();
        Task<ServiceResponse<GetProjectDto>> GetProjectById(int id);
        Task<ServiceResponse<List<GetProjectDto>>> AddProject(AddProjectDto newProject);
        Task<ServiceResponse<GetProjectDto>> UpdateProject(UpdateProjectDto updatedProject);
        Task<ServiceResponse<List<GetProjectDto>>> DeleteProject(int id);
    }
}
