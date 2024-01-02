using ProjectManagementApi.Dtos.JobEntry;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Interfaces
{
    public interface IJobEntryService
    {
        Task<ServiceResponse<List<GetJobEntryDto>>> GetAllJobEntries();
        Task<ServiceResponse<List<GetJobEntryDto>>> GetJobEntriesByJobId(int id);
        Task<ServiceResponse<List<GetJobEntryDto>>> GetJobEntriesByUserId(int id);
        Task<ServiceResponse<GetJobEntryDto>> GetJobEntryById(int id);
        Task<ServiceResponse<List<GetJobEntryDto>>> AddJobEntry(AddJobEntryDto newJobEntry);
        Task<ServiceResponse<GetJobEntryDto>> UpdateJobEntry(UpdateJobEntryDto updatedJobEntry);
        Task<ServiceResponse<List<GetJobEntryDto>>> DeleteJobEntry(int id);
    }
}
