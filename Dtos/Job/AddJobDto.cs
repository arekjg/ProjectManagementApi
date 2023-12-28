using ProjectManagementApi.Helper;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Dtos
{
    public class AddJobDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public JobStatus Status { get; set; }
        public int CreatedBy { get; set; }
        public int CreatedAtDate { get; set; }
        public int DeadlineDate { get; set; }
        public Priority Priority { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
