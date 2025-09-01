using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Interfaces;
using AutoMapper;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController(ApplicationDbContext context, IMapper mapper, IGenericRepository<Project> ProjectRepository) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectDto projectDto, CancellationToken cancellationToken)
        {
            var project = mapper.Map<Project>(projectDto);
            ProjectRepository.Add(project);
            await context.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetProjectById), new { project.Pno }, project);
        }

        [HttpGet]
        public IActionResult GetProjects(int pageNumber=1,int pageSize=10)
        {
            var projects = ProjectRepository.GetAll();
            var projectsDto = mapper.Map<List<ProjectDto>>(projects).Skip(pageNumber - 1)
                .Take(pageSize).ToList();
            return Ok(projectsDto);
        }

        [HttpGet("get-by-id")]
        public IActionResult GetProjectById(int id)
        {
            var project = ProjectRepository.GetById(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProject(int id)
        {
            var project = ProjectRepository.GetById(id);
            if (project == null)
            {
                return NotFound();
            }

            ProjectRepository.Delete(project);
            context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateProject(int id, ProjectDto updatedProject)
        {
            var project = ProjectRepository.GetById(id);
            if (project == null)
            {
                return NotFound();
            }

            var newProject = mapper.Map(updatedProject, project);
            ProjectRepository.Update(newProject);
            context.SaveChanges();

            return Ok(newProject);
        }
    }
}
