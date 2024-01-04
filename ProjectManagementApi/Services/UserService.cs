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

            return _context.Users.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
        }

        public async Task<List<GetUserDto>> DeleteUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }

            return await _context.Users.Select(u => _mapper.Map<GetUserDto>(u)).ToListAsync();
        }

        public async Task<List<GetUserDto>> GetAllEmployees()
        {
            return await _context.Users
                .Where(u => u.UserType == Helper.UserType.EMPLOYEE)
                .Select(u => _mapper.Map<GetUserDto>(u))
                .ToListAsync();
        }

        public async Task<List<GetUserDto>> GetAllPMs()
        {
            return await _context.Users
                .Where(u => u.UserType == Helper.UserType.PROJECT_MANAGER)
                .Select(u => _mapper.Map<GetUserDto>(u))
                .ToListAsync();
        }

        public async Task<List<GetUserDto>> GetAllUsers()
        {
            return await _context.Users.Select(u => _mapper.Map<GetUserDto>(u)).ToListAsync();
        }

        public async Task<List<GetUserDto>> GetEmployeesByPMId(int id)
        {
            return await _context.Users
                .Where(u => u.SupervisorId == id)
                .Select(u => _mapper.Map<GetUserDto>(u))
                .ToListAsync();
        }

        public async Task<GetUserDto> GetUserById(int id)
        {
            return _mapper.Map<GetUserDto>(await _context.Users
                .Include(u => u.Supervisor)
                .FirstOrDefaultAsync(u => u.Id == id));
        }

        public async Task<GetUserDto> UpdateUser(UpdateUserDto updatedUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == updatedUser.Id);
            if (user != null)
            {
                user.UserType = updatedUser.UserType;
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.Supervisor = updatedUser.Supervisor;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }

            return _mapper.Map<GetUserDto>(user);
        }
    }
}
