using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public interface IProjectService
    {
        Task<bool> CreateProjectAsync(ProjectRegistrationForm form);
        Task<IEnumerable<Project?>> GetAllProjectsAsync();
    }
}