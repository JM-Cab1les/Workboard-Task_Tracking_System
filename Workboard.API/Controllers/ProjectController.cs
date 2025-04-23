using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workboard.Application.DTO;
using Workboard.Application.Interfaces;
using Workboard.Domain.Entities;
using Workboard.Domain.SPEntity;

namespace Workboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService_;

        public ProjectController(IProjectService projectService)
        {
            projectService_ = projectService;
        }

        [HttpGet("GetProjectList")]
        public async Task<ActionResult<List<spRetrieveProjectListResult>>> GetProjectList()
        {
            return await projectService_.GetProjectList();
        }

        [HttpGet("GetProjectCount")]
        public async Task<int> GetProjectCount()
        {
            return await projectService_.GetProjectCount();
        }


        [HttpPost("AddNewProject")]
        public async Task<IActionResult> AddNewProject([FromBody] ProjectDto newProject)
        {
            try
            {
                await projectService_.AddProject(newProject);
                return Ok(new { message = "New Project Added" });
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpDelete("DeleteProject/{projectId}")]
        public IActionResult DeleteProject(int projectId)
        {
            try
            {
                projectService_.DeleteProject(projectId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { messsage = ex.Message });
            }
          
        }

        [HttpPut("UpdateProject/{id}")]
        public ActionResult<Project> UpdateProject(int id, ProjectDto project)
        {
            try
            {
                projectService_.UpdateProject(id, project);
                return Ok(new { message = "Project Updsated" });
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }


    }
}
