using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManegementTool.Dto_s;
using ProjectManegementTool.Interface;

namespace ProjectManegementTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _repo;
        public ProjectController(IProjectRepository repo) => _repo = repo;

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectDto dto)
        {
            var project = await _repo.CreateProjectAsync(dto);
            return Ok(project);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _repo.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _repo.GetProjectByIdAsync(id);
            if (project == null) return NotFound();
            return Ok(project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateProjectDto dto)
        {
            var success = await _repo.UpdateProjectAsync(id, dto);
            if (!success) return NotFound();
            return Ok("Project updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repo.DeleteProjectAsync(id);
            if (!success) return NotFound();
            return Ok("Project deleted");
        }
    }
}
