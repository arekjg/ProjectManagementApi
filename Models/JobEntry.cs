namespace ProjectManagementApi.Models
{
    public class JobEntry
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Started { get; set; }
        public DateTime Ended { get; set; }
        public TimeSpan TimePassed { get; set; }
    }
}
