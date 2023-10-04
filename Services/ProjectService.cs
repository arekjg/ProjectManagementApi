using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Data;
using ProjectManagementApi.Dtos;
using ProjectManagementApi.Interfaces;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Services
{
    public class ProjectService : IProjectService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProjectService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetProjectDto>>> AddProject(AddProjectDto newProject)
        {
            ServiceResponse<List<GetProjectDto>> serviceResponse = new ServiceResponse<List<GetProjectDto>>();
            await _context.Projects.AddAsync(_mapper.Map<Project>(newProject));
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Projects.Select(p => _mapper.Map<GetProjectDto>(p)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProjectDto>>> DeleteProject(int id)
        {
            ServiceResponse<List<GetProjectDto>> serviceResponse = new ServiceResponse<List<GetProjectDto>>();
            try
            {
                var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
                if (project != null)
                {
                    _context.Projects.Remove(project);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.Projects.Select(p => _mapper.Map<GetProjectDto>(p)).ToListAsync();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Project not found.";
                }
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProjectDto>>> GetAllProjects()
        {
            ServiceResponse<List<GetProjectDto>> serviceResponse = new ServiceResponse<List<GetProjectDto>>();
            var projects = await _context.Projects.Select(p => _mapper.Map<GetProjectDto>(p)).ToListAsync();
            serviceResponse.Data = projects;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProjectDto>> GetProjectById(int id)
        {
            ServiceResponse<GetProjectDto> serviceResponse = new ServiceResponse<GetProjectDto>();
            var project = _mapper.Map<GetProjectDto>(await _context.Projects.FirstOrDefaultAsync(p => p.Id == id));
            serviceResponse.Data = project;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProjectDto>> UpdateProject(UpdateProjectDto updatedProject)
        {
            ServiceResponse<GetProjectDto> serviceResponse = new ServiceResponse<GetProjectDto>();
            try
            {
                var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == updatedProject.Id);
                if (project != null)
                {
                    project.Name = updatedProject.Name;
                    project.Description = updatedProject.Description;
                    project.Status = updatedProject.Status;
                    project.Deadline = updatedProject.Deadline;
                    project.Priority = updatedProject.Priority;

                    _context.Projects.Update(project);
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetProjectDto>(project);
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Project not found.";
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
