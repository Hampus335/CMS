using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(IProjectService projectsService) : ControllerBase
    {
        private readonly IProjectService _projectService = projectsService;

        [HttpPost]
        public async Task<IActionResult> Create(ProjectRegistrationForm form)
        {
            if (!ModelState.IsValid && form.CustomerId < 1)
                return BadRequest();
            var result = await _projectService.CreateProjectAsync(form);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        }
    }
}
