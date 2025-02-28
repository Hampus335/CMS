using Business.Factories;
using Business.Interface;
using Business.Models;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(ILogger<ProjectsController> _logger, IProjectService _projectService) : ControllerBase
    {
    
        [HttpPost]
        public async Task<IActionResult> Create(ProjectRegistrationForm form)
        {
            if (!ModelState.IsValid && form.CustomerId < 1)
                return BadRequest();
            var result = await _projectService.CreateProjectAsync(form);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProjectUpdateform form)
        {
            form.Id = id;
            form.Customer = await _projectService.AddCustomerToProject(id);
            if (!ModelState.IsValid || form.Id < 1)
                return BadRequest("Ogiltiga data.");

            var result = await _projectService.UpdateProjectAsync(form);

            if (!result)
                return NotFound("Projektet kunde inte uppdateras eller hittades inte.");

            return Ok("Projektet har uppdaterats.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        }
    }
}           
