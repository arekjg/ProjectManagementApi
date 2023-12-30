using ProjectManagementApi.Dtos;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDto>>> GetAllUsers();
        Task<ServiceResponse<List<GetUserDto>>> GetAllEmployees();
        Task<ServiceResponse<List<GetUserDto>>> GetAllPMs();
        Task<ServiceResponse<List<GetUserDto>>> GetEmployeesByPMId(int id);
        Task<ServiceResponse<GetUserDto>> GetUserById(int id);
        Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUser);
        Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser);
        Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id);
    }
}
