using ProjectManagementApi.Dtos;

namespace ProjectManagementApi.Interfaces
{
    public interface IJobService
    {
        Task<List<GetJobDto>> AddJob(AddJobDto newJob);
        Task<List<GetJobDto>> DeleteJob(int id);
        Task<List<GetJobDto>> GetAllJobs();
        Task<GetJobDto> GetJobById(int id);
        Task<List<GetJobDto>> GetJobsByProjectId(int id);
        Task<List<GetJobDto>> GetJobsByUserId(int id);
        Task<GetJobDto> UpdateJob(UpdateJobDto updatedJob);
    }
}
