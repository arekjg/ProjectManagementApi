using ProjectManagementApi.Helper;

namespace ProjectManagementApi.Dtos
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public UserType UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Image { get; set; }
        public int SupervisorId { get; set; }
    }
}
