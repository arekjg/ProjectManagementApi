namespace ProjectManagementApi.Dtos
{
    public class UpdateProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public int Priority { get; set; }
    }
}
