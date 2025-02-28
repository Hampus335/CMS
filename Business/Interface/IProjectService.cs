using Business.Factories;
using Business.Models;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public interface IProjectService
    {
        Task<CustomerEntity?> AddCustomerToProject(int customerId);
        Task<bool> CreateProjectAsync(ProjectRegistrationForm form);
        Task<IEnumerable<Project?>> GetAllProjectsAsync();
        Task<bool> UpdateProjectAsync(ProjectUpdateform form);

    }
}