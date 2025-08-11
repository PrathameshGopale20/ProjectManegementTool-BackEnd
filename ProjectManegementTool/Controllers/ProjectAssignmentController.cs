using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManegementTool.Dto_s;
using ProjectManegementTool.Interface;

namespace ProjectManegementTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectAssignmentController : ControllerBase
    {

        private readonly IUserProjectRepository _repository;

        public ProjectAssignmentController(IUserProjectRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignUserToProject(AssignUserToProjectDto dto)
        {
            var success = await _repository.AssignUserToProject(dto);
            if (!success) return BadRequest("User already assigned to this project");

            return Ok("Assignment successful");
        }
    }
}
