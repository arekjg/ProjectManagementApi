using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Data;
using ProjectManagementApi.Dtos;
using ProjectManagementApi.Interfaces;
using ProjectManagementApi.Models;
using System.Net;

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

        public async Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUser)
        {
            ServiceResponse<List<GetUserDto>> serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                await _context.Users.AddAsync(_mapper.Map<User>(newUser));
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Users.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
            }
            catch (Exception e)
            {
                serviceResponse.Code = HttpStatusCode.InternalServerError;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            ServiceResponse<List<GetUserDto>> serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Users.Select(u => _mapper.Map<GetUserDto>(u)).ToListAsync();
                }
                else
                {
                    serviceResponse.Code = HttpStatusCode.NotFound;
                    serviceResponse.Message = $"User with ID = {id} not found.";
                }
            }
            catch (Exception e)
            {
                serviceResponse.Code = HttpStatusCode.InternalServerError;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
        {
            ServiceResponse<List<GetUserDto>> serviceResponse = new ServiceResponse<List<GetUserDto>>();
            try
            {
                var users = await _context.Users.Select(u => _mapper.Map<GetUserDto>(u)).ToListAsync();
                serviceResponse.Data = users;
            }
            catch (Exception e)
            {
                serviceResponse.Code = HttpStatusCode.InternalServerError;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> GetUserById(int id)
        {
            ServiceResponse<GetUserDto> serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {
                var user = _mapper.Map<GetUserDto>(await _context.Users.FirstOrDefaultAsync(u => u.Id == id));
                if (user != null)
                {
                    serviceResponse.Data = user;
                }
                else
                {
                    serviceResponse.Code = HttpStatusCode.NotFound;
                    serviceResponse.Message = $"User with ID = {id} not found.";
                }
            }
            catch (Exception e)
            {
                serviceResponse.Code = HttpStatusCode.InternalServerError;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser)
        {
            ServiceResponse<GetUserDto> serviceResponse = new ServiceResponse<GetUserDto>();
            try
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

                    serviceResponse.Data = _mapper.Map<GetUserDto>(user);
                }
                else
                {
                    serviceResponse.Code = HttpStatusCode.NotFound;
                    serviceResponse.Message = $"User with ID = {updatedUser.Id} not found.";
                }
            }
            catch (Exception e)
            {
                serviceResponse.Code = HttpStatusCode.InternalServerError;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }
    }
}
