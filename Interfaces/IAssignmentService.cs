using ProjectManagementApi.Dtos;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Interfaces
{
    public interface IAssignmentService
    {
        Task<ServiceResponse<List<GetAssignmentDto>>> GetAllAssignments();
        Task<ServiceResponse<GetAssignmentDto>> GetAssignmentById(int id);
        Task<ServiceResponse<List<GetAssignmentDto>>> AddAssignment(AddAssignmentDto newAssignment);
        Task<ServiceResponse<GetAssignmentDto>> UpdateAssignment(UpdateAssignmentDto updatedAssignment);
        Task<ServiceResponse<List<GetAssignmentDto>>> DeleteAssignment(int id);
    }
}
