using ProjectManagementApi.Helper;

namespace ProjectManagementApi.Dtos
{
    public class UpdateJobDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public JobStatus Status { get; set; }
        public int DeadlineDate { get; set; }
        public Priority Priority { get; set; }
    }
}
