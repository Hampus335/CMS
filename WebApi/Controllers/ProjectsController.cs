using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(IProjectsService projectsService) : ControllerBase
    {
        private readonly IProjectsService _projectService = projectsService;

        [HttpPost]
        public async Task<IActionResult> Create(ProjectsRegistrationForm form)
        {
            if (!ModelState.IsValid && form.CustomerId < 1)
                return BadRequest();
            var result = await _projectService.CreateProjectAsync(form);

            return (object)result.StatusCode switch
            {
                201 => Created("", null),
                400 => BadRequest(result.Message),
                409 => Conflict(result.Message),
                _ => Problem(),
            };
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _projectService.GetProjectsAsync();
            return Ok(result.Result);
        }
    }
}
