using Business.Interface;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(IProjectsService projectsService) : ControllerBase
    {
        private readonly IProjectsService _projectService = projectsService;

        [HttpPost]
        public async Task<IActionResult> Create(ProjectRegistrationForm form)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _projectService(form);

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
            var result = await _projectService.g();
            return Ok(result.Result);
        }
    }
}
