using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementApi.Controllers;
using ProjectManagementApi.Dtos;
using ProjectManagementApi.Interfaces;

namespace ProjectManagementApi.Tests.Controller
{
    public class UserControllerTests
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserControllerTests()
        {
            _userService = A.Fake<IUserService>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public async Task UserController_GetUsers_ReturnOkAsync()
        {
            // Arrange
            var users = A.Fake<ICollection<GetUserDto>>();
            var usersList = A.Fake<List<GetUserDto>>();
            A.CallTo(() => _mapper.Map<List<GetUserDto>>(users)).Returns(usersList);
            var controller = new UserController(_userService);

            // Act
            var result = await controller.GetUsers();

            // Assert
            result.Should().NotBeNull().And.BeOfType(typeof(OkObjectResult));
            result.As<OkObjectResult>().Value.Should().NotBeNull().And.BeAssignableTo<List<GetUserDto>>();
        }
    }
}
