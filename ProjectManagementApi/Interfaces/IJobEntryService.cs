using ProjectManagementApi.Dtos;

namespace ProjectManagementApi.Interfaces
{
    public interface IJobEntryService
    {
        Task<List<GetJobEntryDto>> GetAllJobEntries();
        Task<List<GetJobEntryDto>> GetJobEntriesByJobId(int id);
        Task<List<GetJobEntryDto>> GetJobEntriesByUserId(int id);
        Task<GetJobEntryDto> GetJobEntryById(int id);
        Task<List<GetJobEntryDto>> AddJobEntry(AddJobEntryDto newJobEntry);
        Task<GetJobEntryDto> UpdateJobEntry(UpdateJobEntryDto updatedJobEntry);
        Task<List<GetJobEntryDto>> DeleteJobEntry(int id);
    }
}
