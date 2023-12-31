using ProjectManagementApi.Dtos;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Interfaces
{
    public interface IJobService
    {
        Task<ServiceResponse<List<GetJobDto>>> AddJob(AddJobDto newJob);
        Task<ServiceResponse<List<GetJobDto>>> DeteleJob(int id);
        Task<ServiceResponse<List<GetJobDto>>> GetAllJobs();
        Task<ServiceResponse<GetJobDto>> GetJobById(int id);
        Task<ServiceResponse<List<GetJobDto>>> GetJobsByProjectId(int id);
        Task<ServiceResponse<List<GetJobDto>>> GetJobsByUserId(int id);
        Task<ServiceResponse<GetJobDto>> UpdateJob(UpdateJobDto updatedJob);
    }
}
