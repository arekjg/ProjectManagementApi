using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Data;
using ProjectManagementApi.Dtos;
using ProjectManagementApi.Interfaces;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AssignmentService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetAssignmentDto>>> AddAssignment(AddAssignmentDto newAssignment)
        {
            ServiceResponse<List<GetAssignmentDto>> serviceResponse = new ServiceResponse<List<GetAssignmentDto>>();
            await _context.Assignments.AddAsync(_mapper.Map<Assignment>(newAssignment));
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Assignments.Select(p => _mapper.Map<GetAssignmentDto>(p)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAssignmentDto>>> DeleteAssignment(int id)
        {
            ServiceResponse<List<GetAssignmentDto>> serviceResponse = new ServiceResponse<List<GetAssignmentDto>>();
            try
            {
                var assignment = await _context.Assignments.FirstOrDefaultAsync(p => p.Id == id);
                if (assignment != null)
                {
                    _context.Assignments.Remove(assignment);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Assignments.Select(p => _mapper.Map<GetAssignmentDto>(p)).ToListAsync();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Assignment not found.";
                }
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAssignmentDto>>> GetAllAssignments()
        {
            ServiceResponse<List<GetAssignmentDto>> serviceResponse = new ServiceResponse<List<GetAssignmentDto>>();
            var assignments = await _context.Assignments.Select(p => _mapper.Map<GetAssignmentDto>(p)).ToListAsync();
            serviceResponse.Data = assignments;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAssignmentDto>> GetAssignmentById(int id)
        {
            ServiceResponse<GetAssignmentDto> serviceResponse = new ServiceResponse<GetAssignmentDto>();
            var assignment = _mapper.Map<GetAssignmentDto>(await _context.Assignments.FirstOrDefaultAsync(p => p.Id == id));
            serviceResponse.Data = assignment;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAssignmentDto>> UpdateAssignment(UpdateAssignmentDto updatedAssignment)
        {
            ServiceResponse<GetAssignmentDto> serviceResponse = new ServiceResponse<GetAssignmentDto>();
            try
            {
                var assignment = await _context.Assignments.FirstOrDefaultAsync(p => p.Id == updatedAssignment.Id);
                if (assignment != null)
                {
                    assignment.Name = updatedAssignment.Name;
                    assignment.Description = updatedAssignment.Description;
                    assignment.Status = updatedAssignment.Status;
                    assignment.Deadline = updatedAssignment.Deadline;
                    assignment.Priority = updatedAssignment.Priority;

                    _context.Assignments.Update(assignment);
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetAssignmentDto>(assignment);
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Assignment not found.";
                }
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }
    }
}
