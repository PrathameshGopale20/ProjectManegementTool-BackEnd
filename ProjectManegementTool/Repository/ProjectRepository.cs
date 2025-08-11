using Microsoft.EntityFrameworkCore;
using ProjectManegementTool.Data;
using ProjectManegementTool.Dto_s;
using ProjectManegementTool.Interface;
using ProjectManegementTool.Models;

namespace ProjectManegementTool.Repository
{
    public class ProjectRepository:IProjectRepository
    {
        private readonly AppDbContext _context;
        public ProjectRepository(AppDbContext context) => _context = context;

        public async Task<Project> CreateProjectAsync(CreateProjectDto dto)
        {
            var project = new Project
            {
                ProjectName = dto.ProjectName,
                CustomerName = dto.CustomerName,
                Start_Date = dto.Start_Date,
                End_Date = dto.End_Date,
                Duration = dto.Duration,
                Status = dto.Status
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<List<CreateProjectDto>> GetAllProjectsAsync()
        {
            return await _context.Projects
                .Select(p => new CreateProjectDto
                {
                    Id = p.Id,
                    ProjectName = p.ProjectName,
                    CustomerName = p.CustomerName,
                    Duration = p.Duration,
                    Status = p.Status
                }).ToListAsync();
        }

        public async Task<Project?> GetProjectByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<bool> UpdateProjectAsync(int id, CreateProjectDto dto)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return false;

            if (!string.IsNullOrEmpty(dto.ProjectName)) project.ProjectName = dto.ProjectName;
            if (!string.IsNullOrEmpty(dto.Status)) project.Status = dto.Status;

            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return false;

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

