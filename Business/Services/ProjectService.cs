
using Business.Factories;
using Business.Interface;
using Business.Models;
using Business.Models.Customer;
using Business.Models.Response;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;
using System.Net.Http.Headers;


namespace Business.Services
{
    public class ProjectService(IProjectRepository projectRepository) : IProjectService
    {
        private readonly IProjectRepository _projectRepository = projectRepository;

        public async Task<Project> CreateProjectAsync(ProjectRegistrationForm form)
        {
            var entity = await _projectRepository.GetAsync(x => x.ProjectName == form.ProjectName);
            entity ??= await _projectRepository.AddAsync(ProjectFactory.Create(form));

            return ProjectFactory.Create(entity);

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
            return (ResponseResult<IEnumerable<Project?>>)ResponseResult<IEnumerable<Project>>.Ok(result: projects);

        }

        public async Task<ResponseResult<Project?>> GetProjectAsync(Expression<Func<ProjectEntity, bool>> expression)
        {
            var entity = await _projectRepository.GetAsync(expression);
            var project = ProjectFactory.Create(entity);
            return (ResponseResult<Project?>)ResponseResult<Project?>.Ok(result: ProjectFactory.Create(entity));

        }

        public async Task<ResponseResult<Project?>> UpdateProjectAsync(ProjectUpdateForm form)
        {
            var entity = await _projectRepository.UpdateAsync(ProjectFactory.Create(form));
            return ResponseResult<Project>.Ok(result: ProjectFactory.Create(entity);
        }
    }
}
