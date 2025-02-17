
using Business.Factories;
using Business.Interface;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;
using WebApi.Controllers;

namespace Business.Services
{
    public class ProjectService(IProjectRepository projectRepository, ICustomerRepository customerRepository, IProjectFactory projectFactory) : IProjectService
    {
        private readonly IProjectRepository _projectRepository = projectRepository;
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly IProjectFactory _projectFactory = projectFactory;

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

            
        public async Task<IEnumerable<Project>> GetRepositoryAsync()
        {
            var entities = await _projectRepository.GetAllAsync ();
            foreach (var entity in entities)
            {
                _projectFactory.
            }

        }

        public async Task<IEnumerable<Project?>> GetAllProjectsAsync()
        {
            var entities = await _projectRepository.GetAllAsync();
            var projects = entities.Select(_projectFactory.Create);
            return projects;
        }
            
        public async Task<Project?> GetProjectAsync(Expression<Func<ProjectEntity, bool>> expression)
        {
            var entity = await _projectRepository.GetAsync(expression);
            var project = projectFactory.Create(entity);;
            return project;

        }

        public async Task<Project?> UpdateProjectAsync(ProjectUpdateForm form)
        {
            var entity = await _projectRepository.UpdateAsync(_projectFactory.Create(form));
            return _projectFactory.Create(entity);
        }
    }
}
