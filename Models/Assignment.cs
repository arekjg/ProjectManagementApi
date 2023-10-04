using ProjectManagementApi.Helper;

namespace ProjectManagementApi.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public int CreatedById { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastEdited { get; set; }
        public DateTime Ended { get; set; }
        public DateTime Deadline { get; set; }
        public TimeSpan TimePassed { get; set; }
        public TimeSpan WorkTime { get; set; }
        public Priority Priority { get; set; }
        public int ProjectId { get; set; }
    }
}