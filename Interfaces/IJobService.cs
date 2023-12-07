using ProjectManagementApi.Dtos;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Interfaces
{
    public interface IJobService
    {
        Task<ServiceResponse<List<GetJobDto>>> GetAllJobs();
        Task<ServiceResponse<GetJobDto>> GetJobById(int id);
        Task<ServiceResponse<List<GetJobDto>>> AddJob(AddJobDto newJob);
        Task<ServiceResponse<GetJobDto>> UpdateJob(UpdateJobDto updatedJob);
        Task<ServiceResponse<List<GetJobDto>>> DeteleJob(int id);
    }
}
