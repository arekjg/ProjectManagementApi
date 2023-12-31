using Microsoft.AspNetCore.Mvc;
using ProjectManagementApi.Dtos;
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
            return Ok(await _userService.GetUserById(id));
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await _userService.GetAllEmployees());
        }

        [HttpGet("pms")]
        public async Task<IActionResult> GetPMs()
        {
            return Ok(await _userService.GetAllPMs());
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("pm/{id}")]
        public async Task<IActionResult> GetByPMId(int id)
        {
            return Ok(await _userService.GetEmployeesByPMId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserDto newUser)
        {
            return Ok(await _userService.AddUser(newUser));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateUserDto updatedUser)
        {
            return Ok(await _userService.UpdateUser(updatedUser));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _userService.DeleteUser(id));
        }
    }
}
