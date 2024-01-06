using ProjectManagementApi.Helper;

namespace ProjectManagementApi.Dtos
{
    public class AddJobDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public JobStatus Status { get; set; }
        public int CreatedById { get; set; }
        public int CreatedAtDate { get; set; }
        public int DeadlineDate { get; set; }
        public Priority Priority { get; set; }
        public int ProjectId { get; set; }
    }
}
