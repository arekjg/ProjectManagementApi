using ProjectManagementApi.Helper;

namespace ProjectManagementApi.Dtos
{
    public class AddUserDto
    {
        public UserType UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte[] Image { get; set; }
        public int SupervisorId { get; set; }
    }
}
