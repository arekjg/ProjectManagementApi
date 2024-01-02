using ProjectManagementApi.Models;

namespace ProjectManagementApi.Dtos.JobEntry
{
    public class UpdateJobEntryDto
    {
        public int Id { get; set; }
        public int? EndedAtDate { get; set; }
        public int? EndedAtTime { get; set; }
    }
}
