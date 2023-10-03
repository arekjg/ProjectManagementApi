namespace ProjectManagementApi.Dtos
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int SupervisorId { get; set; }
    }
}
