using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Data;
using ProjectManagementApi.Dtos;
using ProjectManagementApi.Interfaces;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetUserDto>> AddUser(AddUserDto newUser)
        {
            await _context.Users.AddAsync(_mapper.Map<User>(newUser));
            await _context.SaveChangesAsync();

            var users = await _context.Users.ToListAsync();
            return _mapper.Map<List<GetUserDto>>(users);
        }

        public async Task<List<GetUserDto>> DeleteUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }

            var users = await _context.Users.ToListAsync();
            return _mapper.Map<List<GetUserDto>>(users);
        }

        public async Task<List<GetUserDto>> GetAllEmployees()
        {
            var employees = await _context.Users
                .Where(u => u.UserType == Helper.UserType.EMPLOYEE)
                .ToListAsync();
            return _mapper.Map<List<GetUserDto>>(employees);
        }

        public async Task<List<GetUserDto>> GetAllPMs()
        {
            var pms = await _context.Users
                .Where(u => u.UserType == Helper.UserType.PROJECT_MANAGER)
                .ToListAsync();
            return _mapper.Map<List<GetUserDto>>(pms);
        }

        public async Task<List<GetUserDto>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<List<GetUserDto>>(users);
        }

        public async Task<List<GetUserDto>> GetEmployeesByPMId(int id)
        {
            var employees = await _context.Users
                .Where(u => u.SupervisorId == id)
                .ToListAsync();
            return _mapper.Map<List<GetUserDto>>(employees);
        }

        public async Task<GetUserDto?> GetUserById(int id)
        {
            var user = await _context.Users
                .Include(u => u.Supervisor)
                .FirstOrDefaultAsync(u => u.Id == id);
            return _mapper.Map<GetUserDto>(user);
        }

        public async Task<GetUserDto> UpdateUser(UpdateUserDto updatedUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == updatedUser.Id);
            if (user != null)
            {
                user.UserType = updatedUser.UserType;
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.SupervisorId = updatedUser.SupervisorId;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<GetUserDto>(user);
        }
    }
}