using ProjectManegementTool.Dto_s;
using ProjectManegementTool.Models;

namespace ProjectManegementTool.Interface
{
    public interface IProjectRepository
    {
        Task<Project> CreateProjectAsync(CreateProjectDto dto);
        Task<List<CreateProjectDto>> GetAllProjectsAsync();
        Task<Project?> GetProjectByIdAsync(int id);
        Task<bool> UpdateProjectAsync(int id, CreateProjectDto dto);
        Task<bool> DeleteProjectAsync(int id);
    }
}
