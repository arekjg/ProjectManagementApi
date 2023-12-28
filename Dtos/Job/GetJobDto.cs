using ProjectManagementApi.Helper;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Dtos
{
    public class GetJobDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public JobStatus Status { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public int CreatedAtDate { get; set; }
        public int LastEdited { get; set; }
        public int? EndedAtDate { get; set; }
        public int DeadlineDate { get; set; }
        public int? TimePassed { get; set; }
        public int? WorkTime { get; set; }
        public Priority Priority { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
