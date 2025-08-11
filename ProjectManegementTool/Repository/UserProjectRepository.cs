using Microsoft.EntityFrameworkCore;
using ProjectManegementTool.Data;
using ProjectManegementTool.Dto_s;
using ProjectManegementTool.Interface;
using ProjectManegementTool.Models;

namespace ProjectManegementTool.Repository
{
    public class UserProjectRepository :IUserProjectRepository
    {
        private readonly AppDbContext _context;

        public UserProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AssignUserToProject(AssignUserToProjectDto dto)
        {
            var exists = await _context.UserProjectMappings
                .AnyAsync(up => up.UsersId == dto.UsersId && up.ProjectId == dto.ProjectId);

            if (exists) return false; // already assigned

            var mapping = new UserProjectMapping
            {
                UsersId = dto.UsersId,
                ProjectId = dto.ProjectId,
                AssignedRole = dto.AssignedRole
            };

            await _context.UserProjectMappings.AddAsync(mapping);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
