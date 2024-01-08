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

        public async Task<List<GetProjectDto>> AddProject(AddProjectDto newProject)
        {
            await _context.Projects.AddAsync(_mapper.Map<Project>(newProject));
            await _context.SaveChangesAsync();

            var projects = await _context.Projects.ToListAsync();
            return _mapper.Map<List<GetProjectDto>>(projects);
        }

        public async Task<List<GetProjectDto>> DeleteProject(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }

            var projects = await _context.Projects.ToListAsync();
            return _mapper.Map<List<GetProjectDto>>(projects);
        }

        public async Task<List<GetProjectDto>> GetAllProjects()
        {
            var projects = await _context.Projects.ToListAsync();
             return _mapper.Map<List<GetProjectDto>>(projects);
        }

        public async Task<GetProjectDto> GetProjectById(int id)
        {
            var project = await _context.Projects
                .Include(p => p.CreatedBy)
                .FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<GetProjectDto>(project);
        }

        public async Task<List<GetProjectDto>> GetProjectsByPMId(int id)
        {
            var projects = await _context.Projects
                .Where(p => p.CreatedById == id)
                .ToListAsync();
            return _mapper.Map<List<GetProjectDto>>(projects);
        }

        public async Task<GetProjectDto> UpdateProject(UpdateProjectDto updatedProject)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == updatedProject.Id);
            if (project != null)
            {
                project.Name = updatedProject.Name;
                project.Description = updatedProject.Description;
                project.Status = updatedProject.Status;
                project.DeadlineDate = updatedProject.DeadlineDate;
                project.Priority = updatedProject.Priority;

                _context.Projects.Update(project);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<GetProjectDto>(project);
        }
    }
}
