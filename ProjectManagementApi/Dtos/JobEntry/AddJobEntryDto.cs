using ProjectManagementApi.Models;

namespace ProjectManagementApi.Dtos
{
    public class AddJobEntryDto
    {
        public int UserId { get; set; }
        public int JobId { get; set; }
        public int StartedAtDate { get; set; }
        public int StartedAtTime { get; set; }
    }
}
