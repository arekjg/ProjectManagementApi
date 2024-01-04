using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Data;
using ProjectManagementApi.Dtos;
using ProjectManagementApi.Interfaces;
using ProjectManagementApi.Models;
using System.Net;

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

            return _context.Projects.Select(p => _mapper.Map<GetProjectDto>(p)).ToList();
        }

        public async Task<List<GetProjectDto>> DeleteProject(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }

            return await _context.Projects.Select(p => _mapper.Map<GetProjectDto>(p)).ToListAsync();
        }

        public async Task<List<GetProjectDto>> GetAllProjects()
        {
             return await _context.Projects.Select(p => _mapper.Map<GetProjectDto>(p)).ToListAsync();
        }

        public async Task<GetProjectDto> GetProjectById(int id)
        {
            return _mapper.Map<GetProjectDto>(await _context.Projects.FirstOrDefaultAsync(p => p.Id == id));
        }

        public async Task<List<GetProjectDto>> GetProjectsByPMId(int id)
        {
            return await _context.Projects
                .Where(p => p.CreatedById == id)
                .Select(p => _mapper.Map<GetProjectDto>(p))
                .ToListAsync();
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
