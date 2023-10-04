using Microsoft.AspNetCore.Mvc;
using ProjectManagementApi.Dtos;
using ProjectManagementApi.Interfaces;

namespace ProjectManagementApi.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userService.GetUserById(id));
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
