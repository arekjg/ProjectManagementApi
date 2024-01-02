using ProjectManagementApi.Helper;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Dtos
{
    public class AddUserDto
    {
        public UserType UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CreatedAtDate { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string? Avatar{ get; set; }
        public int? SupervisorId { get; set; }
        public User? Supervisor { get; set; }
    }
}
