using ProjectManagementApi.Dtos;

namespace ProjectManagementApi.Interfaces
{
    public interface IProjectService
    {
        Task<List<GetProjectDto>> AddProject(AddProjectDto newProject);
        Task<List<GetProjectDto>> DeleteProject(int id);
        Task<List<GetProjectDto>> GetAllProjects();
        Task<GetProjectDto> GetProjectById(int id);
        Task<List<GetProjectDto>> GetProjectsByPMId(int id);
        Task<GetProjectDto> UpdateProject(UpdateProjectDto updatedProject);
    }
}
