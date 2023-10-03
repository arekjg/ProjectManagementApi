namespace ProjectManagementApi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        //public int CreatedById { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEnded { get; set; }
        public DateTime DateDeadline { get; set; }
        public TimeSpan TimePassed { get; set; }
        public TimeSpan WorkTime { get; set; }
        public int Priority { get; set; }
    }
}
