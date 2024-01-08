using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementApi.Controllers;
using ProjectManagementApi.Dtos;
using ProjectManagementApi.Helper;
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

        private readonly List<GetUserDto> _usersTestCases = new List<GetUserDto>
        {
                new()
                {
                    Id = 1,
                    UserType = UserType.ADMIN,
                    FirstName = "Rick",
                    LastName = "Sanchez"
                },
                new()
                {
                    Id = 2,
                    UserType = UserType.PROJECT_MANAGER,
                    FirstName = "Morty",
                    LastName = "Smith"
                },
                new()
                {
                    Id = 3,
                    UserType = UserType.EMPLOYEE,
                    FirstName = "Summer",
                    LastName = "Smith",
                    SupervisorId = 2
                }
        };

        [Fact]
        public async Task UserController_GetUsers_ReturnOk()
        {
            // Arrange
            A.CallTo(() => _userService.GetAllUsers()).Returns(_usersTestCases);
            var controller = new UserController(_userService);

            // Act
            var result = await controller.GetUsers();

            // Assert
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var okResult = (OkObjectResult)result;
            okResult.Value.Should().NotBeNull().And.BeAssignableTo<List<GetUserDto>>();

            var returnedUsers = okResult.Value as List<GetUserDto>;
            returnedUsers.Should().HaveCount(_usersTestCases.Count);

            if (returnedUsers != null)
            {
                foreach (var userDto in returnedUsers)
                {
                    userDto.Should().BeOfType<GetUserDto>();
                }
                returnedUsers
                    .Where(u => u.Id == 2).First().FirstName
                    .Should().BeEquivalentTo("Morty");
            }
        }

        [Fact]
        public async Task UserController_GetEmployees_ReturnOk()
        {
            // Arrange
            var employees = _usersTestCases.Where(u => u.UserType == UserType.EMPLOYEE).ToList();
            A.CallTo(() => _userService.GetAllEmployees()).Returns(employees);
            var controller = new UserController(_userService);

            // Act
            var result = await controller.GetEmployees();

            // Assert
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var okResult = (OkObjectResult)result;
            okResult.Value.Should().NotBeNull().And.BeAssignableTo<List<GetUserDto>>();

            var returnedEmployees = okResult.Value as List<GetUserDto>;
            returnedEmployees.Should().HaveCount(employees.Count);

            if (returnedEmployees != null)
            {
                foreach (var userDto in returnedEmployees)
                {
                    userDto.Should().BeOfType<GetUserDto>();
                    userDto.UserType.Should().Be(UserType.EMPLOYEE);
                }
                returnedEmployees.First().FirstName
                    .Should().BeEquivalentTo("Summer");
            }
        }

        [Fact]
        public async Task UserController_GetPMs_ReturnOk()
        {
            // Arrange
            var pms = _usersTestCases.Where(u => u.UserType == UserType.PROJECT_MANAGER).ToList();
            A.CallTo(() => _userService.GetAllPMs()).Returns(pms);
            var controller = new UserController(_userService);

            // Act
            var result = await controller.GetPMs();

            // Assert
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var okResult = (OkObjectResult)result;
            okResult.Value.Should().NotBeNull().And.BeAssignableTo<List<GetUserDto>>();

            var returnedPMs = okResult.Value as List<GetUserDto>;
            returnedPMs.Should().HaveCount(pms.Count);

            if (returnedPMs != null)
            {
                foreach (var userDto in returnedPMs)
                {
                    userDto.Should().BeOfType<GetUserDto>();
                    userDto.UserType.Should().Be(UserType.PROJECT_MANAGER);
                }
                returnedPMs.First().FirstName
                    .Should().BeEquivalentTo("Morty");
            }
        }

        [Fact]
        public async Task UserController_GetById_ReturnOk()
        {
            // Arrange
            const int userId = 1;
            var userDto = new GetUserDto { Id = userId, FirstName = "Summer" };

            A.CallTo(() => _userService.GetUserById(userId)).Returns(userDto);
            var controller = new UserController(_userService);

            // Act
            var result = await controller.GetById(userId);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = (OkObjectResult)result;
            okResult.Value.Should().NotBeNull().And.BeAssignableTo<GetUserDto>();

            var returnedUserDto = okResult.Value as GetUserDto;
            returnedUserDto.Should().BeEquivalentTo(userDto);
        }

        [Fact]
        public async Task UserController_GetById_ReturnNotFound()
        {
            // Arrange
            const int invalidUserId = -1;

            A.CallTo(() => _userService.GetUserById(invalidUserId)).Returns((GetUserDto?)null);
            var controller = new UserController(_userService);

            // Act
            var result = await controller.GetById(invalidUserId);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }


    }
}