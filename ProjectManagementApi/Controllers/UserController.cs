using Microsoft.AspNetCore.Mvc;
using ProjectManagementApi.Dtos;
using ProjectManagementApi.Helper;
using ProjectManagementApi.Interfaces;

namespace ProjectManagementApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                GetUserDto? user = await _userService.GetUserById(id);
                return ResponseUtility.OkOrNotFound(user);
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                List<GetUserDto> employees = await _userService.GetAllEmployees();
                return ResponseUtility.OkOrNotFound(employees);
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

        [HttpGet("pms")]
        public async Task<IActionResult> GetPMs()
        {
            try
            {
                List<GetUserDto> pms = await _userService.GetAllPMs();
                return ResponseUtility.OkOrNotFound(pms);
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                List<GetUserDto> users = await _userService.GetAllUsers();
                return ResponseUtility.OkOrNotFound(users);
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

        [HttpGet("pm/{id}")]
        public async Task<IActionResult> GetByPMId(int id)
        {
            try
            {
                List<GetUserDto> employees = await _userService.GetEmployeesByPMId(id);
                return ResponseUtility.OkOrNotFound(employees);
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserDto newUser)
        {
            try
            {
                return Ok(await _userService.AddUser(newUser));
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateUserDto updatedUser)
        {
            try
            {
                return Ok(await _userService.UpdateUser(updatedUser));
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                List<GetUserDto> users = await _userService.DeleteUser(id);
                return ResponseUtility.OkOrNotFound(users);
            }
            catch (Exception e)
            {
                return ResponseUtility.InternalServerError(e);
            }
        }
    }
}
