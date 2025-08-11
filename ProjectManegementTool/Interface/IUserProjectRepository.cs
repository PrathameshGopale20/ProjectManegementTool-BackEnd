using ProjectManegementTool.Dto_s;

namespace ProjectManegementTool.Interface
{
    public interface IUserProjectRepository
    {
        Task<bool> AssignUserToProject(AssignUserToProjectDto dto); 
    }
}
