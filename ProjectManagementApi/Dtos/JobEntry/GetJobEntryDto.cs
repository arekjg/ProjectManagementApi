using ProjectManagementApi.Models;

namespace ProjectManagementApi.Dtos
{
    public class GetJobEntryDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int StartedAtDate { get; set; }
        public int StartedAtTime { get; set; }
        public int? EndedAtDate { get; set; }
        public int? EndedAtTime { get; set; }
        public int? TimePassed { get; set; }
    }
}
