using ProjectManagementApi.Dtos;

namespace ProjectManagementApi.Interfaces
{
    public interface IUserService
    {
        Task<List<GetUserDto>> AddUser(AddUserDto newUser);
        Task<List<GetUserDto>> DeleteUser(int id);
        Task<List<GetUserDto>> GetAllEmployees();
        Task<List<GetUserDto>> GetAllPMs();
        Task<List<GetUserDto>> GetAllUsers();
        Task<List<GetUserDto>> GetEmployeesByPMId(int id);
        Task<GetUserDto> GetUserById(int id);
        Task<GetUserDto> UpdateUser(UpdateUserDto updatedUser);
    }
}
