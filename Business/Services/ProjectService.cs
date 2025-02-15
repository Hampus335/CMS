
using Business.Factories;
using Business.Interface;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;


namespace Business.Services
{
    public class ProjectService(IProjectRepository projectRepository, ICustomerRepository customerRepository) : IProjectService
    {
        private readonly IProjectRepository _projectRepository = projectRepository;
        private readonly ICustomerRepository _customerRepository = customerRepository;
        public ProjectFactory ProjectFactory { get; set; }
        public ProjectService(ProjectFactory projectFactory)
        {
            ProjectFactory = projectFactory;
        }

        public async Task<bool> CreateProjectAsync(ProjectRegistrationForm form)
        {
            if (!await _customerRepository.ExistsAsync(customer => customer.Id == form.CustomerId))
                return false;

            var projectEntity = ProjectFactory.Create(form);
            if (projectEntity == null)
                return false;

            bool result = await _projectRepository.AddAsync(projectEntity);
            return result;

        }


        public async Task<ResponseResult<IEnumerable<Project>>> GetRepositoryAsync()
        {
            var entities = await _projectRepository.GetAllAsync ();
            return (ResponseResult<IEnumerable<Project>>)ResponseResult<IEnumerable<Project>>.Ok(result: entities.Select(ProjectFactory.Create)!);

        }

        public async Task<ResponseResult<IEnumerable<Project?>>> GetAllProjectsAsync()
        {
            var entities = await _projectRepository.GetAllAsync();
            var projects = entities.Select(ProjectFactory.Create);
            return projects;
        }

        public async Task<ResponseResult<Project?>> GetProjectAsync(Expression<Func<ProjectEntity, bool>> expression)
        {
            var entity = await _projectRepository.GetAsync(expression);
            var project = entity ProjectFactory.Create(entity);
            return project;

        }

        public async Task<ResponseResult<Project?>> UpdateProjectAsync(ProjectUpdateForm form)
        {
            var entity = await _projectRepository.UpdateAsync(ProjectFactory.Create(form));
            return ResponseResult<Project>.Ok(result: ProjectFactory.Create(entity);
        }
    }
}
