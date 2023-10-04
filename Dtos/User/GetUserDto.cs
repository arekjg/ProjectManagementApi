using ProjectManagementApi.Helper;

namespace ProjectManagementApi.Dtos
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public UserType UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastEdited { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte[] Image { get; set; }
        public int SupervisorId { get; set; }
    }
}
