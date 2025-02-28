
using Business.Factories;
using Business.Interface;
using Business.Models;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;
using WebApi.Controllers;

namespace Business.Services
{
    public class ProjectService(IProjectRepository projectRepository, ICustomerRepository customerRepository, IProjectFactory projectFactory, DataContext context) : IProjectService
    {
        private readonly IProjectRepository _projectRepository = projectRepository;
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IProjectFactory _projectFactory = projectFactory;
        private readonly DataContext _context = context;
        

        public async Task<CustomerEntity?> AddCustomerToProject(int customerId)
        {
            return await _customerRepository.GetAsync(c => c.Id == customerId);
        }
        public async Task<bool> CreateProjectAsync(ProjectRegistrationForm form)
        {
            if (!await _customerRepository.ExistsAsync(customer => customer.Id == form.CustomerId))
                return false;

            var projectEntity = _projectFactory.Create(form);
            if (projectEntity == null)
                return false;

            bool result = await _projectRepository.AddAsync(projectEntity);
            return result;
        }

        public async Task<IEnumerable<Project?>> GetAllProjectsAsync()
        {
            var entities = await _projectRepository.GetAllAsync();
            var projects = entities.Select(_projectFactory.Create);
            return projects;
        }
            
        public async Task<Project?> GetProjectAsync(Expression<Func<ProjectUpdateform, bool>> expression)
        {
            var entity = await _projectRepository.GetAsync(expression);
            var project = projectFactory.Create(entity);;
            return project;

        }

        //lite GPT här
        public async Task<bool> UpdateProjectAsync(ProjectUpdateform form)
        {
            // Hämta befintligt projekt från databasen
            var existingProject = await _projectRepository.GetAsync(p => p.Id == form.Id);
            if (existingProject == null)
            {
                return false; // Projektet existerar inte
            }

            // Kontrollera vilka fält som har ändrats och uppdatera endast dessa
            bool isUpdated = false;
            if (existingProject.Name != form.Name)
            {
                existingProject.Name = form.Name;
                isUpdated = true;
            }
            if (existingProject.Description != form.Description)
            {
                existingProject.Description = form.Description;
                isUpdated = true;
            }

            // Om inga ändringar har gjorts, returnera true direkt
            if (!isUpdated)
            {
                return true;
            }

            // Uppdatera projektet i databasen
            return await _projectRepository.UpdateAsync(existingProject);
        }

    }
}
